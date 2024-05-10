﻿namespace BibliotecaAuth.Utils
{
    public class AuthJwt
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public int ExpireMin { get; set; }
    }
}
