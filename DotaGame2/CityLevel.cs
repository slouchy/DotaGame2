using System;

namespace DotaGame2
{
    internal class CityLevel
    {
        public CityLevel()
        {
        }

        internal bool LevelUp()
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

        private int DeductResource(int resource, int useResource)
        {
            throw new NotImplementedException();
        }

        private void ShowGenerateSuccess()
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
    }
}