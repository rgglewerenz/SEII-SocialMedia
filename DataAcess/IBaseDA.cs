using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public interface IBaseDA
    {
        void StartTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
