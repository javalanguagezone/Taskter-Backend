using System.ComponentModel.DataAnnotations;

namespace Taskter.Api.Contracts
{
    public class ClientInsertDTO
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}