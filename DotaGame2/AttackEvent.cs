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

            var soliders = new int[] { };
            var villagers = new int[] { };
            var enemyLife = 0;
            for (int i = 0; i < soliders.Length; i++)
            {
                var result = DoAttack(soliders[i]);
                SetEnemyLife(enemyLife, result);
            }

            if (enemyLife <= 0)
            {
                SetGameSuccess();
                isOver = IsGameOver(true);
                return isOver;
            }

            if (soliders.Length <= 0 && villagers.Length <= 0)
            {
                SetGameFail();
                isOver = IsGameOver(true);
                return isOver;
            }

            if (soliders.Length > 0)
            {
                EnemyAttack(soliders);
            }
            else
            {
                if (villagers.Length > 0)
                {
                    EnemyAttack(soliders);
                }
            }

            isOver = false;
            return isOver;
        }

        private void EnemyAttack(int[] soliders)
        {
            throw new NotImplementedException();
        }

        private void SetGameFail()
        {
            throw new NotImplementedException();
        }

        private bool IsGameOver(bool v)
        {
            throw new NotImplementedException();
        }

        private void SetGameSuccess()
        {
            throw new NotImplementedException();
        }

        private void SetEnemyLife(int enemyLife, object result)
        {
            throw new NotImplementedException();
        }

        private object DoAttack(int v)
        {
            throw new NotImplementedException();
        }
    }
}