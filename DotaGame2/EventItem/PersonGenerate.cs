﻿using DotaGame2.Event;
using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models
{
    public class PersonGenerate : GenerateServiceBase
    {
        private List<IResource> _eventCost;

        public PersonGenerate(IPerson person)
        {
            _eventCost = new List<IResource>
            {
                new ResourceModel
                {
                    HaveResourceCount = person.Cost
                }
            };
        }

        protected override List<IResource> GetCostResource()
        {
            return _eventCost;
        }
    }
}
