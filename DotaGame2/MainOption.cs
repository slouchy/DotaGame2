using DotaGame2.Interface;
using DotaGame2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotaGame2
{
    public class MainOption
    {
        public static List<IPerson> _villagers;
        public static List<IPerson> _soliders;
        public static List<IResource> _resources;
        public static List<IEemeny> _emenies;
        public static LevelModel _level;

        public MainOption()
        {
            _villagers = new List<IPerson>();
            _soliders = new List<IPerson>();
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
                    if (CheckResourceAndMinus(userInput))
                    {
                        IPerson person = new Person(Enums.Person.Solider);
                        person.Life = 30;
                        _soliders.Add(person);
                        isAttack = GetAttackStatus(true);
                    }
                    break;
                case "villager":
                    if (CheckResourceAndMinus(userInput))
                    {
                        IPerson person = new Person(Enums.Person.Villager);
                        person.Life = 20;
                        _villagers.Add(person);
                        isAttack = GetAttackStatus(true);
                    }

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
            var attackEvent = new AttackEvent();
            var soliderCount = GetSoliderCount();
            var nLife = attackEvent.UserAttack(soliderCount, _emenies.FirstOrDefault().Life);

            bool isOver = nLife <= 0;
            _emenies.FirstOrDefault().Life = nLife;
            if (!isOver)
            {
                var attackTarget = _soliders.OrderBy(x => x.Life).FirstOrDefault() ?? _villagers.OrderBy(x => x.Life).FirstOrDefault();
                if (attackTarget == null)
                {
                    SetGameOver();
                    isOver = GetOverStatus();
                }
                else
                {
                    var remainingLife = attackEvent.EnemyAttack(attackTarget.Life);
                    SetAttackedStatus(attackTarget, remainingLife);
                }
            }

            return isOver;
        }

        private static void SetAttackedStatus(IPerson attackTarget, float remainingLife)
        {
            if (remainingLife <= 0)
            {
                _soliders.Remove(attackTarget);
                _villagers.Remove(attackTarget);
            }
            else
            {
                attackTarget.Life = remainingLife;
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

        private void SetVillagerCollectStatus(IPerson villager)
        {
            villager.IsCollected = !villager.IsCollected;
        }

        private int GetSoliderCount()
        {
            return _soliders.Count;
        }
    }
}