using Microsoft.Win32;
using Newtonsoft.Json;
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

namespace Project
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }


        // Passeord Visiblity logic
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "")
            {
                button2.BackgroundImage = Image.FromFile("eye1.png");
                button2.Text = " ";
                textBox2.PasswordChar = '\0';// For some reason to reset the view a binary 0 is given, blame the docs not mee
                textBox2.Focus();
            }
            else
            {
                button2.BackgroundImage = Image.FromFile("eye2.png");
                button2.Text = "";
                textBox2.PasswordChar = '•';
                textBox2.Focus();
            }
            
        }

        //Authentication logic .... Pretty Straight Forward
        private void button1_Click(object sender, EventArgs e)
        {
            //Pages page = new Pages();// This might be a problem( resource wise ) on top of here cuz if someone inputs a wrong password this object is created nonetheless
            StreamWriter write = new StreamWriter("sess.txt",false);
            string username = textBox1.Text;
            string password = textBox2.Text;
            Boolean loggedIn = false; // Just for the pseudo accounts to work
            StreamReader read = new StreamReader("accounts.txt");//change back to data.txt
            String Textdata = read.ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<Dictionary<string,string>>>(Textdata);
            foreach ( var acc in data )
            {
                Console.WriteLine(acc);
                Console.WriteLine(username);
                Console.WriteLine(password);
                if (username == acc["id"])
                {
                    if (password == acc["password"])
                    {
                        MessageBox.Show("Correct!");
                        if (acc["Acc_type"] == "student")
                        {
                            
                            
                            
                            Pages page = new Pages(acc["Acc_type"], acc["id"], acc["name"]);
                            page.Show();
                            
                            
                            
                            
                        }
                        else
                        {
                           
                            Pages page = new Pages(acc["Acc_type"], acc["id"], acc["name"]);
                            page.Show();
                        }
                        write.WriteLine(acc["Acc_type"]);
                        write.WriteLine(acc["id"]);
                        write.WriteLine(acc["name"]);
                        write.Close();
                        loggedIn = true;
                    }
                        
                    else
                        MessageBox.Show("Nope");
                }
            }
            read.Close();
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Username Empty!");
            }else if (textBox2.Text == "")
            {
                MessageBox.Show("Incorrect Password!");
            }
            if (!loggedIn)
            {
                if (textBox1.Text[0] == 'P')
                {
                    Pages page = new Pages("admin", username);
                    page.Show();
                    write.WriteLine("admin");
                    write.WriteLine(username);
                    write.Close();

                }
                else if (textBox1.Text[0] == 't')
                {

                    Pages page = new Pages("student", username);
                    page.Show();
                    write.WriteLine("student");
                    write.WriteLine(username);
                    write.Close();
                }

                MessageBox.Show("Wrong Credentials");
                write.Close();
            }
            



        }
    }
}
