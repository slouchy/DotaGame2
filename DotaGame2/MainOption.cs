﻿using DotaGame2.Interface;
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
                    isAttack = GenerateSoldier();
                    break;
                case "villager":
                    if (CheckResourceAndMinus(userInput))
                    {
                        GenerateVillager();
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

        private bool GenerateSoldier()
        {
            Console.WriteLine("Choose Solider type: Halberd(30), Archer(30), Infantry(35), Cavalry(50)? ");
            var userInput = Console.ReadLine().ToLower();
            IPerson person;
            var isAttack = true;
            switch (userInput)
            {
                case "halberd":
                    person = new HalberdModel()
                    {
                        Life = 30,
                        Cost = 30,
                        IsCollected = false,
                        Type = Enums.Person.Halberd
                    };
                    break;
                case "archer":
                    person = new ArcherModel()
                    {
                        Life = 25,
                        Cost = 30,
                        IsCollected = false,
                        Type = Enums.Person.Archer
                    };
                    break;
                case "infantry":
                    person = new InfantryModel()
                    {
                        Life = 15,
                        Cost = 35,
                        IsCollected = false,
                        Type = Enums.Person.Infantry
                    };
                    break;
                case "cavalry":
                    person = new CavalryModel()
                    {
                        Life = 50,
                        Cost = 50,
                        IsCollected = false,
                        Type = Enums.Person.Cavalry
                    };
                    break;
                default:
                    isAttack = false;
                    person = null;
                    break;
            }

            if (person != null)
            {
                if (_resources.First().HaveResourceCount - person.Cost < 0)
                {
                    isAttack = false;
                }
                else
                {
                    _resources.First().HaveResourceCount -= person.Cost;
                    _soliders.Add(person);
                    isAttack = true;
                }
            }

            return isAttack;
        }

        private void GenerateVillager()
        {
            Console.WriteLine("Choose Villager sex: Man or Woman?");
            var userInput = Console.ReadLine().ToLower();
            IPerson person = new VillagerModel();

            switch (userInput)
            {
                case "man":
                    person.Type = Enums.Person.ManVillager;
                    break;
                case "woman":
                    person.Type = Enums.Person.WomanVillager;
                    break;
            }

            _villagers.Add(person);
        }

        private bool DoAttack()
        {
            var attackEvent = new AttackEvent();
            var soliderCount = GetSoliderCount();
            var enemyLife = attackEvent.UserAttack(soliderCount, _emenies.FirstOrDefault().Life);

            bool isOver = enemyLife <= 0;
            _emenies.FirstOrDefault().Life = enemyLife;
            if (!isOver)
            {
                var attackTarget = GetAttackTarget();
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