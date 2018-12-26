using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using Taskter.Api.Config;

namespace Taskter.Tests.Structural
{
    [TestFixture]
    public class TaskterApiAssemblyShould
    {
        private Assembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = Assembly.GetAssembly(typeof(TaskterApiAssembly));
        }

        [Test]
        public void HaveInfrastructureAssemblyReference()
        {
            var referencedAssemblies = _assembly.GetReferencedAssemblies();
            var infrastructureAssembly = referencedAssemblies.FirstOrDefault(x => x.Name == "Taskter.Infrastructure");

            infrastructureAssembly.Should().NotBeNull();
        }

        [Test]
        public void HaveCoreAssemblyReference()
        {
            var referencedAssemblies = _assembly.GetReferencedAssemblies();
            var coreAssembly = referencedAssemblies.FirstOrDefault(x => x.Name == "Taskter.Core");

            coreAssembly.Should().NotBeNull();
        }
    }
}
