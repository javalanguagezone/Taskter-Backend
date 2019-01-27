using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Taskter.Core.Entities;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class ProjectTaskEntryEntityShould
    {
        ProjectTaskEntry _entry = new ProjectTaskEntry(1, 1, 20, DateTime.Now, "Notee");


        [Test]
        public void NotAcceptsNegativeDurationInMinOnSetting()
        {
            Action act = () => _entry.SetDuratinInMin(-1);
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");

        }
        [Test]
        public void NotAcceptsNegativeDurationInMinOnCreating()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(1, 1, -1, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");
        }
        [Test]
        public void NotAcceptsZeroDurationInMinOnSetting()
        {
            Action act = () => _entry.SetDuratinInMin(0);
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");

        }

        [Test]
        public void NotAcceptsZeroDurationInMinOnCreating()
        {
            ProjectTaskEntry _entry1; 

            Action act = () => _entry1 = new ProjectTaskEntry(1, 1, 0, DateTime.Now, "Notee"); 
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");

        }
        [Test]
        public void NotAcceptsOverOneDayDurationInMinOnCreating()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(1, 1, 2000, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void NotAcceptsOverOneDayDurationInMinOnSetting()
        {
            Action act = () => _entry.SetDuratinInMin(2000);
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void NotAcceptsNullParametersForUserIdOnCreating()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(0,1, 20, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void NotAcceptsNegativeParametersForUserIdOnCreating()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(-1, 1, 20, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void NotAcceptsNegativeParametersForUserIdOnSetting()
        {
            Action act = () => _entry.SetUserId(-1);
            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }
        [Test]
        public void NotAcceptsZeroIdForProjectTaskIdOnCreating()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(1, 0, 20, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }

        [Test]
        public void NotAcceptsNegativeParametersForPprojectTaskIdOnSetting()
        {
            Action act = () => _entry.SetProjectTaskId(-1);
            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");

        }
    }
}
