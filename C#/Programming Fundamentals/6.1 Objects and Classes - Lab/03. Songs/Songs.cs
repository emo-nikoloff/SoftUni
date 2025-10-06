/*Define a class called Song that will hold the following information about some songs:
· Type List
· Name
· Time
· On the first line, you will receive the number of songs - N.
· On the next N lines, you will be receiving data in the following format: "{typeList}_{name}_{time}".
· On the last line, you will receive Type List or "all".
If you receive Type List as an input on the last line, print out only the names of the songs, which are from that Type List. If you receive the "all" command, print out the names of all the songs.*/
using System;
using System.Collections.Generic;

namespace _03._Songs;

class Program
{
    static void Main(string[] args)
    {
        int songs = int.Parse(Console.ReadLine());

        List<Song> songsList = new();

        for (int i = 1; i <= songs; i++)
        {
            string[] data = Console.ReadLine().Split("_");

            string type = data[0];
            string name = data[1];
            string time = data[2];

            Song song = new();

            song.TypeList = type;
            song.Name = name;
            song.Time = time;

            songsList.Add(song);
        }

        string typeList = Console.ReadLine();

        if (typeList == "all")
        {
            foreach (Song song in songsList)
            {
                Console.WriteLine(song.Name);
            }
        }
        else
        {
            foreach (Song song in songsList)
            {
                if (song.TypeList == typeList)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}

class Song
{
    public string TypeList { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }

}
