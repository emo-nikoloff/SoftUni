/*You will receive three lines from the console:
· A count of people who are going on vacation.
· Type of the group (Students, Business or Regular).
· The day of the week which the group will stay on (Friday, Saturday or Sunday).
Based on the given information calculate how much the group will pay for the entire vacation.
The price for a single person is as follows:
            Friday  Saturday    Sunday
Students    8.45    9.80        10.46
Business    10.90   15.60       16
Regular     15      20          22.50
There are also discounts based on some conditions:
· For Students – if the group is 30 or more people, you should reduce the total price by 15%.
· For Business – if the group is 100 or more people, 10 of the people stay for free.
· For Regular – if the group is between 10 and 20 people (both inclusively), reduce the total price by 5%.
Note: You should reduce the prices in that EXACT order!
As an output print the final price which the group is going to pay in the format:
"Total price: {price}"
The price should be formatted to the second decimal point*/
using System;

namespace _03._Vacation;

class Program
{
    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());
        string group = Console.ReadLine();
        string day = Console.ReadLine();

        double priceForPerson = 0, totalPrice = 0;
        switch (group)
        {
            case "Students":
                switch (day)
                {
                    case "Friday":
                        priceForPerson = 8.45;
                        break;
                    case "Saturday":
                        priceForPerson = 9.80;
                        break;
                    case "Sunday":
                        priceForPerson = 10.46;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

                if (people >= 30)
                {
                    totalPrice = priceForPerson * people - ((priceForPerson * people) * 0.15);
                }
                else
                {
                    totalPrice = priceForPerson * people;
                }
                break;
            case "Business":
                switch (day)
                {
                    case "Friday":
                        priceForPerson = 10.90;
                        break;
                    case "Saturday":
                        priceForPerson = 15.60;
                        break;
                    case "Sunday":
                        priceForPerson = 16;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

                if (people >= 100)
                {
                    totalPrice = priceForPerson * (people - 10);
                }
                else
                {
                    totalPrice = priceForPerson * people;
                }
                break;
            case "Regular":
                switch (day)
                {
                    case "Friday":
                        priceForPerson = 15;
                        break;
                    case "Saturday":
                        priceForPerson = 20;
                        break;
                    case "Sunday":
                        priceForPerson = 22.50;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }

                if (people >= 10 && people <= 20)
                {
                    totalPrice = priceForPerson * people - ((priceForPerson * people) * 0.05);
                }
                else
                {
                    totalPrice = priceForPerson * people;
                }
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
        Console.WriteLine($"Total price: {totalPrice:f2}");
    }
}
