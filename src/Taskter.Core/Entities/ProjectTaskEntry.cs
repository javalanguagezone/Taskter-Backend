using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.SharedKernel;

namespace Taskter.Core.Entities
{
    public class ProjectTaskEntry : BaseEntity
    {


        public int ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int DurationInMin { get;  private set; }
        
        public DateTime Date { get; set; }

        public string Note { get; set; }



        public void SetDuratinInMin(int duration)
        {
            if (duration <= 0 )
            {
                throw new ArgumentException("Duration can not be <=0!");
            }
            if (duration > 1440)
            {
                throw new ArgumentException("Duration can not be > 1440!");

            }
            this.DurationInMin = duration;
        }
        private ProjectTaskEntry()
        {

        }

        private void ValidateParameters( int userId, int projectTaskId, int durationInMin, DateTime date)
        {
            if (durationInMin <= 0  )
            {
                throw new ArgumentException("Duration can not be <= 0!");
            }
            if (durationInMin > 1440)
            {
                throw new ArgumentException("Duration can not be > 1440!");

            }
            if (userId <= 0 )
            {
                throw new ArgumentException("User can not be null or negative! ");
            }
            if (projectTaskId <= 0)
            {
                throw new ArgumentException("Project task can not be null or negative! ");
            }
            if (date == null )
            {
                throw new ArgumentException("Date can not be null!");
            }
        }
        public ProjectTaskEntry( int id, int UserId,  int ProjectTaskId, int DurationInMin, DateTime date, string Note)
        {

            ValidateParameters(UserId, ProjectTaskId, DurationInMin, date);

            this.Id = Id;
            this.UserId = UserId;
            
            this.ProjectTaskId = ProjectTaskId;
            
            this.DurationInMin = DurationInMin;
            this.Date = date;
            this.Note = Note;
        }

        public ProjectTaskEntry( int UserId, int ProjectTaskId, int DurationInMin, DateTime date, string Note)
        {

            ValidateParameters(UserId, ProjectTaskId, DurationInMin, date);

            
            this.UserId = UserId;

            this.ProjectTaskId = ProjectTaskId;

            this.DurationInMin = DurationInMin;
            this.Date = date;
            this.Note = Note;
        }


    }
}
