using DotaGame2.Interface;
using DotaGame2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2
{
    public class Person : IPerson
    {
        private Enums.Person _personType;

        public bool IsCollected { get; set; }

        public Person(Enums.Person type)
        {
            _personType = type;
        }

        int IPerson.CollectResource()

        {
            var people = new string[] { };
            var resource = 0;
            for (int i = 0; i < people.Length; i++)
            {
                if (!IsVillagerCollectioned())
                {
                    DoCollect();
                    SetCollectioned(true);
                }
                else
                {
                    SetCollectioned(false);
                }
            }

            return resource;
        }

        private void DoCollect()
        {
            throw new NotImplementedException();

        }

        private void SetCollectioned(bool isCollected)
        {
            throw new NotImplementedException();

        }

        private bool IsVillagerCollectioned()
        {
            throw new NotImplementedException();

        }
    }
}
