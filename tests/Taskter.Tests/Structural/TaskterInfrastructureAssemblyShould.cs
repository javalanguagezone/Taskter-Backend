using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using Taskter.Infrastructure.Config;

namespace Taskter.Tests.Structural
{
    [TestFixture]
    public class TaskterInfrastructureAssemblyShould
    {
        private Assembly _assembly;

        [SetUp]
        public void SetUp()
        {
            _assembly = Assembly.GetAssembly(typeof(TaskterInfrastructureAssembly));
        }

        [Test]
        public void NotHaveApiAssemblyReference()
        {
            var referencedAssemblies = _assembly.GetReferencedAssemblies();
            var apiAssembly = referencedAssemblies.FirstOrDefault(x => x.Name == "Taskter.Api");

            apiAssembly.Should().BeNull();
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
