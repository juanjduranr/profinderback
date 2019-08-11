using System;
using System.Collections.Generic;
using System.Text;

namespace ProFinder.Core.Entities
{
    public class Token
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public bool IsError { get; }

        public Token(string error,
                     string errorDescription)
        {
            AccessToken = string.Empty;
            ExpiresIn = 0;
            Error = error;
            ErrorDescription = errorDescription;
            IsError = true;
        }

        public Token(string accessToken,
                     int expiresIn)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            Error = string.Empty;
            ErrorDescription = string.Empty;
            IsError = false;
        }
    }
}
