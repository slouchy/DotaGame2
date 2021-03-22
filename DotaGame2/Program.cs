using System;

namespace DotaGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            var isOver = false;
            var main = new MainOption();
            while (!isOver)
            {
                main.ShowInfo();
                main.ShowOptions();
                main.MainOptions();
            }

            main.SetGameOver();
        }
    }
}
