using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Video> videos = new List<Video>();

        Video v1 = new Video("DIY Desert Succulent Terrarium", "Andrea Muñoz", 420);
        v1.AddComment(new Comment("Carla", "I love how simple this looks!"));
        v1.AddComment(new Comment("Luis", "Now I want to make one for my patio."));
        v1.AddComment(new Comment("Martha", "Great step-by-step explanation."));
        videos.Add(v1);

        Video v2 = new Video("Intro to Semiconductor Policy", "TechChihuahuense", 600);
        v2.AddComment(new Comment("Diego", "Super clear for beginners."));
        v2.AddComment(new Comment("Ana", "I finally understand CHIPS Act basics!"));
        v2.AddComment(new Comment("Rosa", "Can you cover EU policy next time?"));
        videos.Add(v2);

        Video v3 = new Video("Library Hacks for Teens", "Academia Juárez Library", 300);
        v3.AddComment(new Comment("Emilia", "The bookmark tip is genius!"));
        v3.AddComment(new Comment("Oscar", "Loved the book tracker idea."));
        v3.AddComment(new Comment("Paola", "Can you share the Canva template?"));
        videos.Add(v3);

        foreach (Video vid in videos)
        {
            vid.DisplayVideoInfo();
        }

    }
}
