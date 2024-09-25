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
}
