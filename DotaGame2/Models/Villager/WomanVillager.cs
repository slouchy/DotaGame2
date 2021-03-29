using DotaGame2.Interface;
using System;
using System.Collections.Generic;

namespace DotaGame2.Models.Villager
{
    internal class WomanVillager : Base
    {
        public WomanVillager()
        {
            _life = 35;
            _cost = new List<IResource> { new ResourceModel { HaveResourceCount = 35 } };
        }

        public override void DoCollect()
        {
            throw new NotImplementedException();
        }
    }
}