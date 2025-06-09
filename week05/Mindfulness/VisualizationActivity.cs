using System;
using System.Collections.Generic;

class VisualizationActivity : Activity
{
    private List<string> _visualSteps = new List<string>
    {
        "Imagine you’re walking through a quiet forest.",
        "You hear the birds gently chirping.",
        "A light breeze brushes across your face.",
        "You sit by a calm river and breathe deeply.",
        "The sunlight filters softly through the trees.",
        "You feel at peace and grounded."
    };

    public VisualizationActivity()
    {
        SetActivityInfo("Visualization Activity", "This activity will help you visualize a peaceful and calming place. It’s designed to help you mentally escape to a relaxing environment and reduce stress.");
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        int timeLeft = GetDuration();

        while (timeLeft > 4)
        {
            string step = _visualSteps[rand.Next(_visualSteps.Count)];
            Console.WriteLine("\n" + step);
            ShowSpinner(4);
            timeLeft -= 4;
        }
    }
}