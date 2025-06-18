public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }

    protected Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();

    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split(',');
        switch (parts[0])
        {
            case "Simple": return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "Eternal":
                if (parts.Length >= 5)
                    return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
                else
                    return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "Checklist": return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
        }
        return null;
    }
}
