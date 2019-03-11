using System; 

namespace Taskter.Core.Entities {
    public class UserProject {

        private int _userId;
        public int UserId 
        { 
            get => _userId; 
            private set
            {
                ValidateId(value);
                _userId = value;
            } 
        }
        public User User { get; set; }
        private int _projectId;
        public int ProjectId 
        { 
            get => _projectId; 
            private set
            {
                ValidateId(value);
                _projectId = value;
            } 
        }
        public Project Project { get; set; }
        public bool Active { get; set; } = true;
        private void ValidateId(int id){
            if (id <= 0 )
            {
                throw new ArgumentException("Id field can not be set to negative value or zero!");
            }
        }
        private UserProject()
        {
        
        }
        public UserProject (int userId, int projectId)
        {
            UserId = userId;
            ProjectId = projectId;
        }
        public void EditStatus(bool active)
        {
            Active = active;
        }
    }

}