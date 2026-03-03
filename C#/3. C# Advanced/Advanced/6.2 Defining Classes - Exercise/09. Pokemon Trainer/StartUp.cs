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
