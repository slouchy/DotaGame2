﻿using DotaGame2.Interface;
using DotaGame2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2
{
    public class Person : IPerson
    {
        private Enums.Person _personType;

        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsCollected { get; set; }

        public float Life { get; set; }

        public Person(Enums.Person type)
        {
            _personType = type;
        }
    }
}
