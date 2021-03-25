using System;

namespace DotaGame2.Interface
{
    public interface IPerson
    {
        Guid Id { get; set; }

        bool IsCollected { get; set; }

        float Life { get; set; }
    }
}