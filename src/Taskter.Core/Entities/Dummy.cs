using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class Dummy : BaseEntity
    {
        public string Name { get; set; }
        public string Status { get; private set; }

        public Dummy(string name)
        {
            Name = name;
            Status = "Started";
        }

        public void SetToBlocked()
        {
            Status = "Blocked";
        }
    }
}