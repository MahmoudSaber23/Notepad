using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class frmNotepad : Form
    {
        public frmNotepad()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(rtxtNotepad.Text))
            {
               if(MessageBox.Show("Are You Sure That You Want New Text? ", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    rtxtNotepad.Clear();
                }
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter= "Text Files (*.txt)|*.txt|All Files (*.*) |*.*";

            if(OpenFile.ShowDialog() == DialogResult.OK)
            {
                rtxtNotepad.Text = System.IO.File.ReadAllText(OpenFile.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Filter = "Text Files (*.txt)|*.txt|All Files (*.*) |*.*";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(SaveFile.FileName, rtxtNotepad.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           rtxtNotepad.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.SelectedText =DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog Font=new FontDialog();

            if(Font.ShowDialog()==DialogResult.OK)
            {
                rtxtNotepad.Font = Font.Font;
            }

        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.WordWrap = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtNotepad.WordWrap = false;
        
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad Application\nVersion 1.0\nDeveloped by: Fury", "About Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rtxtNotepad_TextChanged(object sender, EventArgs e)
        {
            Charcounter.Text=rtxtNotepad.Text.Length.ToString();
        }

        private void foreColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                rtxtNotepad.ForeColor = color.Color;
            }

        }
    }
}
