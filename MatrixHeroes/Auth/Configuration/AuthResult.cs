using System.Collections.Generic;

namespace MatrixHeroes.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
