using DotaGame2.Interface;
using System;
using System.Collections.Generic;

namespace DotaGame2.Models.Solider
{
    internal class CavalrySolider : Base
    {
        public CavalrySolider()
        {
            _life = 50;
            _cost = new List<IResource> { new ResourceModel { HaveResourceCount = 50 } };
        }

        public override void DoAttack()
        {
            throw new NotImplementedException();
        }
    }
}