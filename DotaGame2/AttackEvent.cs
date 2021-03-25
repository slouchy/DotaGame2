using DotaGame2.Interface;
using System;

namespace DotaGame2
{
    internal class AttackEvent
    {

        public AttackEvent()
        {
        }

        internal float UserAttack(int soliderCount, float enemyLife)
        {
            for (int i = 0; i < soliderCount; i++)
            {
                enemyLife -= 10;
                if (enemyLife <= 0)
                {
                    setGameSuccess();
                    break;
                }
            }

            return enemyLife;
        }

        internal float EnemyAttack(float life)
        {
            life -= 20;
            return life;
        }

        private void setGameSuccess()
        {
            Console.WriteLine("You win!!");
        }
    }
}