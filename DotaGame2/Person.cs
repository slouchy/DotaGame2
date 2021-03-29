using DotaGame2.Interface;
using DotaGame2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2
{
    public class Person : IPerson
    {
        public Guid _id { get; } = Guid.NewGuid();
        public float _life { get; set; }
        public List<IResource> _cost { get; set; }



        private Enums.Person _personType;

        public bool IsCollected { get; set; }

        public float Life { get; set; }

        public int Cost { get; set; }
        

        public Person()
        {

        }

        public void DoAttack()
        {
            throw new NotImplementedException();
        }

        public void DoCollect()
        {
            throw new NotImplementedException();
        }
    }
}
