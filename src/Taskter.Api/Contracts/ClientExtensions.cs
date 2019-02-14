using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class ClientExtensions
    {
        public static Client ToEntity(this ClientInsertDTO cidto)
        {
            return new Client(cidto.Name);
        }
    }
}
