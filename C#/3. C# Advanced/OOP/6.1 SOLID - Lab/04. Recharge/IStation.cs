namespace Recharge;

public interface IStation
{
    int Capacity { get; }
    int Current { get; }

    void Dismount();
}

