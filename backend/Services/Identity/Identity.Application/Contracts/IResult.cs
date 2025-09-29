using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Contracts
{
    public interface IResult
    {
        public bool Succeeded { get; protected set;}
    }
}
