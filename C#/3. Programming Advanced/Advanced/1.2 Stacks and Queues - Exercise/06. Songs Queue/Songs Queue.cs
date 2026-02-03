/*Write a program that keeps track of a song's queue. The first song that is put in the queue, should be the first that gets played. A song cannot be added, if it is currently in the queue.
You will be given a sequence of songs, separated by a comma and a single space. After that, you will be given commands until there are no songs enqueued. When there are no more songs in the queue
print "No more songs!" and stop the program.
The possible commands are:
· "Play" - plays a song (removes it from the queue)
· "Add {song}" - adds the song to the queue, if it isn't contained already, otherwise print "{song} is already contained!"
· "Show" - prints all songs in the queue, separated by a comma and a white space (start from the first song in the queue to the last)*/
namespace _06._Songs_Queue;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> songs = new(Console.ReadLine().Split(", "));
        while (songs.Count > 0)
        {
            string[] commandTokens = Console.ReadLine().Split();
            string command = commandTokens[0];
            switch (command)
            {
                case "Play":
                    songs.Dequeue();
                    break;
                case "Add":
                    string song = string.Join(" ", commandTokens.Skip(1));
                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    break;
                case "Show":
                    Console.WriteLine(string.Join(", ", songs));
                    break;
            }
        }
        Console.WriteLine("No more songs!");
    }
}
