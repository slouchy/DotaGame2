using DotaGame2.Interface;
using DotaGame2.Models;
using DotaGame2.Models.Solider;
using DotaGame2.Models.Villager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotaGame2
{
    public class MainOption
    {
        public static List<Models.Villager.Base> _villagers;
        public static List<Models.Solider.Base> _soliders;
        public static List<IResource> _resources;
        public static List<IEemeny> _emenies;
        public static LevelModel _level;

        public MainOption()
        {
            _villagers = new List<Models.Villager.Base>();
            _soliders = new List<Models.Solider.Base>();
            _resources = new List<IResource>()
            {
                new ResourceModel
                {
                    HaveResourceCount = 100
                }
            };
            _emenies = new List<IEemeny>()
            {
                new EemenyModel
                {
                    Life = 100
                }
            };
            _level = new LevelModel
            {
                Lv = 1
            };
        }

        public void ShowInfo()
        {
            var message =
                $"村民數：{_villagers.Count}, \r\n" +
                $"士兵：{_soliders.Count}, \r\n" +
                $"資源數：{string.Join(" | ", _resources.Select(x => x.HaveResourceCount))},  \r\n" +
                $"敵人血量：{string.Join(" | ", _emenies.Select(x => x.Life))} \r\n";
            Console.WriteLine(message);

        }

        public void ShowOptions()
        {
            Console.WriteLine("Choose Options (1)soldier, (2)villager, (3)level, (4)skip, (5)Quit [Input 1,2,3,4,5]");
        }

        public bool MainOptions()
        {
            var userInput = ("").ToLower();
            var isAttack = false;
            bool isOver = false;
            if (userInput == "quit")
            {
                isOver = GetOverStatus();
                return isOver;
            }

            switch (userInput.ToLower())
            {
                case "soldier":
                    isAttack = DoGenerateSoldier();
                    break;
                case "villager":
                    isAttack = DoGenerateVillager();
                    break;
                case "level":
                    if (CheckResourceAndMinus(userInput.ToLower()))
                    {
                        LevelUp();
                        isAttack = GetAttackStatus(true);
                    }
                    break;
                case "skip":
                    isAttack = GetAttackStatus(true);
                    break;
            }

            if (isAttack)
            {
                isOver = DoAttack();
            }

            if (!isOver)
            {
                UpdateResourceCount();
            }

            return isOver;
        }

        private bool DoAttack()
        {
            var isOver = false;
            foreach (var solider in _soliders)
            {
                var enemyLife = solider.DoAttack(_emenies.FirstOrDefault().Life);
                _emenies.FirstOrDefault().Life = enemyLife;
                if (enemyLife <= 0)
                {
                    isOver = true;
                    break;
                }
                else
                {
                    isOver = false;
                }
            }

            if (isOver)
            {
                setGameSuccess();
                SetGameOver();
            }
            else
            {
                var attackTarget = GetAttackTarget();
                if (attackTarget == null)
                {
                    SetGameOver();
                    isOver = GetOverStatus();
                }
                else
                {
                    var attackEvent = new AttackEvent();
                    var remainingLife = attackEvent.EnemyAttack(attackTarget._life);
                    SetAttackedStatus(attackTarget, remainingLife);
                }
            }

            return isOver;
        }

        private static IPerson GetAttackTarget()
        {
            if (_soliders.Any())
            {
                return _soliders.First();
            }

            if (_villagers.Any())
            {
                return _villagers.First();
            }

            return null;
        }

        private static void SetAttackedStatus(IPerson attackTarget, float remainingLife)
        {
            if (remainingLife <= 0)
            {
                if (attackTarget.GetType() == typeof(Models.Villager.Base))
                {
                    _villagers.Remove(attackTarget as Models.Villager.Base);
                }
                else if (attackTarget.GetType() == typeof(Models.Solider.Base))
                {
                    _soliders.Remove(attackTarget as Models.Solider.Base);
                }
            }
            else
            {
                attackTarget._life = remainingLife;
            }
        }

        public void SetGameOver()
        {
            Console.WriteLine("Game Over");
        }

        private bool CheckResourceAndMinus(string userInput)
        {
            int cost = 0;
            switch (userInput.ToLower())
            {
                case "soldier":
                    cost = 30;
                    break;
                case "villager":
                    cost = 10;
                    break;
                case "level":
                    cost = 15;
                    break;
            }

            if (_resources.First().HaveResourceCount - cost < 0)
            {
                return false;
            }
            else
            {
                _resources.First().HaveResourceCount -= cost;
                return true;
            }
        }

        private bool GetAttackStatus(bool isAttack)
        {
            return isAttack;
        }

        private bool GetOverStatus()
        {
            return true;
        }

        private void LevelUp()
        {
            _level.Lv += 1;
        }

        private void UpdateResourceCount()
        {
            var getResourceCount = GetCollectionVillagers();
            _resources.FirstOrDefault().HaveResourceCount += 10 * getResourceCount;
        }

        private int GetCollectionVillagers()
        {
            var canCollectResourceCount = _villagers.Count(x => !x.IsCollected);
            foreach (var villager in _villagers)
            {
                SetVillagerCollectStatus(villager);
            }

            return canCollectResourceCount;
        }

        private void SetVillagerCollectStatus(Models.Villager.Base villager)
        {
            villager.IsCollected = !villager.IsCollected;
        }

        private int GetSoliderCount()
        {
            return _soliders.Count;
        }

        private bool DoGenerateSoldier()
        {
            Console.WriteLine("Choose Solider type: Halberd(30), Archer(30), Infantry(35), Cavalry(50)? ");
            var userInput = Console.ReadLine().ToLower();
            Models.Solider.Base person = null;
            switch (userInput)
            {
                case "halberd":
                    person = new HalberdSolider();
                    break;
                case "archer":
                    person = new ArcherSolider();
                    break;
                case "infantry":
                    person = new InfantrySolider();
                    break;
                case "cavalry":
                    person = new CavalrySolider();
                    break;
            }

            if (person == null)
            {
                return false;
            }
            else
            {
                var soliderGnerate = new PersonGenerate(person);
                var isSuccessGenerateVillager = soliderGnerate.Generate(_resources);
                if (isSuccessGenerateVillager)
                {
                    _soliders.Add(person);
                }

                return isSuccessGenerateVillager;
            }
        }

        private bool DoGenerateVillager()
        {
            Console.WriteLine("Choose Villager sex: Man or Woman?");
            var userInput = Console.ReadLine().ToLower();
            Models.Villager.Base myVillager;
            if (userInput == "man")
            {
                myVillager = new ManVillager();
            }
            else
            {
                myVillager = new WomanVillager();
            }

            var villagerGenerate = new PersonGenerate(myVillager);
            var isSuccessGenerateVillager = villagerGenerate.Generate(_resources);
            if (isSuccessGenerateVillager)
            {
                _villagers.Add(myVillager);
            }

            return isSuccessGenerateVillager;
        }

        private void setGameSuccess()
        {
            Console.WriteLine("You win!!");
        }
    }
}