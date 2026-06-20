using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new();
        }

        public string Model { get; }
        public int Capacity { get; }
        public List<CPU> Multiprocessor { get; }
        public int Count { get => Multiprocessor.Count; }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU cpu = Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            if (cpu != null)
            {
                Multiprocessor.Remove(cpu);
                return true;
            }
            return false;
        }

        public CPU MostPowerful()
        {
            return Multiprocessor.OrderByDescending(c => c.Frequency).FirstOrDefault();
        }

        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(c => c.Brand == brand);
        }

        public string Report()
        {
            StringBuilder result = new();

            result.AppendLine($"CPUs in the Computer {Model}:");
            foreach (CPU cpu in Multiprocessor)
            {
                result.AppendLine(cpu.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
