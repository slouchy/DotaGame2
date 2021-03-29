using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Models.Solider
{
    public abstract class Base : IPerson
    {
        public Guid _id { get; } = Guid.NewGuid();
        public float _life { get; set; }
        public List<IResource> _cost { get; set; }
        protected float _attack { get; set; }

        protected abstract float GetAttack();

        public float DoAttack(float enemyLife)
        {
            // 1. 士兵進行攻擊
            var soliderAttack = GetAttack();
            // 2. 敵人扣除血量
            enemyLife -= soliderAttack;
            return enemyLife;
        }
    }
}
