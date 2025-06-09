class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        SetActivityInfo("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    protected override void PerformActivity()
    {
        int totalTime = GetDuration();
        int cycle = 6;
        while (totalTime > 0)
        {
            Console.Write("\nBreathe in... ");
            Countdown(3);
            Console.Write("Now breathe out... ");
            Countdown(3);
            totalTime -= cycle;
        }
    }
}
