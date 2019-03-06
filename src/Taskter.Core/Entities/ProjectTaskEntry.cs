using System;
using Taskter.Core.SharedKernel;


namespace Taskter.Core.Entities
{
    public class ProjectTaskEntry : BaseEntity
    {
        private int _projectTaskId;
        public int ProjectTaskId
        {
            get => _projectTaskId;
            set {
                ValidateId(value);
                _projectTaskId = value;
            }
        }
        public ProjectTask ProjectTask { get; set; }

        private Guid _userId;
        public Guid UserId
        {
            get => _userId;
            private set {
                ValidateId(value);
                _userId = value;
            }
        }

        private int _durationInMin;
        public int DurationInMin
        {
            get => _durationInMin;
            set {
                ValidateDurationInMinutes(value);
                _durationInMin = value;
            }
        }
        public DateTime Date { get; set; }
        public string Note { get; set; }

        private void ValidateDurationInMinutes(int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException("Duration can not be <=0!");
            }
            if (duration > 1440)
            {
                throw new ArgumentException("Duration can not be > 1440!");

            }
        }
        private void ValidateId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id field can not be set to negative value or zero!");
            }
        }
        private void ValidateId(Guid id)
        {
            if (id == default(Guid))
            {
                throw new ArgumentException("Id field can not be set to negative value or zero!");
            }
        }

        public ProjectTaskEntry(int id, Guid userId, int projectTaskId, int durationInMin, DateTime date, string note)
        {
            Id = id;
            UserId = userId;
            ProjectTaskId = projectTaskId;
            DurationInMin = durationInMin;
            Date = date;
            Note = note;
        }

        public ProjectTaskEntry(Guid userId, int projectTaskId, int durationInMin, DateTime date, string note)
        {
            UserId = userId;
            ProjectTaskId = projectTaskId;
            DurationInMin = durationInMin;
            Date = date;
            Note = note;
        }
        private ProjectTaskEntry()
        {

        }
    }
}
