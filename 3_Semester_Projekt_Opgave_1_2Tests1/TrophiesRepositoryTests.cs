using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RepoTests
{
    [TestMethod]
    public void Get_ReturnsCopy()
    {
        var repo = new TrophiesRepository();
        var trophies = repo.Get();
        trophies[0].Competition = "Modified";
        var originalTrophies = repo.Get();
        Assert.AreNotEqual("Modified", originalTrophies[0].Competition);
    }

    [TestMethod]
    public void Get_YearFilter()
    {
        var repo = new TrophiesRepository();
        var result = repo.Get(year: 2010);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Basketball", result[0].Competition);
    }

    [TestMethod]
    public void Get_SortedByComp()
    {
        var repo = new TrophiesRepository();
        var result = repo.Get(sortBy: "Competition");
        Assert.AreEqual("Basketball", result[0].Competition);
        Assert.AreEqual("Football", result[1].Competition);
    }

    [TestMethod]
    public void Add_Trophy()
    {
        var repo = new TrophiesRepository();
        var newTrophy = new Trophy { Competition = "Hockey", Year = 2021 };
        var added = repo.Add(newTrophy);

        Assert.AreEqual(6, added.Id);
        Assert.AreEqual("Hockey", added.Competition);
    }

    [TestMethod]
    public void Remove_Trophy()
    {
        var repo = new TrophiesRepository();
        var removed = repo.Remove(3);
        Assert.IsNotNull(removed);
        Assert.AreEqual("Football", removed.Competition);

        var result = repo.Remove(3);
        Assert.IsNull(result);
    }

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
