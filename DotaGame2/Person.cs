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
                if (!IsVillagerCollectioned())
                {
                    DoCollect();
                    SetCollectioned(true);
                }
                else
                {
                    SetCollectioned(false);
                }
            }

            return resource;
        }

        bool IPerson.Generate()
        {
            var resource = LoadGenerateInfo();
            var useResource = 0;
            var isAttack = false;
            if (resource < useResource)
            {
                ShowResourceNotEnough();
                isAttack = IsAttack(false);
                return isAttack;
            }

            resource = DeductResource(resource, useResource);
            ShowGenerateSuccess();
            isAttack = IsAttack(true);
            return isAttack;

        }

        private void ShowGenerateSuccess()
        {
            throw new NotImplementedException();
        }

        private int DeductResource(int resource, int useResource)
        {
            throw new NotImplementedException();
        }

        private bool IsAttack(bool isAttack)
        {
            throw new NotImplementedException();
        }

        private void ShowResourceNotEnough()
        {
            throw new NotImplementedException();
        }

        private int LoadGenerateInfo()
        {
            throw new NotImplementedException();
        }

        private void DoCollect()
        {
            throw new NotImplementedException();

        }

        private void SetCollectioned(bool isCollected)
        {
            throw new NotImplementedException();

        }

        private bool IsVillagerCollectioned()
        {
            throw new NotImplementedException();

        }
    }
}
