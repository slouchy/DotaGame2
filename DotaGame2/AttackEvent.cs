using System;

namespace DotaGame2
{
    internal class AttackEvent
    {
        private bool _attackStatus;

        public AttackEvent(bool isAttack)
        {
            _attackStatus = isAttack;
        }

        internal bool Attack()
        {
            throw new NotImplementedException();
        }
    }
}