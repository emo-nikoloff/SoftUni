/*Define a class Trainer and a class Pokemon.
Trainers have:
· Name
· Number of badges
· A collection of pokemon
Pokemon have:
· Name
· Element
· Health
All values are mandatory. Every Trainer starts with 0 badges.
You will be receiving lines until you receive the command "Tournament". Each line will carry information about a pokemon and the trainer who caught it in the format:
"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
TrainerName is the name of the Trainer who caught the pokemon. Trainers' names are unique. After receiving the command "Tournament", you will start receiving commands until the "End" command is
received. They can contain one of the following:
· "Fire"
· "Water"
· "Electricity"
For every command, you must check if a trainer has at least 1 pokemon with the given element. If he does, he receives 1 badge. Otherwise, all of his pokemon lose 10 health. If a pokemon falls to
0 or less health, he dies and must be deleted from the trainer's collection. In the end, you should print all of the trainers, sorted by the number of badges they have in descending order
(if two trainers have the same amount of badges, they should be sorted by order of appearance in the input) in the format:
"{trainerName} {badges} {numberOfPokemon}"*/
namespace _09._Pokemon_Trainer;

public class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;

        Dictionary<string, Trainer> trainersByName = new();
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] info = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string trainerName = info[0];
            if (!trainersByName.ContainsKey(trainerName))
            {
                trainersByName.Add(trainerName, new(trainerName));
            }
            Trainer trainer = trainersByName[trainerName];

            string pokemonName = info[1];
            string pokemonElement = info[2];
            int pokemonHealth = int.Parse(info[3]);
            Pokemon pokemon = new(pokemonName, pokemonElement, pokemonHealth);

            trainer.Collection.Add(pokemon);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            string element = input;

            foreach (Trainer trainer in trainersByName.Values)
            {
                if (trainer.Collection.Any(p => p.Element == element))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Collection.ForEach(p => p.Health -= 10);
                    trainer.Collection.RemoveAll(p => p.Health <= 0);
                }
            }
        }

        trainersByName.Values.OrderByDescending(t => t.Badges).ToList().ForEach(Console.WriteLine);
    }
}
