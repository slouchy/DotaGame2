﻿using DotaGame2.Event;
using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models
{
    public class ArcherGenerate : GenerateServiceBase
    {
        private List<IResource> _eventCost;

        public ArcherGenerate(IPerson person)
        {
            _eventCost = person._cost;
        }

        protected override List<IResource> GetCostResource()
        {
            return _eventCost;
        }
    }
}
