using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using Taskter.Api.Config;

namespace Taskter.Tests.Structural
{
    public class TaskterApiAssemblyShould
    {
        private Assembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = Assembly.GetAssembly(typeof(TaskterApiAssembly));
        }

        [Test]
        public void NotHaveApiAssemblyReference()
        {
            var referencedAssemblies = _assembly.GetReferencedAssemblies();
            var apiAssembly = referencedAssemblies.FirstOrDefault(x => x.Name == "Taskter.Infrastructure");

            apiAssembly.Should().NotBeNull();
        }

        [Test]
        public void HaveCoreAssemblyReference()
        {
            var referencedAssemblies = _assembly.GetReferencedAssemblies();
            var apiAssembly = referencedAssemblies.FirstOrDefault(x => x.Name == "Taskter.Core");

            apiAssembly.Should().NotBeNull();
        }
    }
}
