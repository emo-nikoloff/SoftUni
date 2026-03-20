namespace MoneyTransactions;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, double> accounts = new();

        string[] accountInput = Console.ReadLine().Split(',');

        for (int i = 0; i < accountInput.Length; i++)
        {
            string[] accountInfo = accountInput[i].Split('-');

            int id = int.Parse(accountInfo[0]);
            double balance = double.Parse(accountInfo[1]);

            accounts.Add(id, balance);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputInfo = input.Split();

            string compand = inputInfo[0];
            int id = int.Parse(inputInfo[1]);
            double balance = double.Parse(inputInfo[2]);

            try
            {
                switch (compand)
                {
                    case "Deposit":
                        accounts[id] += balance;

                        Console.WriteLine($"Account {id} has new balance: {accounts[id]:f2}");
                        break;
                    case "Withdraw":
                        if (accounts[id] < balance)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        accounts[id] -= balance;

                        Console.WriteLine($"Account {id} has new balance: {accounts[id]:f2}");
                        break;
                    default:
                        throw new ArgumentException("Invalid command!");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Invalid account!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Enter another command");
            }
        }
    }
}
