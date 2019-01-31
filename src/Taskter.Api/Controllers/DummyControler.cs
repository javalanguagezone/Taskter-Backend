using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Taskter.Api.Contracts;
using Taskter.Core.Entities;
using Taskter.Core.Interfaces;

namespace Taskter.Api.Controllers
{
    [Route("api/dummies")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly IDummyRepository _repository;
        private readonly IMapper _mapper;

        public DummyController(IDummyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dummy>> Get()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Dummy> Get(int id)
        {
            var result = _repository.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Add(DummyInsertDto dummy)
        {
            _repository.AddDummy(_mapper.Map<Dummy>(dummy));
            return NoContent();
        }

        [HttpPut("{id}/blocked")]
        public ActionResult MoveToBlocked(int id)
        {
            var dummy = _repository.GetById(id);

            if (dummy == null)
            {
                return NotFound();
            }

            dummy.SetToBlocked();
            _repository.UpdateDummy(dummy);

            return NoContent();
        }
    }
}