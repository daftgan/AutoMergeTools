using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMergeTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonChooseSolution_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                textBoxProject.Text = opf.FileName;
            }
        }

        private void buttonChooseOutputFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog opf = new SaveFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                textBoxOutput.Text = opf.FileName;
            }
        }

        private void buttonProcessStart_Click(object sender, EventArgs e)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            watcher.Path = Path.GetDirectoryName(textBoxProject.Text);
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
            watcher.Filter = "*.cs";
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Changed;
            watcher.Deleted += Watcher_Changed;
            watcher.Renamed += Watcher_Changed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;
            buttonProcessStart.Enabled = false;

        }

        private void Watcher_Changed(object sender, EventArgs e)
        {
            AutoMergeUtilities.MergeSourceFile(textBoxProject.Text, textBoxOutput.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.OutputFilePath = textBoxOutput.Text;
            Properties.Settings.Default.ProjectPath = textBoxProject.Text;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxOutput.Text = Properties.Settings.Default.OutputFilePath;
            textBoxProject.Text = Properties.Settings.Default.ProjectPath;
        }
    }
}
