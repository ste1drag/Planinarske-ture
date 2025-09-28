using Identity.Application.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure
{
    public class ResultWrapper : IResult
    {
        private readonly IdentityResult _identityResult;

        public ResultWrapper(IdentityResult identityResult)
        {
            _identityResult = identityResult ?? throw new ArgumentNullException(nameof(identityResult));
        }

        public bool Succeeded => _identityResult.Succeeded;

        bool IResult.Succeeded { get => Succeeded; set => throw new NotImplementedException(); }
    }
}
