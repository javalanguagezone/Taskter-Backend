using AutoMapper;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;

namespace Taskter.Api.Mappings
{
    public class DummyObjectsProfile : Profile
    {
        public DummyObjectsProfile()
        {
            CreateMap<DummyInsertDto, Dummy>();
        }
    }
}