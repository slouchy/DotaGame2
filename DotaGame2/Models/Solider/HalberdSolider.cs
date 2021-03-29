using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models.Solider
{
    public class HalberdSolider : Base
    {
        public HalberdSolider()
        {
            _life = 30;
            _cost = new List<IResource> { new ResourceModel { HaveResourceCount = 30 } };
            _attack = 10;
        }

        protected override float GetAttack()
        {
            return _attack;
        }
    }
}
