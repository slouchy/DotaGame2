using DotaGame2.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2
{
    public class Person : IPerson
    {
        int IPerson.CollectResource()
        {
            var people = new string[] { };
            var resource = 0;
            for (int i = 0; i < people.Length; i++)
            {
                var isCollectioned = false;
                if (!isCollectioned)
                {
                    resource++;
                    isCollectioned = true;
                }
                else
                {
                    isCollectioned = false;
                }
            }

            return resource;
        }

        bool IPerson.Generate()
        {
            throw new NotImplementedException();
        }

        private void DoCollect()
        {

        }
    }
}
