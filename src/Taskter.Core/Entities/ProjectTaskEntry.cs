using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.SharedKernel;


namespace Taskter.Core.Entities
{
    public class ProjectTaskEntry : BaseEntity
    {
        public int ProjectTaskId { get; private set; }
        public ProjectTask ProjectTask { get; set; }
        public int UserId { get; private set; }
        public User User { get; set; }
        public int DurationInMin { get;  private set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }

        public void SetDuratinInMin(int duration)
        {
            ValidateDurationInMinutes(duration);
            this.DurationInMin = duration;
        }
        public void SetProjectTaskId(int id){
            ValidateId(id);
            this.UserId = id;
        }
        private void ValidateDurationInMinutes(int duration)
        {
            if (duration <= 0  )
            {
                throw new ArgumentException("Duration can not be <=0!");
            }
            if (duration > 1440)
            {
                throw new ArgumentException("Duration can not be > 1440!");

            }
        }
        private void ValidateId( int id){
            if (id <= 0 )
            {
                throw new ArgumentException("Id field can not be set to negative value or zero!");
            }
        }

        public ProjectTaskEntry( int id, int userId,  int projectTaskId, int durationInMin, DateTime date, string note)
        {
            ValidateDurationInMinutes(durationInMin);
            ValidateId(userId);
            ValidateId(projectTaskId);

            this.Id = id;
            this.UserId = userId;
            this.ProjectTaskId = projectTaskId;
            this.DurationInMin = durationInMin;
            this.Date = date;
            this.Note = note;
        }

        public ProjectTaskEntry( int userId, int projectTaskId, int durationInMin, DateTime date, string note)
        {
            ValidateDurationInMinutes(durationInMin);
            ValidateId(userId);
            ValidateId(projectTaskId);
            
            this.UserId = userId;
            this.ProjectTaskId = projectTaskId;
            this.DurationInMin = durationInMin;
            this.Date = date;
            this.Note = note;
        }
        private ProjectTaskEntry()
        {

        }
    }
}
