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
            var isOver = false;
            if (!_attackStatus)
            {
                return isOver;
            }

            isOver = UserAttackTurn();
            return isOver;
        }

        private bool UserAttackTurn()
        {
            var isOver = false;
            var soliders = new string[] { };
            var enemyLife = 0;
            for (int i = 0; i < soliders.Length; i++)
            {
                var result = SoliderAttack();
                enemyLife -= SetEnemyLife(result);
                if (enemyLife <= 0)
                {
                    setGameSuccess();
                    isOver = true;
                    break;
                }
            }

            return isOver;
        }

        private void setGameSuccess()
        {
            throw new NotImplementedException();
        }

        private int SetEnemyLife(int attack)
        {
            throw new NotImplementedException();
        }

        private int SoliderAttack()
        {
            throw new NotImplementedException();
        }
    }
}