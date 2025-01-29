using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Contracts.Persistence
{
    public interface IUnityOfWork
    {
        Task<int> SaveChangeAsync();
    }
}
