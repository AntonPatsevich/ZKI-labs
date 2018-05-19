using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6
{
    public partial class Form1 : Form
    {
        private string fn = string.Empty;
        private bool docChanged = false;

        public Form1()
        {
            InitializeComponent();
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Text = string.Empty;
            this.Text = "NkEdit - Новый Документ";
            toolStrip1.Visible = true;
            

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "текст|*.txt";
            openFileDialog1.Title = "Открыть Документ";
            openFileDialog1.Multiselect = false;

            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "текст|*.txt";
            saveFileDialog1.Title = "Сохранить документ";
        }
        private void OpenDocument()
        {
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = openFileDialog1.FileName;
                this.Text = fn;
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fn);
                    textBox1.Text = sr.ReadToEnd();
                    textBox1.SelectionStart = textBox1.TextLength;
                    sr.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка доступ к файлу\n" + exc.ToString(), "NkEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private int SaveDocument()
        {
            int result = 0;
            if (fn == string.Empty)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fn = saveFileDialog1.FileName;
                    this.Text = fn;
                }
                else result = -1;
            }
            if (fn != string.Empty)
            {
                try
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fn);
                    System.IO.StreamWriter sw = fi.CreateText();
                    sw.Write(textBox1.Text);
                    sw.Close();
                    result = 0;

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "NkEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return result;
        }
        private void FileCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (docChanged)
            {
                DialogResult dr;
                dr = MessageBox.Show("Сохранить Изменения ?", "NkEdit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (SaveDocument() == 0)
                        {
                            textBox1.Clear();
                            docChanged = false;
                        }
                        break;
                    case DialogResult.No:
                        textBox1.Clear();
                        docChanged = false;
                        break;
                    case DialogResult.Cancel:
                        break;
                };
            }
        }
        private void FileOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = openFileDialog1.FileName;
                this.Text = fn;
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fn);
                    textBox1.Text = sr.ReadToEnd();
                    textBox1.SelectionStart = textBox1.TextLength;
                    sr.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка чтения файла.\n" + exc.ToString(), "MEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        private void FileSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }
        private void FileExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ParamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = !toolStrip1.Visible;
            //   ParamToolStripMenuItem.Checked = ! ParamToolStripMenuItem.Checked;
        }
        private void ParamFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                //  textBox1.Font = FontDialog1.Font;
            }

        }

        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {
            if (docChanged)
            {
                DialogResult dr;
                dr = MessageBox.Show("Сохранить Изменения ?", "NkEdit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (SaveDocument() == 0)
                        {
                            textBox1.Clear();
                            docChanged = false;
                        }
                        break;
                    case DialogResult.No:
                        textBox1.Clear();
                        docChanged = false;
                        break;
                    case DialogResult.Cancel:
                        break;
                };
            }
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = openFileDialog1.FileName;
                this.Text = fn;
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fn);
                    textBox1.Text = sr.ReadToEnd();
                    textBox1.SelectionStart = textBox1.TextLength;
                    sr.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка доступ к файлу\n" + exc.ToString(), "NkEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (fn == string.Empty)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fn = saveFileDialog1.FileName;
                    this.Text = fn;
                }
                else result = -1;
            }
            if (fn != string.Empty)
            {
                try
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fn);
                    System.IO.StreamWriter sw = fi.CreateText();
                    sw.Write(textBox1.Text);
                    sw.Close();
                    result = 0;

                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString(), "NkEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {
            Form2 about = new Form2();
            about.ShowDialog();
        }
    }
}