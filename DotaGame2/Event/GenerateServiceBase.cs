using DotaGame2.Interface;
using DotaGame2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotaGame2.Event
{
    public abstract class GenerateServiceBase : IGenerateService
    {
        public bool Generate(List<IResource> resource)
        {
            // 1. 取得類型資源成本
            var cost = GetCostResource();
            bool result;
            // 2. 檢查資源數
            if (CheckResourceEnough(resource, cost))
            {
                // 3. 扣除資源
                DoResourceMinus(resource, cost);
                result = true;
            }
            else
            {
                // 3. 顯示資源不足
                ShowResourceNotEnough();
                result = false;
            }

            // 4. 回傳生成結果
            return result;
        }

        protected abstract List<IResource> GetCostResource();

        private bool CheckResourceEnough(List<IResource> total, List<IResource> cost)
        {
            return total.First().HaveResourceCount - cost.First().HaveResourceCount >= 0;
        }

        private void DoResourceMinus(List<IResource> total, List<IResource> cost)
        {
            total.First().HaveResourceCount -= cost.First().HaveResourceCount;
        }

        private void ShowResourceNotEnough()
        {
            Console.WriteLine("資源不足");
        }
    }
}
