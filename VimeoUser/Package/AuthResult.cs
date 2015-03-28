namespace VimeoUser.Package
{
    internal class AuthResult
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string scope { get; set; }
    }
}