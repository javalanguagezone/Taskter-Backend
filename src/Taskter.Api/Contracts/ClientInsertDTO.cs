using System.ComponentModel.DataAnnotations;

namespace Taskter.Api.Contracts
{
    public class ClientInsertDTO
    {
       
        public int ClientId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}