namespace CustomRandomList;

public class RandomList : List<string>
{
    public string RandomString()
    {
        Random random = new();

        string stringToRemove = this[random.Next(0, Count)];

        Remove(stringToRemove);

        return stringToRemove;
    }
}
