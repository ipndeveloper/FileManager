using static ParallelStaff.FileManager.Common.Enums;
using ParallelStaff.FileManager.Customs.Controls.Treeview;
using ParallelStaff.FileManager.Mediator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ParallelStaff.FileManager.Customs.Controls
{
 
    public partial class FileTreeView : TreeView 
    {
        protected IMediator _mediator;
        public event TreeViewEventHandler SelectedNodeChanged;
        public FileTreeView(IMediator Mediator)
        {
            this._mediator = Mediator;
            this.AfterSelect += new TreeViewEventHandler(SelectNodeChangedEvent);
            this.MouseUp += new MouseEventHandler(MouseUpEvent);
            this.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseDoubleClick);
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.BeforeSelect += (sender, args) =>
            {
               
                //(args.Node as FileTreeNode)?.LoadNodes();
            };

            this.AfterExpand += (sender, args) =>
            {
                (args.Node as FileTreeNode)?.SetIcon();
                (args.Node as FileTreeNode)?.LoadNodes();
            };

            this.AfterCollapse += (sender, args) =>
            {
                (args.Node as FileTreeNode)?.SetIcon();
            };
        }
        void SelectNodeChangedEvent(object sender, TreeViewEventArgs e)
        {
            SelectedNodeChangedTrigger(sender, e);
        }
        void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (this.SelectedNode == null)
                SelectedNodeChangedTrigger(sender, new TreeViewEventArgs(null));
        }
        void SelectedNodeChangedTrigger(object sender, TreeViewEventArgs e)
        {
            if (SelectedNodeChanged != null)
                SelectedNodeChanged(sender, e);
        }
        private async void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
           await  this._mediator.Notify(sender, e, EventControl.DoubleClick);
            
                
        }
        private async void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                await this._mediator.Notify(sender, e, EventControl.ClickRigth);
            }

        }
        public void Load(string path)
        {
            this.BeginUpdate();
            this.Nodes.Clear();

            var root = new FileTreeNode(path);
            this.Nodes.Add(root);
            root.LoadNodes();
            this.EndUpdate();

        }
    }
}
