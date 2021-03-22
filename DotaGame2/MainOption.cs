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
            var userInput = "";
            var isAttack = false;
            var isOver = false;
            var person = new Person();

            switch (userInput.ToLower())
            {
                case "soldier":
                    person.Generate();
                    break;
                case "villager":
                    person = new Person();
                    person.Generate();
                    break;
                case "level":
                    var cityLevel = new CityLevel();
                    cityLevel.LevelUp();
                    break;
                case "skip":
                    isAttack = true;
                    break;
                case "Quit":
                    isOver = true;
                    break;
            }

            var attackEvent = new AttackEvent(isAttack);
            isOver = attackEvent.Attack();

            if (!isOver)
            {
                isOver = person.CollectResource();
            }

            return isOver;
        }

        public void SetGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
