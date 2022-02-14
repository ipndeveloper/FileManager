using ParallelStaff.FileManager.Customs.Controls;
using ParallelStaff.FileManager.Customs.Controls.ContextMenu;
using ParallelStaff.FileManager.Mediator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelStaff.FileManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();
            InitializeComponent1();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void InitializeComponent1()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();

            this.Copiar = new System.Windows.Forms.ToolStripMenuItem();
            this.Cortar = new System.Windows.Forms.ToolStripMenuItem();
            this.Pegar = new System.Windows.Forms.ToolStripMenuItem();
            this.Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();

            Controller controller = new Controller();
            this.treeView1 = new FileTreeView(controller);

            this.button1 = new FileButton(controller);

            this.contextMenuStrip1 = new FileContextMenuStrip(controller, this.components);
            controller.BtnControl = this.button1;
            controller.FolderDialogControl = this.folderBrowserDialog1;
            controller.TreeControl = this.treeView1;
            controller.ListViewControl = this.listView1;
            controller.ContextMenuControl = this.contextMenuStrip1;
            controller.TxtControl = this.textBox1;
            this.button1.Text = "Explorer";

            listView1.View = View.Details;
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 23);
            this.textBox1.TabIndex = 2;
            // 
            // listView1
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
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(407, 46);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(609, 392);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;

            this.columnHeader1.Text = "Name";
            this.columnHeader2.Text = "Type";
            this.columnHeader3.Text = "Date";
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
            // eliminar
            // 
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(109, 22);
            this.Eliminar.Text = "Eliminar";
            //
            this.Pegar.Name = "Pegar";
            this.Pegar.Size = new System.Drawing.Size(109, 22);
            this.Pegar.Text = "Pegar";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 41);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(313, 397);
            this.treeView1.TabIndex = 4;
            // 
            // button1
            // 

            this.button1.Location = new System.Drawing.Point(331, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Open Directory";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 450);
            this.textBox1.Enabled = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "File Manager - developed by ipndeveloper.";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
