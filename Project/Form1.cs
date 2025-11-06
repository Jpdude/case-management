using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox2.Text;
            String password = textBox1.Text;

            if (username == "johnpaulnjepu08@gmail.com" && password == "poop")
            {

                MessageBox.Show("You good gang");

                //Form newForm = new Pages();
                //newForm.Show();
            }
            else
            {
                MessageBox.Show("Brotha ur crendtials aint it");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
