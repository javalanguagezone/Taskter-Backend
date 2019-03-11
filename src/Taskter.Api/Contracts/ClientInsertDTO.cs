using System.ComponentModel.DataAnnotations;

namespace Taskter.Api.Contracts
{
    public class ClientInsertDTO
    {  
        public int Id { get; set; }
        public string Name { get; set; }
    }
}