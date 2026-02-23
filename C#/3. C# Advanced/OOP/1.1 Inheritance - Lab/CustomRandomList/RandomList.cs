namespace CustomRandomList;

public class RandomList : List<string>
{
    public string RandomString()
    {
        Random random = new();

        string removedString = this[random.Next(0, Count)];

        Remove(removedString);

        return removedString;
    }
}
