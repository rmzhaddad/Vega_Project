using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Project_CodeWithMosh.Persistence
{

   public interface IUnitOfWork
    {
                Task CompleteAsync();
    }
}
