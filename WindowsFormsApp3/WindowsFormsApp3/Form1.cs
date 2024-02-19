using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public string filename;
        public bool isFileChange;

        public Form1()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            filename = "";
            isFileChange = false;
        }

        public void CreateNewDocument(object sender, EventArgs e) 
        {
            textBox1.Text = "";
            filename = "";
        }

        public void OpenFile(object sender, EventArgs e) 
        {
            openFileDialog1.FileName = "";
            if(openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog1.FileName;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл");
                }
            }
        }

        public void SaveFile(string filename1) 
        {
            if (filename1 == "")
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename1 = saveFileDialog1.FileName;
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter(filename1);
                sw.Write(textBox1.Text);
                sw.Close();
                filename = filename1;
                isFileChange = false;
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить файл");
            }
        }

        public void Save(object sender, EventArgs e)
        {
            SaveFile(filename);
        }

        
    }
}
