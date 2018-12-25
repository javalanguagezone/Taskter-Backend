using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskter.Core.Entities;

namespace Taskter.Api.Contracts
{
    public static class DummyExtensions
    {
        public static Dummy ToEntity(this DummyInsertDto dummy)
        {
            return new Dummy(dummy.Name);
        }
    }
}
