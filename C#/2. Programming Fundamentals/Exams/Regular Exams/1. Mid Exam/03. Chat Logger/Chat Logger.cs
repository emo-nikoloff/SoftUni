/**/
using System;
using System.Collections.Generic;

namespace _03._Chat_Logger;

class Program
{
    static void Main(string[] args)
    {
        List<string> chatLog = new();
        string command;

        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandParts = command.Split();

            string message = commandParts[1];

            switch (commandParts[0])
            {
                case "Chat":
                    chatLog.Add(message);
                    break;
                case "Delete":
                    if (chatLog.Contains(message))
                    {
                        chatLog.Remove(message);
                    }
                    break;
                case "Edit":
                    string editedMessage = commandParts[2];

                    if (chatLog.Contains(message))
                    {
                        int messageIndex = chatLog.IndexOf(message);
                        chatLog[messageIndex] = editedMessage;
                    }
                    break;
                case "Pin":
                    if (chatLog.Contains(message))
                    {
                        int messageIndex = chatLog.IndexOf(message);
                        string currentMessage = message;

                        chatLog.RemoveAt(messageIndex);
                        chatLog.Add(currentMessage);
                    }
                    break;
                case "Spam":
                    for (int i = 1; i < commandParts.Length; i++)
                    {
                        message = commandParts[i];
                        chatLog.Add(message);
                    }
                    break;
            }
        }

        for (int i = 0; i < chatLog.Count; i++)
        {
            Console.WriteLine(chatLog[i]);
        }
    }
}
