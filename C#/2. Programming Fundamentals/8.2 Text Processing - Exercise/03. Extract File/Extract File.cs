/*Create a program that reads the path to a file and subtracts the file name and its extension.*/
using System;

namespace _03._Extract_File;

class Program
{
    static void Main(string[] args)
    {
        string[] fileDirectory = Console.ReadLine().Split('\\');

        foreach (string item in fileDirectory)
        {
            if (item.Contains('.'))
            {
                string[] fileWithExtension = item.Split('.');

                string fileName = fileWithExtension[0];
                string fileExtension = fileWithExtension[1];

                Console.WriteLine($"File name: {fileName}\nFile extension: {fileExtension}");
                break;
            }
        }
    }
}
