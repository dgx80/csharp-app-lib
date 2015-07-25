﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLib.Components
{
    public class ProjectMenuStrip
    {
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Form m_form;
        private ApplicationManager m_applicationManager;
        private string m_sProjectFileExtension;

        public ProjectMenuStrip(
            ApplicationManager applicationManager,
            System.Windows.Forms.Form form,
            System.Windows.Forms.MenuStrip menuStrip,
            string sProjectFileExtension
            ) 
        {
            m_applicationManager = applicationManager;
            m_form = form;
            m_sProjectFileExtension = sProjectFileExtension;
            this.menuStrip1 = menuStrip;
            m_form.ResumeLayout(true);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(963, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";

            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";

            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&new";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "&quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);

            m_form.Controls.Add(this.menuStrip1);
            m_form.MainMenuStrip = this.menuStrip1;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            m_form.ResumeLayout(false);
            m_form.PerformLayout();
            this.menuStrip1.Show();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = m_applicationManager.CURRENT_PROJECT_NAME;
            string sDirectory = "";
            if (s != "")
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(s);
                if (System.IO.Directory.Exists(fileInfo.DirectoryName))
                {
                    sDirectory = fileInfo.DirectoryName;
                }
            }
            m_applicationManager.onNewProjectFile(s);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void getCurrentDirectory()
        {
            string s = m_applicationManager.CURRENT_PROJECT_NAME;
            string sDirectory = "";
            if (s != "")
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(s);
                if (System.IO.Directory.Exists(fileInfo.DirectoryName))
                {
                    sDirectory = fileInfo.DirectoryName;
                }
            }
        }
    }
}