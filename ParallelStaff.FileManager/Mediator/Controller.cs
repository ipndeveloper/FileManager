using ParallelStaff.FileManager.Core;
using ParallelStaff.FileManager.Customs.Controls;
using ParallelStaff.FileManager.Customs.Controls.ContextMenu;
using ParallelStaff.FileManager.Customs.Controls.Treeview;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ParallelStaff.FileManager.Common.Enums;
namespace ParallelStaff.FileManager.Mediator
{
    public class Controller : IMediator
    {
        private Dictionary<string, InfoCache> Cache = new Dictionary<string, InfoCache>();
        private TreeNode _currentNode = new TreeNode();
        public FileButton BtnControl { get; set; }
        public FileTreeView TreeControl { get; set; }
        public FolderBrowserDialog FolderDialogControl { get; set; }
        public TextBox TxtControl { get; set; }
        public FileContextMenuStrip ContextMenuControl { get; set; }
        public ListView ListViewControl { get; set; }
        public async Task Notify(object sender, EventArgs evento, EventControl fileEvent)
        {
            #region Events Button
            if (BtnControl == sender && fileEvent == EventControl.Click)
            {
                var result = FolderDialogControl.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(FolderDialogControl.SelectedPath))
                {
                    TxtControl.Text = FolderDialogControl.SelectedPath;
                    TreeControl.Load(FolderDialogControl.SelectedPath);
                    ListViewControl.Items.Clear();
                }
            }
            #endregion
            #region contextMenu TreeView
            if (ContextMenuControl ==sender && fileEvent == EventControl.Click)
            {
                var control = (ToolStripItemClickedEventArgs)evento;
                ToolStripItem item = control.ClickedItem;
                switch (item.Name)
                {
                    case "Eliminar":
                        try
                        {
                            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure you want to delete the directory?", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                await Task.Run(() => Directory.Delete(_currentNode.Tag.ToString()));
                                TreeControl.Load(FolderDialogControl.SelectedPath);
                            }
                       
                            
                        }
                        catch
                        {
                            MessageBox.Show("an error occurred while performing the operation, contact ipndeveloper. ");
                        }
                
                        break;
                    case "Copiar":
                    case "Cortar":
                        var operationMenu = (OperationMenu)Enum.Parse(typeof(OperationMenu), item.Name);
                        if (!Cache.ContainsKey("store"))
                            Cache.Add("store", new InfoCache { Node = _currentNode, Operation = operationMenu, Origin = OriginControl.TreeView });
                        else
                            Cache["store"] = new InfoCache { Node = _currentNode, Operation = operationMenu, Origin = OriginControl.TreeView };
                        break;
                    case "Pegar":
                        var cache = Cache.ElementAt(0);
                        var cacheValue = cache.Value;
                      
                        if (cacheValue.Origin == OriginControl.ListView)
                        {

                        }
                        else if(cacheValue.Origin == OriginControl.TreeView)
                        {
                            try
                            {
                                var _detinofile = Path.Combine(_currentNode.Tag.ToString(), cacheValue.Node.Text);
                                var _origen = new DirectoryInfo(cacheValue.Node.Tag.ToString());
                                var _destino = new DirectoryInfo(_detinofile);
                                if (Directory.Exists(_detinofile))
                                {
                                    _detinofile = Path.Combine(_currentNode.Tag.ToString(), string.Format("{0} Copy_{1}", cacheValue.Node.Text, Guid.NewGuid().ToString()));
                                    _destino = new DirectoryInfo(_detinofile);
                                }

                                if (_currentNode.FullPath.IndexOf(cacheValue.Node.FullPath) > -1)
                                {
                                    MessageBox.Show("The destination folder is the subfolder of the soure folder. ");
                                }
                                else
                                {
                                    await Task.Run(() => ParallelStaff.FileManager.Core.FileManager.Copy(_origen, _destino, cacheValue.Operation));
                                    Cache.Remove("store");
                                    TreeControl.Load(FolderDialogControl.SelectedPath);

                                }
                            }
                            catch
                            {
                                MessageBox.Show("an error occurred while performing the operation, contact ipndeveloper. ");
                            }
                     
 

                        }
                        break;
                }

            }
            if(ContextMenuControl == sender && fileEvent == EventControl.Opening)
            {
                if(Cache.ContainsKey("store"))
                    ContextMenuControl.Items[2].Enabled = true;
                else
                    ContextMenuControl.Items[2].Enabled = false;

            }
            #endregion
            #region Events TreeView
            if (TreeControl ==sender  && fileEvent == EventControl.DoubleClick)
            {
                var c = (TreeNodeMouseClickEventArgs)evento;
                TreeNode newSelected = c.Node;
                ListViewControl.Items.Clear();
                DirectoryInfo nodeDirInfo = new DirectoryInfo(newSelected.Tag.ToString());
                ListViewItem.ListViewSubItem[] subItems;
                ListViewItem item = null;
                try
                {
                    foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
                    {
                        item = new ListViewItem(dir.Name, 1);
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                    new ListViewItem.ListViewSubItem(item, "Directory"),new ListViewItem.ListViewSubItem(item,dir.LastAccessTime.ToShortDateString())
                        };
                        item.SubItems.AddRange(subItems);
                        ListViewControl.Items.Add(item);
                    }
                    foreach (FileInfo file in nodeDirInfo.GetFiles())
                    {
                        item = new ListViewItem(file.Name, 4);
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                    new ListViewItem.ListViewSubItem(item, "File"),new ListViewItem.ListViewSubItem(item,file.LastAccessTime.ToShortDateString())
                        };
                        item.SubItems.AddRange(subItems);
                        ListViewControl.Items.Add(item);
                    }
                    ListViewControl.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("You have no access to this folder!"); // 
                    return;
                }
            }
            if(TreeControl == sender && fileEvent == EventControl.ClickRigth)
            {
                var e = (TreeNodeMouseClickEventArgs)evento;
                TreeControl.SelectedNode = e.Node;
                _currentNode = e.Node;
                e.Node.ContextMenuStrip = ContextMenuControl;
            
            }
            #endregion
        }
    }
}
