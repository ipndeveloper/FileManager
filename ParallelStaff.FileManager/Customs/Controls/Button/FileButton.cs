using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ParallelStaff.FileManager.Common;
using static ParallelStaff.FileManager.Common.Enums;

namespace ParallelStaff.FileManager.Customs.Controls
{
    public class FileButton : Button
    {
        protected IMediator _mediator;
        public FileButton(IMediator Mediator)
        {
            this._mediator = Mediator;
            this.Click += new System.EventHandler(this.button1_Click);
        }
        private async void button1_Click(object sender, EventArgs e )
        {
            await _mediator.Notify(sender, e , EventControl.Click);
        }
    }
}
