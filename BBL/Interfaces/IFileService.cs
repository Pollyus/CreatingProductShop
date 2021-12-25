using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.Interfaces
{
    public interface IFileService
    {
        void PrintExceptions(Exception ex);
        void PrintCheque(int orderId);
    }
}
