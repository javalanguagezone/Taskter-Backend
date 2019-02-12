namespace Taskter.Api.Contracts
{
    public class ProjectTaskInsertDTO
    {
        public int taskId { get; set; }
        public string name { get; set; }
        public bool billable { get; set; }
    }
}