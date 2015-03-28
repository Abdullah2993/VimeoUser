using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Process.GetCurrentProcess().WaitForExit();
        }

        private static async void Test()
        {
            using (var client = new VimeoUser.Client())
            {
                await client.AuthenticateAsync("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"); //removed
                var videos = await client.FetchAllVideos("username"); //removed
                Console.WriteLine(videos.total);
            }
        }
    }
}
