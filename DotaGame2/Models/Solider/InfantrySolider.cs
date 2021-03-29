using DotaGame2.Interface;
using System;
using System.Collections.Generic;

namespace DotaGame2.Models.Solider
{
    internal class InfantrySolider : Base
    {
        public InfantrySolider()
        {
            _life = 35;
            _cost = new List<IResource> { new ResourceModel { HaveResourceCount = 35 } };
        }

        public override void DoAttack()
        {
            throw new NotImplementedException();
        }
    }
}