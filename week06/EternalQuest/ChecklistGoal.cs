public class ChecklistGoal : Goal
{
    private int count;
    private int target;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int count = 0)
        : base(name, description, points)
    {
        this.target = target;
        this.bonus = bonus;
        this.count = count;
    }

    public override int RecordEvent()
    {
        count++;
        int earned = Points;
        if (count == target)
        {
            earned += bonus;
        }
        return earned;
    }

    public override string GetStatus()
    {
        string checkbox = (count >= target) ? "X" : " ";
        return $"[{checkbox}] {Name} ({Description}) -- Currently completed: {count}/{target}";
    }

    public override string Serialize() => $"Checklist,{Name},{Description},{Points},{target},{bonus},{count}";
}
