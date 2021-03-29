using System;
using System.Collections.Generic;

namespace DotaGame2.Interface
{
    public interface IPerson
    {
        Guid _id { get; }

        float _life { get; set; }

        List<IResource> _cost { get; set; }

        //void DoAttack();

        //void DoCollect();
    }
}