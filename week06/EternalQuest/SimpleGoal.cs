public class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, string description, int points, bool complete = false)
        : base(name, description, points)
    {
        isComplete = complete;
    }

    public override int RecordEvent()
    {
        if (!isComplete)
        {
            isComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        string checkbox = isComplete ? "X" : " ";
        return $"[{checkbox}] {Name} ({Description})";
    }

    public override string Serialize() => $"Simple,{Name},{Description},{Points},{isComplete}";
}