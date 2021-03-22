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
            var info = LoadInfo();

            var isOver = false;
            if (!_attackStatus)
            {
                return isOver;
            }

            isOver = UserAttackTurn();
            if (!isOver)
            {
                isOver = EnemyAttackTurn();
            }

            return isOver;
        }

        private object LoadInfo()
        {
            throw new NotImplementedException();
        }

        private bool EnemyAttackTurn()
        {
            var soliders = new string[] { };
            var villagers = new string[] { };
            var isOver = false;
            if (soliders.Length <= 0 && villagers.Length <= 0)
            {
                SetGameFail();
                isOver = true;
                return isOver;
            }

            var isEnemyAttack = false;
            isOver = false;
            if (soliders.Length > 0)
            {
                isEnemyAttack = EnemyAttack(soliders);
            }

            if (!isEnemyAttack)
            {
                EnemyAttack(villagers);
            }

            return isOver;
        }

        private bool EnemyAttack(string[] people)
        {
            var person = LoadAttackedPerson(people);
            var personLife = EnemyAttackPerson();
            var isOver = false;
            if (personLife <= 0)
            {
                SetPersonDie(person);
            }

            ShowAttackedStatus();
            return isOver;
        }

        private float EnemyAttackPerson()
        {
            throw new NotImplementedException();
        }

        private void SetPersonDie(object person)
        {
            throw new NotImplementedException();
        }

        private void ShowAttackedStatus()
        {
            throw new NotImplementedException();
        }

        private object LoadAttackedPerson(string[] people)
        {
            throw new NotImplementedException();
        }

        private void SetGameFail()
        {
            throw new NotImplementedException();
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