using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models.Villager
{
    public abstract class Base : IPerson
    {
        public Guid _id { get; } = Guid.NewGuid();
        public float _life { get; set; }
        public List<IResource> _cost { get; set; }
        public bool IsCollected { get; set; } = false;

        public abstract void DoCollect();
    }
}
