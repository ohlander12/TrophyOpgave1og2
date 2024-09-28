public class Trophy
{
    public int Id { get; set; }
    public string? Competition { get; set; }
    public int Year { get; set; }

    // Copy constructor
    public Trophy(Trophy trophy)
    {
        Id = trophy.Id;
        Competition = trophy.Competition;
        Year = trophy.Year;
    }

    // Standard constructor
    public Trophy() { }

    public void ValidateCompetition()
    {
        if (Competition == null)
        {
            throw new ArgumentNullException("Competition must not be null");
        }

        if (Competition.Length < 3)
        {
            throw new ArgumentException("Competition name must be at least 3 characters long");
        }
    }

    public void ValidateYear()
    {
        if (Year < 1970 || Year > 2024)
        {
            throw new ArgumentException("Year must be between 1970 and 2024");
        }
    }

    public override string ToString()
    {
        return $"Trophy Id: {Id}, Competition: {Competition}, Year: {Year}";
    }
}
