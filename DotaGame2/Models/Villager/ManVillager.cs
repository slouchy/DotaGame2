using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models.Villager
{
    public class ManVillager : Base
    {
        public ManVillager()
        {
            _life = 30;
            _cost = new List<IResource> { new ResourceModel { HaveResourceCount = 30 } };
        }

        public override void DoCollect()
        {
            throw new NotImplementedException();
        }
    }
}
