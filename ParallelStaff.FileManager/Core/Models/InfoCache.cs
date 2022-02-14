using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using static ParallelStaff.FileManager.Common.Enums;

namespace ParallelStaff.FileManager.Core
{
    public class InfoCache
    {
        public TreeNode Node { get; set; }
        public string FullPath { get; set; }
        public OriginControl Origin { get; set; }

        public OperationMenu Operation { get; set; }
    }
}
