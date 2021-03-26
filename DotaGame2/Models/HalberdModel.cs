using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models
{
    public class HalberdModel : SoliderBase
    {
        public override Enums.Person Type { get; set; }
        public override float Life { get; set; }
        public override int Cost { get; set; }
    }
}
