using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using static ParallelStaff.FileManager.Common.Enums;

namespace ParallelStaff.FileManager.Customs.Controls.ContextMenu
{
    public partial class FileContextMenuStrip : ContextMenuStrip
    {
        protected IMediator _mediator;
        public FileContextMenuStrip(IMediator Mediator , IContainer container) : base(container)
        {
            this._mediator = Mediator;
            this.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(MenuItem_Click);
            this.Opening += new System.ComponentModel.CancelEventHandler(MenuItem_Opening);

        }
        private async void MenuItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
           await  _mediator.Notify(sender, e, EventControl.Click);
        }
        private async  void MenuItem_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
           await  _mediator.Notify(sender, e, EventControl.Opening);
        }
    }
}
