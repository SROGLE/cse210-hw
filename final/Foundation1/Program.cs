using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create video 1
        Video video1 = new Video("Learning C# Basics", "Tech Academy", 300);
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Mike", "Clear explanations"));
        videos.Add(video1);

        // Create video 2
        Video video2 = new Video("Cooking Pasta", "Chef Mario", 600);
        video2.AddComment(new Comment("Lisa", "Looks delicious!"));
        video2.AddComment(new Comment("Tom", "I tried this recipe, amazing!"));
        video2.AddComment(new Comment("Emma", "What type of pasta do you recommend?"));
        video2.AddComment(new Comment("David", "Best cooking channel!"));
        videos.Add(video2);

        // Create video 3
        Video video3 = new Video("Guitar Tutorial for Beginners", "Music Master", 900);
        video3.AddComment(new Comment("Alex", "Finally learning guitar!"));
        video3.AddComment(new Comment("Grace", "Easy to follow"));
        video3.AddComment(new Comment("Ryan", "More videos please!"));
        videos.Add(video3);

        // Display all videos
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}