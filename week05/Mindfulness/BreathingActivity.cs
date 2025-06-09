using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        SetActivityInfo("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            Countdown(3);
            Console.Write("Now breathe out... ");
            Countdown(3);
        }
    }
}
