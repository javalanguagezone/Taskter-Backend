using System.ComponentModel.DataAnnotations;

namespace Taskter.Api.Contracts
{
    public class DummyInsertDto
    {
        [Required]
        public string Name { get; set; }
    }
}