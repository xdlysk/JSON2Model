using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSON2Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Generate_Click(object sender, EventArgs e)
        {
            var cs = new CSharp();
            richTextBox2.Text = cs.Generate(richTextBox1.Text);
        }
    }
}
