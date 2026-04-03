using BlackFriday.Core;
using BlackFriday.Core.Contracts;

namespace BlackFriday;

class Program
{
    static void Main(string[] args)
    {
        IEngine engine = new Engine();
        engine.Run();
    }
}
