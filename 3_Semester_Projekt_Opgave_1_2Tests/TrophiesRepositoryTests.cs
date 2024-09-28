using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RepoTests
{
    // Tester om Get() returnerer en kopi af listen
    [TestMethod]
    public void Get_ReturnsCopy()
    {
        var repo = new TrophiesRepository();
        var trophies = repo.Get();

        trophies[0].Competition = "Modified"; // Ændrer kopien

        var originalTrophies = repo.Get(); // Henter originalen igen

        Assert.AreNotEqual("Modified", originalTrophies[0].Competition); // Bekræfter at originalen ikke er ændret
    }
    // Tester Get() med filter på år
    [TestMethod]
    public void Get_YearFilter()
    {
        var repo = new TrophiesRepository();
        var result = repo.Get(year: 2010);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Basketball", result[0].Competition);
    }

    // Tester Get() med sortering efter konkurrence
    [TestMethod]
    public void Get_SortedByComp()
    {
        var repo = new TrophiesRepository();
        var result = repo.Get(sortBy: "Competition");
        Assert.AreEqual("Basketball", result[0].Competition);
        Assert.AreEqual("Football", result[1].Competition);
    }

    // Tester Add() ved at tilføje et nyt trofæ
    [TestMethod]
    public void Add_Trophy()
    {
        var repo = new TrophiesRepository();
        var newTrophy = new Trophy { Competition = "Hockey", Year = 2021 };
        var added = repo.Add(newTrophy);

        Assert.AreEqual(6, added.Id); // Id skal være 6, da der allerede er 5 trofæer
        Assert.AreEqual("Hockey", added.Competition);
    }

    // Tester Remove() ved at fjerne et trofæ
    [TestMethod]
    public void Remove_Trophy()
    {
        var repo = new TrophiesRepository();
        var removed = repo.Remove(3);
        Assert.IsNotNull(removed);
        Assert.AreEqual("Football", removed.Competition);

        var result = repo.Remove(3);
        Assert.IsNull(result); // Trofæet er allerede fjernet, så resultatet skal være null
    }

    // Tester Update() ved at opdatere et trofæ
    [TestMethod]
    public void Update_Trophy()
    {
        var repo = new TrophiesRepository();
        var updatedValues = new Trophy { Competition = "New Comp", Year = 2015 };
        var updated = repo.Update(2, updatedValues);

        Assert.IsNotNull(updated);
        Assert.AreEqual("New Comp", updated.Competition);
        Assert.AreEqual(2015, updated.Year);
    }


}
