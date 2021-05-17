using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab3
{
    public partial class Form1 : Form
    {
        List<string> _valid;
        List<string> _notValid;

        public Form1()
        {
            InitializeComponent();

            _valid = new List<string>();
            _notValid = new List<string>();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (IsEmptyTextBox1()&& !IsValidPath(textBox1.Text))
            {
                MessageBox.Show("Пустая строка!","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            

        }

        private bool IsEmptyTextBox1() => textBox1.Text.Trim().Length == 0 ? true : false;

        private bool IsValidPath(string s)
        {
            s = s.TrimEnd().TrimStart();
            if ( s.Length > 260)
            {
                 return false;
            }
            if (!Path.IsPathRooted(s))
            {
                return false;
            }

            char[] gipc = Path.GetInvalidPathChars();

            for (int i = 0; i < gipc.Length; i++)
            {
                for (int d = 0; d < s.Length; i++)
                {
                    if( gipc[i] == s[d])
                    {
                        return false;
                    }
                }
            }
            string name = Path.GetFileName(s);
            char[] gifnc = Path.GetInvalidFileNameChars();

            for (int i = 0; i < gifnc.Length; i++)
            {
                for (int d = 0; d < name.Length; i++)
                {
                    if (gifnc[i] == name[d])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
