namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get; }
        public int Cores { get; }
        public double Frequency { get; }

        public override string ToString()
        {
            return $"{Brand} CPU:\nCores: {Cores}\nFrequency: {Frequency:f1} GHz";
        }
    }
}
