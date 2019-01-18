using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Taskter.Api;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Tests.Helpers.Factories;

namespace Taskter.Tests.Structural
{
    [TestFixture]
    public class MapperShould
    {
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            new IntegrationWebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddAutoMapper();
                        _mapper = services.BuildServiceProvider().GetService<IMapper>();
                    });
                }).CreateClient();
        }

        [Test]
        public void ConvertDummyInsertDtoToDummy()
        {
            var insertDto = new DummyInsertDto()
            {
                Name = "Tarik"
            };

            var model = _mapper.Map<Dummy>(insertDto);

            model.Should().NotBeNull();
            model.Name.Should().Be("Tarik");
            model.Status.Should().Be("Started");
        }
    }
}
