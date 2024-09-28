using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TrophyTests
{
    // Test method for validating competition
    [TestMethod]
    public void ValidateCompetitionTest()
    {
        // Case where competition name is too short
        Trophy tooShortCompetition = new Trophy
        {
            Id = 1,
            Competition = "AB",
            Year = 1990
        };
        Assert.ThrowsException<ArgumentException>(() => tooShortCompetition.ValidateCompetition());

        // Case where competition name is null
        Trophy nullCompetition = new Trophy
        {
            Id = 2,
            Competition = null,
            Year = 1990
        };
        Assert.ThrowsException<ArgumentNullException>(() => nullCompetition.ValidateCompetition());

        // Case where competition name is valid
        Trophy validCompetition = new Trophy
        {
            Id = 3,
            Competition = "Swimming",
            Year = 1995
        };
        validCompetition.ValidateCompetition();  // This should not throw any exception
    }

    // Test method for validating year
    [TestMethod]
    public void ValidateYearTest()
    {
        // Case where year is too early
        Trophy yearTooEarly = new Trophy
        {
            Id = 4,
            Competition = "Swimming",
            Year = 1969
        };
        Assert.ThrowsException<ArgumentException>(() => yearTooEarly.ValidateYear());

        // Case where year is too late
        Trophy yearTooLate = new Trophy
        {
            Id = 5,
            Competition = "Swimming",
            Year = 2025
        };
        Assert.ThrowsException<ArgumentException>(() => yearTooLate.ValidateYear());

        // Case where year is valid
        Trophy validYear = new Trophy
        {
            Id = 6,
            Competition = "Swimming",
            Year = 2000
        };
        validYear.ValidateYear();  // This should not throw any exception
    }

    // Test method for ToString
    [TestMethod]
    public void ValidateToStringTest()
    {
        // Valid case for ToString
        Trophy trophy = new Trophy
        {
            Id = 10,
            Competition = "Rowing",
            Year = 2002
        };

        string expectedString = "Trophy Id: 10, Competition: Rowing, Year: 2002";
        Assert.AreEqual(expectedString, trophy.ToString());
    }
}
