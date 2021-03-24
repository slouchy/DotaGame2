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
            Console.WriteLine("Choose Options (1)soldier, (2)villager, (3)level, (4)skip, (5)Quit [Input 1,2,3,4,5]");
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
                var totalResource = 0;
                totalResource += person.CollectResource();
            }

            return isOver;
        }

        public void SetGameOver()
        {
            Console.WriteLine("Game Over");
        }

        private bool IsAttack()
        {
            return true;
        }

        private bool IsOver()
        {
            throw new NotImplementedException();

        }
    }
}
