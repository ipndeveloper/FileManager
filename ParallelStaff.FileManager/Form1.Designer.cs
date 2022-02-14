
using ParallelStaff.FileManager.Customs.Controls;
using ParallelStaff.FileManager.Customs.Controls.ContextMenu;
using ParallelStaff.FileManager.Mediator;
using System.Windows.Forms;

namespace ParallelStaff.FileManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            //this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Copiar = new System.Windows.Forms.ToolStripMenuItem();
            this.Cortar = new System.Windows.Forms.ToolStripMenuItem();
            this.Pegar = new System.Windows.Forms.ToolStripMenuItem();
            this.Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 23);
            this.textBox1.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(407, 46);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(609, 392);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copiar,
            this.Cortar,
            this.Pegar,
            this.Eliminar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 70);
            // 
            // Copiar
            // 
            this.Copiar.Name = "Copiar";
            this.Copiar.Size = new System.Drawing.Size(109, 22);
            this.Copiar.Text = "Copiar";
            // 
            // Cortar
            // 
            this.Cortar.Name = "Cortar";
            this.Cortar.Size = new System.Drawing.Size(109, 22);
            this.Cortar.Text = "Cortar";
            // 
            // Pegar
            // 
            this.Pegar.Name = "Pegar";
            this.Pegar.Size = new System.Drawing.Size(109, 22);
            this.Pegar.Text = "Pegar";
            // 
            // Pegar
            // 
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(109, 22);
            this.Eliminar.Text = "Eliminar";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 450);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        //private System.Windows.Forms.TreeView treeView1;
        //private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        //private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    
        private System.Windows.Forms.ToolStripMenuItem Copiar;
        private System.Windows.Forms.ToolStripMenuItem Cortar;
        private System.Windows.Forms.ToolStripMenuItem Pegar;
        private System.Windows.Forms.ToolStripMenuItem Eliminar;
        private FileTreeView treeView1;
        private FileButton button1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;

        private FileContextMenuStrip contextMenuStrip1;
        //private System.Windows.Forms.TreeView treeView1;
        //private System.Windows.Forms.Button button1;
        //   private System.Windows.Forms.Button button1;
    }
}

