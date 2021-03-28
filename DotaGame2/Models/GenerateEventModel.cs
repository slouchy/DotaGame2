using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models
{
    public class GenerateEventModel
    {
        public Enums.GenerateEvent MyEvent { get; set; }

        public List<ResourceModel> Costs { get; set; }
    }
}
