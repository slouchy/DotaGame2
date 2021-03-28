using DotaGame2.Interface;
using DotaGame2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2
{
    public class Person : IPerson
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private Enums.Person _personType;

        public bool IsCollected { get; set; }

        public float Life { get; set; }

        public int Cost { get; set; }

        public Person(Enums.Person type)
        {
            _personType = type;
            switch (type)
            {
                case Enums.Person.Solider:
                    Cost = 30;
                    Life = 30;
                    break;
                case Enums.Person.Villager:
                    Cost = 20;
                    Life = 15;
                    break;
                default:
                    break;
            }
        }
    }
}
