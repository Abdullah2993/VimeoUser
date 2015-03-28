using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VimeoUser.Package;

namespace VimeoUser
{
    public class Client : IDisposable
    {
        private const string AuthUri = "https://api.vimeo.com/oauth/authorize/client";
        private const string AuthContent = "grant_type=client_credentials";
        private const string AuthContentType = "application/x-www-form-urlencoded";
        private const string FetchUri = "https://api.vimeo.com/users/{0}/videos?page={1}&per_page=50&sort=date&direction=asc";


        private HttpClient _client;

        public Client()
        {
            _client = new HttpClient();
        }

        public async Task AuthenticateAsync(string authCode)
        {
            await Task.Run(() => Authenticate(authCode));
        }

        private static string GetFetchUri(string user,int page)
        {
            return string.Format(FetchUri, user,page);
        }

        private async Task Authenticate(string authCode)
        {
            //if(authCode==null)
            //    throw new ArgumentNullException("authCode");
            //if(authCode==string.Empty)
            //    throw new ArgumentException("Authentication code must be passed,","authCode");

            var request = new HttpRequestMessage(HttpMethod.Post, AuthUri);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", authCode);
            request.Content = new StringContent(AuthContent, Encoding.UTF8, AuthContentType);

            var response = await _client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            var authResult = JsonConvert.DeserializeObject<AuthResult>(result);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authResult.token_type, authResult.access_token);
        }

        public async Task<Results> FetchVideos(string user,int page)
        {
            var result = await _client.GetStringAsync(GetFetchUri(user,page));
            return JsonConvert.DeserializeObject<Results>(result);
        }

        public async Task<Results> FetchAllVideos(string user)
        {
            var tempResult = await FetchVideos(user,1);
            var result = tempResult;
            while (result.paging.next != null)
            {
                var source = await _client.GetStringAsync("https://api.vimeo.com" + result.paging.next);
                result = JsonConvert.DeserializeObject<Results>(source);
                tempResult.data.AddRange(result.data.ToArray());
            }
            return tempResult;
        }

        public void Dispose()
        {
            if (_client == null)
                throw new ObjectDisposedException("Client already disposed");

            _client.Dispose();
            _client = null;
            GC.SuppressFinalize(this);

        }
    }
}