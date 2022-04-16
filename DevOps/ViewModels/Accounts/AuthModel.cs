using System;
using System.Collections.Generic;

namespace DevOps.ViewModels.Accounts
{
    public class AuthModel
    {
        public string Messages { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public DateTime ExpiresOn { get; set; }

        public string Token { get; set; }
    }
}
