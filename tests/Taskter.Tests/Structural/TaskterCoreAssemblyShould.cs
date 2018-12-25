using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using Taskter.Core.Config;

namespace Taskter.Tests.Structural
{
    [TestFixture]
    public class TaskterCoreAssemblyShould
    {
        private Assembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = Assembly.GetAssembly(typeof(TaskterCoreAssembly));
        }

        [Test]
        public void NotHaveApiAssemblyReference()
        {
            var referencedAssemblies = _assembly.GetReferencedAssemblies();
            var apiAssembly = referencedAssemblies.FirstOrDefault(x => x.Name == "Taskter.Infrastructure");

            apiAssembly.Should().BeNull();
        }

        [Test]
        public void HaveCoreAssemblyReference()
        {
            var referencedAssemblies = _assembly.GetReferencedAssemblies();
            var apiAssembly = referencedAssemblies.FirstOrDefault(x => x.Name == "Taskter.Api");

            apiAssembly.Should().BeNull();
        }
    }
}
