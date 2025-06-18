public class EternalGoal : Goal
{
    private int count = 0;

    public EternalGoal(string name, string description, int points, int count = 0)
        : base(name, description, points)
    {
        this.count = count;
    }

    public override int RecordEvent()
    {
        count++;
        return Points;
    }

    public override string GetStatus()
    {
        string checkbox = (count > 0) ? "X" : " ";
        return $"[{checkbox}] {Name} ({Description}) - Completed {count} time(s)";
    }

    public override string Serialize() => $"Eternal,{Name},{Description},{Points},{count}";
}


