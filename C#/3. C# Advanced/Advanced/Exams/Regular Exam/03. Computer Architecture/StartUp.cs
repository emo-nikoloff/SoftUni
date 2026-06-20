/*Your task is to create a computer repository that stores CPU components by creating the classes described below.
You are given a class CPU,  create the following properties:
•	Brand - string
•	Cores - int
•	Frequency - double
The class constructor should receive brand, cores, and frequency. Override the ToString() method in the following format:
{brand} CPU:
Cores: {cores}
Frequency: {frequency} GHz
Note: Format the Frequency to the first digit after the decimal point!
Next, you are given a class Computer that has a Multiprocessor (a collection that stores CPU entities). All entities inside the collection have the same fields. Every Computer will have Capacity
of the motherboard, and adding new CPU will be limited by the Capacity. Also, the Computer class should have the following properties:
•	Model - string
•	Capacity – int 
•	Multiprocessor – List<CPU>
The class constructor should receive the model and capacity, also it should initialize the multiprocessor with a new instance of the collection. Implement the following features:
•	Getter Count - returns the number of CPUs
•	Method	 Add(CPU cpu) - adds an entity to the multiprocessor if there is room for it. If there is no room for another CPU, skip the command
•	Method Remove(string brand) - removes a CPU by a given brand. If such exists, returns true, otherwise, returns false.
•	Method MostPowerful() - returns the most powerful CPU (the CPU with the highest frequency)
•	Method GetCPU(string brand) – returns the CPU with the given brand. If there is no CPU, meeting the requirements, return null
•	Method Report() - returns a String in the following format:	
    o	CPUs in the Computer {model}:
        {CPU1}
        {CPU2}
        (…)*/
namespace ComputerArchitecture;

public class StartUp
{
    static void Main(string[] args)
    {
        Computer computer = new Computer("Gaming Serioux", 4);

        CPU cpu = new CPU("AMD Ryzen 5", 6, 3.7);

        Console.WriteLine(cpu);

        computer.Add(cpu);

        Console.WriteLine(computer.Remove("Intel Core i5"));

        CPU secondCPU = new CPU("Intel Core i7", 8, 4);
        CPU thirdCPU = new CPU("Intel Core i5", 8, 3.9);

        computer.Add(secondCPU);
        computer.Add(thirdCPU);

        CPU mostPowerful = computer.MostPowerful();
        Console.WriteLine(mostPowerful);

        CPU receivedCPU = computer.GetCPU("Intel Core i5");
        Console.WriteLine(receivedCPU);

        Console.WriteLine(computer.Count);

        Console.WriteLine(computer.Remove("Intel Core i5"));

        Console.WriteLine(computer.Report());
    }
}
