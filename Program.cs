//LA 5.1:

//PacMan High Score recording Script:

using System;

class PacManHighScore
{
    public string Initials { get; set; }
    public int Score { get; set; }
    public PacManHighScore(string initials, int score)
    {
        Initials = initials;
        Score = score;
    }
}

class Program
{
    static List<PacManHighScore> highScores = new List<PacManHighScore>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. High Score Record.");
            Console.WriteLine("2. View High Scores.");
            Console.WriteLine("3. Exit.");
            Console.WriteLine("4. Choose an Option.");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                RecordHighScore();
            }

            else if (choice == "2")
            {
                ViewHighScores();
                break; //After viewing the HighScore, the program will be exited.
            }

            else if (choice == "3")
            {
                break; // Exits the Program immediately.
            }

            else
            {
                Console.WriteLine("You might have choosen the wrong option. Could you please Try Again?");
            }
        }
    }

    static void RecordHighScore()
    {
        Console.WriteLine("Enter the Name of yours (Kindly make sure that its not more than 15 characters): ");
        string initials = Console.ReadLine().ToUpper();

        while (initials.Length > 15)
        {
            Console.WriteLine(initials);
            Console.WriteLine("Enter your Initials");
            initials = Console.ReadLine().ToUpper();
        }

        Console.WriteLine("Enter your Score: ");
        int score;
        while (!int.TryParse(Console.ReadLine(), out score) || score < 0)
        {
            Console.WriteLine("Invalid Score. Enter a Positive number");
            Console.WriteLine("Enter your Score: ");
        }

        highScores.Add(new PacManHighScore(initials, score));
        Console.WriteLine("High Score recorded");
    }

    static void ViewHighScores()
    {
        Console.WriteLine("\n High Scores:");

        if (highScores.Count == 0)
        {
            Console.WriteLine("No high scores recorded.");
        }

        else
        {
            highScores.Sort((x, y) => y.Score.CompareTo(x.Score));
        }

        foreach (var highScore in highScores)
        {
            Console.WriteLine($"{highScore.Initials}: {highScore.Score}");
        }

        Console.WriteLine("\n Exiting...");
    }



}