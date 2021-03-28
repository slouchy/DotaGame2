using DotaGame2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaGame2.Interface
{
    public interface IGenerateService
    {
       bool Generate(List<IResource> resource);
    }
}
