using NUnit.Framework;
using System;
using Taskter.Core.Entities;
using FluentAssertions;

namespace Taskter.Tests.Core
{
    [TestFixture]
    public class ProjectTaskEntryEntityTests
    {
        ProjectTaskEntry _entry = new ProjectTaskEntry(Guid.NewGuid(), 1, 20, DateTime.Now, "Notee");


        [TestCase(0)]
        [TestCase(-1)]
        public void DurationInMinSetter_NegativeOrZeroValue_ThrowArgumentException(int durationInMin)
        {
            Action act = () => _entry.DurationInMin = durationInMin;
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");

        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_NegativeOrZeroDurationInMin_ThrowArgumentException(int durationInMin)
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(Guid.NewGuid(), 1, durationInMin, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>().WithMessage("Duration can not be <=0!");
        }

        [Test]
        public void Constructor_OverOneDayDurationInMin_ThrowArgumentException()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(Guid.NewGuid(), 1, 2000, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void DurationInMinSetter_OverOneDayMinutes_ThrowArgumentException()
        {
            Action act = () => _entry.DurationInMin = 2000;
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Constructor_NegativeOrZeroUserId_ThrowArgumentException()
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(Guid.Empty, 1, 20, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>();
        }

        [TestCase(-10)]
        [TestCase(0)]
        public void Constructor_ZeroOrNegativeProjectTaskId_ThrowArgumentException(int projectTaksId)
        {
            ProjectTaskEntry _entry1;

            Action act = () => _entry1 = new ProjectTaskEntry(Guid.NewGuid() , projectTaksId, 20, DateTime.Now, "Notee");
            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");
        }
        [TestCase(-10)]
        [TestCase(0)]
        public void ProjectTaskSetter_NegativeOrZeroValue_ThrowArgumentException(int projectTaskId)
        {
            Action act = () => _entry.ProjectTaskId = projectTaskId;
            act.Should().Throw<ArgumentException>().WithMessage("Id field can not be set to negative value or zero!");

        }
    }
}
