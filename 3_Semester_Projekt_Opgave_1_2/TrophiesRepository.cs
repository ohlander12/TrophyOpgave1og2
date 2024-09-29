using System;
using System.Collections.Generic;
using System.Linq;

public class TrophiesRepository
{
    private List<Trophy> trophies;

    public TrophiesRepository()
    {
        trophies = new List<Trophy>
        {
            new Trophy { Id = 1, Competition = "Rowing", Year = 2001 },
            new Trophy { Id = 2, Competition = "Basketball", Year = 2010 },
            new Trophy { Id = 3, Competition = "Football", Year = 1998 },
            new Trophy { Id = 4, Competition = "Tennis", Year = 2020 },
            new Trophy { Id = 5, Competition = "Swimming", Year = 2015 }
        };
    }

    public List<Trophy> Get(int? year = null, string? sortBy = null)
    {
        var copyList = trophies.Select(t => new Trophy(t)).ToList();

        if (year.HasValue)
        {
            copyList = copyList.Where(t => t.Year == year.Value).ToList();
        }

        if (sortBy != null)
        {
            if (sortBy.Equals("Competition", StringComparison.OrdinalIgnoreCase))
            {
                copyList = copyList.OrderBy(t => t.Competition).ToList();
            }
            else if (sortBy.Equals("Year", StringComparison.OrdinalIgnoreCase))
            {
                copyList = copyList.OrderBy(t => t.Year).ToList();
            }
        }

        return copyList;
    }

    public Trophy? GetById(int id)
    {
        return trophies.FirstOrDefault(t => t.Id == id);
    }

    public Trophy Add(Trophy trophy)
    {
        int newId = trophies.Max(t => t.Id) + 1;
        trophy.Id = newId;
        trophies.Add(trophy);
        return trophy;
    }

    public Trophy? Remove(int id)
    {
        Trophy? trophyToRemove = trophies.FirstOrDefault(t => t.Id == id);
        if (trophyToRemove != null)
        {
            trophies.Remove(trophyToRemove);
        }
        return trophyToRemove;
    }

    public Trophy? Update(int id, Trophy values)
    {
        Trophy? trophyToUpdate = trophies.FirstOrDefault(t => t.Id == id);
        if (trophyToUpdate != null)
        {
            trophyToUpdate.Competition = values.Competition;
            trophyToUpdate.Year = values.Year;
        }
        return trophyToUpdate;
    }
}
