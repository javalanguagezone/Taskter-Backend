using System; 

namespace Taskter.Core.Entities {
    public class UserProject {

        private Guid _userId;
        public Guid UserId 
        { 
            get => _userId; 
            private set
            {
                ValidateId(value);
                _userId = value;
            } 
        }
        
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

        private void ValidateId(Guid id){
            if (id == default(Guid))
            {
                throw new ArgumentException("Id field can not be set to negative value or zero!");
            }
        }

        private void ValidateId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id field can not be set to negative value or zero!");
            }
        }

        private UserProject()
        {
            
        }
        public UserProject (Guid userId, int projectId)
        {
            UserId = userId;
            ProjectId = projectId;
        }
    }

}