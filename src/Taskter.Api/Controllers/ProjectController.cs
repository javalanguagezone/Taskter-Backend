using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskter.Core.Interfaces;

namespace Taskter.Api.Controllers
{
    public class ProjectController: ControllerBase
    {
        private readonly IProjectRepository _repository;
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }
    }
}
