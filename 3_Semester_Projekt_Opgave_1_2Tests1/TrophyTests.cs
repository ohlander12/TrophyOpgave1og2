using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TrophyTests
{
    [TestMethod]
    public void ValidateCompetitionTest()
    {
        
        Trophy tooShortCompetition = new Trophy
        {
            Id = 1,
            Competition = "No",
            Year = 1990
        };
        Assert.ThrowsException<ArgumentException>(() => tooShortCompetition.ValidateCompetition());

        
        Trophy nullCompetition = new Trophy
        {
            Id = 2,
            Competition = null,
            Year = 1990
        };
        Assert.ThrowsException<ArgumentNullException>(() => nullCompetition.ValidateCompetition());

        
        Trophy validCompetition = new Trophy
        {
            Id = 3,
            Competition = "Swimming",
            Year = 1995
        };
        validCompetition.ValidateCompetition();
    }

    [TestMethod]
    public void ValidateYearTest()
    {
        
        Trophy yearTooEarly = new Trophy
        {
            Id = 4,
            Competition = "Swimming",
            Year = 1969
        };
        Assert.ThrowsException<ArgumentException>(() => yearTooEarly.ValidateYear());

        
        Trophy yearTooLate = new Trophy
        {
            Id = 5,
            Competition = "Swimming",
            Year = 2025
        };
        Assert.ThrowsException<ArgumentException>(() => yearTooLate.ValidateYear());

        
        Trophy validYear = new Trophy
        {
            Id = 6,
            Competition = "Swimming",
            Year = 2000
        };
        validYear.ValidateYear(); 
    }

    [TestMethod]
    public void ValidateToStringTest()
    {
       
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
