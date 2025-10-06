/*Anno 1681. The Caribbean. The golden age of piracy. You are a well-known pirate captain by the name of Jack Daniels. Together with your comrades Jim (Beam) and Johnny (Walker), you have been roaming
the seas, looking for gold and treasure… and the occasional killing, of course. Go ahead, target some wealthy settlements and show them the pirate's way!
Until the "Sail" command is given, you will be receiving:
· You and your crew have targeted cities, with their population and gold, separated by "||".
· If you receive a city that has already been received, you have to increase the population and gold with the given values.
After the "Sail" command, you will start receiving lines of text representing events until the "End" command is given.
Events will be in the following format:
· "Plunder=>{town}=>{people}=>{gold}"
    o You have successfully attacked and plundered the town, killing the given number of people and stealing the respective amount of gold.
    o For every town you attack print this message: "{town} plundered! {gold} gold stolen, {people} citizens killed."
    o If any of those two values (population or gold) reaches zero, the town is disbanded.
        § You need to remove it from your collection of targeted cities and print the following message: "{town} has been wiped off the map!"
    o There will be no case of receiving more people or gold than there is in the city.
· "Prosper=>{town}=>{gold}"
    o There has been dramatic economic growth in the given city, increasing its treasury by the given amount of gold.
    o The gold amount can be a negative number, so be careful. If a negative amount of gold is given, print: "Gold added cannot be a negative number!" and ignore the command.
    o If the given gold is a valid amount, increase the town's gold reserves by the respective amount and print the following message:
"{gold added} gold added to the city treasury. {town} now has {total gold} gold."
· On the first lines, until the "Sail" command, you will be receiving strings representing the cities with their gold and population, separated by "||"
· On the following lines, until the "End" command, you will be receiving strings representing the actions described above, separated by "=>"
· After receiving the "End" command, if there are any existing settlements on your list of targets, you need to print all of them, in the following format:
"Ahoy, Captain! There are {count} wealthy settlements to go to:
{town1} -> Population: {people} citizens, Gold: {gold} kg
{town2} -> Population: {people} citizens, Gold: {gold} kg
…
{town…n} -> Population: {people} citizens, Gold: {gold} kg"
· If there are no settlements left to plunder, print:
"Ahoy, Captain! All targets have been plundered and destroyed!"*/
using System;
using System.Collections.Generic;

namespace _03._P_rates;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Dictionary<string, City> cities = new();

        while ((input = Console.ReadLine()) != "Sail")
        {
            string[] inputParts = input.Split("||");

            string cityName = inputParts[0];
            int cityPopulation = int.Parse(inputParts[1]);
            int cityGold = int.Parse(inputParts[2]);

            if (cities.ContainsKey(cityName))
            {
                cities[cityName].Population += cityPopulation;
                cities[cityName].Gold += cityGold;
            }
            else
            {
                cities[cityName] = new City(cityName, cityPopulation, cityGold);
            }
        }

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputParts = input.Split("=>");

            string action = inputParts[0];
            string town = inputParts[1];

            switch (action)
            {
                case "Plunder":
                    int killedPeople = int.Parse(inputParts[2]);
                    int stolenGold = int.Parse(inputParts[3]);
                    City city = cities[town];

                    city.Population -= killedPeople;
                    city.Gold -= stolenGold;

                    Console.WriteLine($"{town} plundered! {stolenGold} gold stolen, {killedPeople} citizens killed.");

                    if (city.Population <= 0 || city.Gold <= 0)
                    {
                        cities.Remove(town);

                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                    break;
                case "Prosper":
                    int givenGold = int.Parse(inputParts[2]);

                    if (givenGold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        cities[town].Gold += givenGold;

                        Console.WriteLine($"{givenGold} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
                    }
                    break;
            }
        }

        if (cities.Count > 0)
        {
            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach (KeyValuePair<string, City> town in cities)
            {
                Console.WriteLine($"{town.Value.Name} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
            }
        }
        else
        {
            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }
}

class City
{
    public City(string name, int population, int gold)
    {
        Name = name;
        Population = population;
        Gold = gold;
    }

    public string Name { get; set; }
    public int Population { get; set; }
    public int Gold { get; set; }
}
