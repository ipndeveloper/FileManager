using System;
using System.Collections.Generic;
using System.Text;

namespace ParallelStaff.FileManager.Common
{
    public class Enums
    {
        public enum EventControl
        {
            Click,
            ClickRigth,
            DoubleClick,
            Opening
        }

        public enum OriginControl
        {
            TreeView,
            ListView
        }
        public enum OperationMenu
        {
            Copiar,
            Cortar,
            Pegar,
            Eliminar
        }

    }
}
