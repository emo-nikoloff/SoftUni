namespace DetailPrinter;

public class Manager : Employee
{
    public Manager(string name, ICollection<string> documents) : base(name)
    {
        Documents = new List<string>(documents);
    }

    public IReadOnlyCollection<string> Documents { get; }

    public override string Info()
    {
        return string.Join(Environment.NewLine, base.Info(), Documents);
    }
}

