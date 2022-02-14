using ParallelStaff.FileManager.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ParallelStaff.FileManager.Common.Enums;

namespace ParallelStaff.FileManager
{
    public  interface IMediator
    {
        Task Notify(object sender, EventArgs evento , EventControl fileEvent);
        

    }
}
