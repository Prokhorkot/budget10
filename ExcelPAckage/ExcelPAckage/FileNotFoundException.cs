using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelPAckage
{
    class FileNotFoundException: Exception
    {
        public FileNotFoundException(String msg): base(msg)
        {

        }
    }
}
