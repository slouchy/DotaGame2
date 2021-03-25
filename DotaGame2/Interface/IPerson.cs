namespace DotaGame2.Interface
{
    public interface IPerson
    {
        bool IsCollected { get; set; }

        int CollectResource();

    }
}