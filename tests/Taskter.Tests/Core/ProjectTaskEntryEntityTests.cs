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
    public class ProjectTaskEntryEntityTests
    {
        ProjectTaskEntry _entry = new ProjectTaskEntry(1, 1, 20, DateTime.Now, "Notee");


        [Test]
        public void DurationInMinSetter_NegativeValue_ThrowArgumentException()
        {
            Action act = () => _entry.DurationInMin = -1;
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");

        }
        [Test]
        public void Constructor_NegativeDurationInMin_ThrowArgumentException()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(1, 1, -1, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");
        }
        [Test]
        public void DurationInMinSetter_ZeroValue_ThrowArgumentException()
        {
            Action act = () => _entry.DurationInMin = 0;
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");

        }

        [Test]
        public void Constructor_ZeroDurationInMin_ThrowArgumentException()
        {
            ProjectTaskEntry _entry1; 

            Action act = () => _entry1 = new ProjectTaskEntry(1, 1, 0, DateTime.Now, "Notee"); 
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");

        }
        [Test]
        public void Constructor_OverOneDayDurationInMin_ThrowArgumentException()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(1, 1, 2000, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void DurationInMinSetter_OverOneDayMinutes_ThrowArgumentException()
        {
            Action act = () => _entry.DurationInMin = 2000;
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Constructor_ZeroUserId_ThrowArgumentException()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(0,1, 20, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Constructor_NegativeUserId_ThrowArgumentException()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(-1, 1, 20, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Constructor_ZeroProjectTaskId_ThrowArgumentException()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(1, 0, 20, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }
        [Test]
        public void ProjectTaskSetter_NegativeValue_ThrowArgumentException()
        {
            Action act = () => _entry.ProjectTaskId = -1;
            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");

        }
    }
}
