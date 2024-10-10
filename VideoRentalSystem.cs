
//LA 5.2:

using System;
using System.Collections.Generic;





public class User
{
    private static int _userIdCounter = 1;
    public string Name { get; set; }
    public int UserId { get; private set; }
    public List<Video> CurrentRentals { get; private set; }
    public List<Video> PastRentals { get; private set; }

    public User(string name)
    {
        Name = name;
        UserId = _userIdCounter++;
        CurrentRentals = new List<Video>();
        PastRentals = new List<Video>();
    }

    public void CheckoutVideo(Video video)
    {
        CurrentRentals.Add(video);
    }

    public void ReturnVideo(Video video)
    {
        if (CurrentRentals.Contains(video))
        {
            CurrentRentals.Contains((video));
            {
                CurrentRentals.Remove(video);
                PastRentals.Add(video);
            }
        }
        else
        {
            Console.WriteLine($"{video.Name} is not currently rented by {Name}.");
        }
    }
}

public class RentalSystem
{
    public List<User> Users { get; private set; }
    public List<Video> Videos { get; private set; }


    public RentalSystem()
    {
        Users = new List<User>();
        Videos = new List<Video>();
    }

    public User CreateUser(string name)
    {
        User user = new User(name);
        Users.Add(user);
        return user;

    }

    public Video AddVideo(string title, string genre, TimeSpan duration)
    {
        Video video = new Video(title, genre, duration);
        return video;
    }

    public void CheckoutVideo(User user, Video video)
    {
        if (!user.CurrentRentals.Contains(video))
        {
            user.CheckoutVideo(video);
            Console.WriteLine($"{user.Name} has checked out \".");
        }

        else
        {
            Console.WriteLine($"{user.Name} has already checked out \"{video.Name}\".");
        }
    }

    public void ReturnVideo(User user, Video video)
    {
        user.ReturnVideo(video);
        Console.WriteLine($"{user.Name} has returned \"{video.Name}\".");
    }

    public void DisplayUserRentals(User user)
    {
        Console.WriteLine($"\nCurrent Rentals for {user.Name}:");
        if (user.CurrentRentals.Count > 0)
        {
            foreach (var video in user.CurrentRentals)
            {
                Console.WriteLine($"-{video}");
            }
        }

        else
        {
            Console.WriteLine("No current rentals");
        }

        Console.WriteLine($"\nPast rentals for {user.Name}");
        if (user.PastRentals.Count > 0)
        {
            foreach (var video in user.PastRentals)
            {
                Console.WriteLine($"-{video.Name}");
            }
        }

        else
        {
            Console.WriteLine("No past Rentals.");
        }
    }
}