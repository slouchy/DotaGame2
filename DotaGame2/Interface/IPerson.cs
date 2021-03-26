using DotaGame2.Models;
using System;

namespace DotaGame2.Interface
{
    public interface IPerson
    {
        Guid Id { get; }

        int Cost { get; }

        Enums.Person Type { get; set; }

        bool IsCollected { get; set; }

        float Life { get; set; }
    }

    public abstract class SoliderBase : IPerson
    {
        public Guid Id => Guid.NewGuid();
        public bool IsCollected { get; set; }
        public abstract Enums.Person Type { get; set; }
        public abstract float Life { get; set; }
        public abstract int Cost { get; set; }
    }

    public abstract class VillagerBase : IPerson
    {
        public Guid Id => Guid.NewGuid();
        public bool IsCollected { get; set; }
        public abstract Enums.Person Type { get; set; }
        public abstract float Life { get; set; }

        public abstract int Cost { get; set; }
    }
}