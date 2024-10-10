//LA 5.2 (2):
//Second one:

using System;
using System.Collections.Generic;
using System.Linq;

public class Video
{
    public string Name { get; set; }
    public int Id { get; private set; }

    public bool IsRented { get; set; }
    public string Genre { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime? RentedDate { get; set; }
    public string RentedBy { get; set; }

    private static int _idCounter = 1;

    public Video(string name, string genre, TimeSpan duration)
    {
        Name = name;
        Genre = genre;
        Duration = duration;
        Id = _idCounter++;
        IsRented = false;
        RentedDate = null;
        RentedBy = null;
    }

    public void Rent(string customerName)
    {
        if (!IsRented)
        {
            IsRented = true;
            RentedBy = customerName;
            RentedDate = DateTime.Now;
            Console.WriteLine($"{Name} has been Rented by {RentedBy}");
        }
        else
        {
            Console.WriteLine($"{Name} is already Rented");
        }
    }

    public void Return()
    {
        if (IsRented)
        {
            IsRented = false;
            RentedBy = null;
            RentedDate = null;

            Console.WriteLine($"{Name} has been Returned");
        }
        else
        {
            Console.WriteLine($"{Name} was not Returned");
        }


    }


}

class VideoStore
{
    private List<Video> videos = new List<Video>();
    public void AddVideo(string name, string genre, TimeSpan duration)
    {
        Video video = new Video(name, genre, duration);
        videos.Add(video);
        Console.WriteLine($"{name} has been added to the store.");
    }
    public void RentVideo(int videoId, string customerName)
    {
        Video video = videos.FirstOrDefault(v => v.Id == videoId);
        if (video != null)
        {
            video.Rent(customerName);
        }
        else
        {
            Console.WriteLine("Video not found.");
        }
    }
    public void ReturnVideo(int videoId)
    {
        Video video = videos.FirstOrDefault(v => v.Id == videoId);
        if (video != null)
        {
            video.Return();
        }
        else
        {
            Console.WriteLine("Video not found.");
        }
    }

    public void SearchVideos(string searchTerm)
    {
        var result = videos.Where(v => v.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        if (result.Any())
        {
            Console.WriteLine("Search results.");
            foreach (var video in result)
            {
                string yesNoStr = "No";

                if (video.IsRented)
                {
                    yesNoStr = "Yes";
                }

                Console.WriteLine($"\tID: {video.Id}, Name: {video.Name}, Genre: {video.Genre}, " +
                    $"\n\tDuration: {video.Duration}, Rented: {yesNoStr}");
            }
        }
        else
        {
            Console.WriteLine("No videos found");
        }
    }

    public void ListAllVideos()
    {
        Console.WriteLine("All Videos in the store:");
        foreach (var video in videos)
        {
            string yesNoStr = "No";

            if (video.IsRented)
            {
                yesNoStr = "Yes";
            }

            Console.WriteLine($"\tID: {video.Id}, Name: {video.Name}, Genre: {video.Genre}, " +
                   $"\n\tDuration: {video.Duration}, Rented: {yesNoStr}");
        }
    }


}

/*class Program
{
    static void Main(string[] args)
    {
        VideoStore store = new VideoStore();

        //Videos added to the store:
        store.AddVideo("LEO", "Action", new TimeSpan(2, 16, 0));
        store.AddVideo("The Greatest of All Time", "Action/Sci-Fi", new TimeSpan(3, 01, 0));
        store.AddVideo("MASTER", "Action", new TimeSpan(2, 55, 0));

        //To list all Videos:
        store.ListAllVideos();

        //Renting video:
        store.RentVideo(1, "Ahamed Maahin");

        //searching vieos:
        store.SearchVideos("The Greatest of All Time");

        //To List all videos once again.
        store.ListAllVideos();
    }
}*/



