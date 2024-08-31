using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public class AuthenticationModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
