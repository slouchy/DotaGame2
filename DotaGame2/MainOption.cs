using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2
{
    public class MainOption
    {
        public MainOption()
        {
            throw new NotImplementedException();
        }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

        public void ShowOptions()
        {
            throw new NotImplementedException();
        }

        public bool MainOptions()
        {
            IPerson person;
            var userInput = ("").ToLower();
            var isAttack = false;
            bool isOver;
            if (userInput == "quit")
            {
                isOver = IsOver();
                return isOver;
            }

            switch (userInput.ToLower())
            {
                case "soldier":
                    person = new Person();
                    isAttack = person.Generate();
                    break;
                case "villager":
                    person = new Person();
                    isAttack = person.Generate();
                    break;
                case "level":
                    var cityLevel = new CityLevel();
                    isAttack = cityLevel.LevelUp();
                    break;
                case "skip":
                    isAttack = IsAttack();
                    break;
            }

            var attackEvent = new AttackEvent(isAttack);
            isOver = attackEvent.Attack();

            if (!isOver)
            {
                person = new Person();
               var totalResource = person.CollectResource();
            }

            return isOver;
        }

        public void SetGameOver()
        {
            throw new NotImplementedException();
        }

        private bool IsAttack()
        {
            throw new NotImplementedException();
        }

        private bool IsOver()
        {
            throw new NotImplementedException();

        }
    }
}
