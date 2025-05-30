using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var video1 = new Video("Learn C#", "CodeMaster", 300);
        var video2 = new Video("Amazing Nature", "TravelPro", 480);
        var video3 = new Video("Guitar Solos", "MusicWorld", 600);

        video1.AddComment(new Comment("Alice", "This is super helpful!"));
        video1.AddComment(new Comment("Bob", "Very well explained."));
        video1.AddComment(new Comment("Carol", "Loved it!"));

        video2.AddComment(new Comment("Dave", "Stunning views!"));
        video2.AddComment(new Comment("Eva", "Makes me want to travel!"));
        video2.AddComment(new Comment("Frank", "Incredible footage."));

        video3.AddComment(new Comment("Grace", "Wow, those solos are amazing!"));
        video3.AddComment(new Comment("Hank", "Pure talent."));
        video3.AddComment(new Comment("Ivy", "I listen to this on repeat."));

        var videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine(video.GetDisplayText());
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine("- " + comment.GetDisplayText());
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
