namespace Counter_Strike.Models.Guns.Contracts
{
    public interface IGun
    {
        string Name { get; }

        int BulletsCount { get; }

        int Fire();
    }
}
