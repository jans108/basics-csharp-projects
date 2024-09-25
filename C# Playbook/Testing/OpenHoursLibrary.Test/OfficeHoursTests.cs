using System;
using NUnit.Framework;
using OpenHoursLibrary.Test;

namespace Pluralsight.CShPlaybook.OpenHoursLibrary.Test;
public class OfficeHoursTests
{
	[Test]
	public void GetTotalOpenHoursToday_IsCorrect()
	{
		// arrange
		TimeSpan expectedAnswer = new TimeSpan(8, 0, 0);
		var repository = new HoursRepository_TestDouble();
		OfficeHours sut = new OfficeHours(repository);

		// act
		TimeSpan totalHoursOpen = sut.GetTotalOpenHoursToday();

		// assert
		Assert.That(totalHoursOpen, Is.EqualTo(expectedAnswer));
	}

	[Test]
	public void GetTimeUntilNextOpen_IsCorrect()
	{
		// arrange
		TimeSpan expectedAnswer = new TimeSpan(1, 30, 0);
		HoursRepository_TestDouble repository = new();
		OfficeHours officeHours = new OfficeHours(repository);
		TimeNowProvider_TestDouble timeNowProvider = new(new TimeOnly(7, 0));

		// act 
		TimeSpan howLongUntilOpen = officeHours.GetTimeUntilNextOpen(timeNowProvider);

		// assert
		Assert.That(howLongUntilOpen, Is.EqualTo(expectedAnswer));
	}
} 
