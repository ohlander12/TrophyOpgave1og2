using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TrophyTests
{
    [TestMethod]
    public void ValidateCompetitionTest()
    {
        // Konkurrencenavn er for kort
        Trophy tooShortCompetition = new Trophy
        {
            Id = 1,
            Competition = "No",
            Year = 1990
        };
        Assert.ThrowsException<ArgumentException>(() => tooShortCompetition.ValidateCompetition());

        // Konkurrencenavn er null
        Trophy nullCompetition = new Trophy
        {
            Id = 2,
            Competition = null,
            Year = 1990
        };
        Assert.ThrowsException<ArgumentNullException>(() => nullCompetition.ValidateCompetition());

        // Gyldigt konkurrencenavn
        Trophy validCompetition = new Trophy
        {
            Id = 3,
            Competition = "Swimming",
            Year = 1995
        };
        validCompetition.ValidateCompetition();  // Skal ikke kaste nogen undtagelse
    }

    [TestMethod]
    public void ValidateYearTest()
    {
        // Årstal er for tidligt
        Trophy yearTooEarly = new Trophy
        {
            Id = 4,
            Competition = "Swimming",
            Year = 1969
        };
        Assert.ThrowsException<ArgumentException>(() => yearTooEarly.ValidateYear());

        // Årstal er for sent
        Trophy yearTooLate = new Trophy
        {
            Id = 5,
            Competition = "Swimming",
            Year = 2025
        };
        Assert.ThrowsException<ArgumentException>(() => yearTooLate.ValidateYear());

        // Gyldigt årstal
        Trophy validYear = new Trophy
        {
            Id = 6,
            Competition = "Swimming",
            Year = 2000
        };
        validYear.ValidateYear();  // Skal ikke kaste nogen undtagelse
    }

    [TestMethod]
    public void ValidateToStringTest()
    {
        // Gyldigt ToString
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
