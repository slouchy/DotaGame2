using DotaGame2.Interface;
using System;
using System.Collections.Generic;

namespace DotaGame2.Models.Solider
{
    internal class ArcherSolider : Base
    {
        public ArcherSolider()
        {
            _life = 20;
            _cost = new List<IResource> { new ResourceModel { HaveResourceCount = 25 } };
            _attack = 20;
        }

        protected override float GetAttack()
        {
            return _attack;
        }
    }
}