namespace Taskter.Core.Entities {
    public class UserProject {
        public int UserId { get; private set; }

        public User User { get; set; }

        public int ProjectId { get; private set; }
        public Project Project { get; set; }

        private UserProject()
        {
            
        }
        public UserProject (int userId, int projectId)
        {
            UserId = userId;
            ProjectId = projectId;
        }
    }

}