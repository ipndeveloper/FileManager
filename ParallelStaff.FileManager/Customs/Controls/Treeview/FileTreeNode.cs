using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParallelStaff.FileManager.Customs.Controls.Treeview
{
    public class FileTreeNode : TreeNode
    {
        private readonly string _path;

        private readonly bool _isFile;

        public FileTreeNode(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException(nameof(path));
            Text = Path.GetFileName(path);
            Tag = path;
            _isFile = File.Exists(path);
            _path = path;

            if (!_isFile && Directory.EnumerateFileSystemEntries(_path).Any())
            {
                var node = new TreeNode();
                Nodes.Add(node);
              
            }
            SetIcon();
        }

        public void SetIcon()
        {
            ImageIndex = _isFile ? ImageIndex = 1 : IsExpanded ? 2 : 0;
            SelectedImageIndex = _isFile ? ImageIndex = 1 : IsExpanded ? 2 : 0;
        }

        private IEnumerable<string> _children;
        public void LoadNodes()
        {
            if (!_isFile && _children == null)
            {
                _children = Directory.EnumerateDirectories(_path).ToList();
                //((List<string>)_children).AddRange(Directory.EnumerateFiles(_path));

                Nodes.Clear();

                Nodes.AddRange(
                    _children.Select(x =>
                        (TreeNode)new FileTreeNode(x))
                        .ToArray());
            }
        }
    }
}
