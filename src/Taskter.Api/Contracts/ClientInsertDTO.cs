using System.ComponentModel.DataAnnotations;

namespace Taskter.Api.Contracts
{
    public class ClientInsertDTO
    {  
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}