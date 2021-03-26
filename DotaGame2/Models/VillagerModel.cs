using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models
{
    public class VillagerModel : VillagerBase
    {
        public override Enums.Person Type { get; set; } = Enums.Person.ManVillager;
        public override float Life { get; set; } = 20;
        public override int Cost { get; set; } = 20;
    }
}
