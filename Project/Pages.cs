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
using Newtonsoft.Json;

namespace Project
{
    public partial class Pages : Form
    {
        public List<Student> Students { get; set; }
        public Pages()
        {
            Students = GetStudents();
            InitializeComponent();
        }


        private List<Student> GetStudents()
        {

            StreamReader read = new StreamReader("data.txt");
            String Textdata = read.ReadToEnd();
           
            var studentRecords = JsonConvert.DeserializeObject<Dictionary<string, Student>>(Textdata);
            read.Close();


            var list = new List<Student>();
            foreach (var rec in studentRecords)
            {
                //Console.WriteLine(rec.Value.Student_Name);
                list.Add(new Student()
                {
                    id = rec.Key,
                    Student_Name = rec.Value.Student_Name,
                    Student_Number = rec.Value.Student_Number,
                    Student_Email = rec.Value.Student_Email,
                    Course_Name_Number = rec.Value.Course_Name_Number,
                   
                    Department = rec.Value.Department,
                    Term_Or_Semester = rec.Value.Term_Or_Semester,
                    Description_Violation = rec.Value.Description_Violation,
                    Faculty_Member_Name = rec.Value.Faculty_Member_Name,
                    
                });
            }
            

            
            return list;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var students = this.Students;
            dataGridView1.DataSource = students;
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader("data.txt");
            String Textdata = read.ReadToEnd();
            var studentRecords = JsonConvert.DeserializeObject<Dictionary<string, Student>>(Textdata);
            
            read.Close();
            JsonConvert.DeserializeObject(Textdata);
            //richTextBox18.Text = Textdata;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader("C:\\Users\\T00749160\\OneDrive - Thompson Rivers University\\Documents\\Project\\Project\\obj\\Debug\\new 1.txt");
            String Textdata = read.ReadLine();
            read.Close();
            richTextBox2.Text = Textdata;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String text = richTextBox2.Text;
            StreamWriter write = new StreamWriter("C:\\Users\\T00749160\\OneDrive - Thompson Rivers University\\Documents\\Project\\Project\\obj\\Debug\\new 1.txt");
            write.WriteLine(text);
            write.Close();
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.ColumnIndex);
            if (e.ColumnIndex == 9)
            {
                Console.WriteLine("DELETE");
                //Delete

            }

        }

        private void config()
        {
            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = 10;


        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.BackColor = SystemColors.HotTrack;
            button11.FlatStyle = FlatStyle.Popup;

            button10.BackColor = SystemColors.Control;
            button10.FlatStyle = FlatStyle.Standard;
            
            groupBox1.Text = "Edit";
            checkBox1.Text = "Allow Edit";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.BackColor = SystemColors.HotTrack;
            button10.FlatStyle = FlatStyle.Popup;

            button11.BackColor = SystemColors.Control;
            button11.FlatStyle = FlatStyle.Standard;

            groupBox1.Text = "Add";
            checkBox1.Text = "Auto Save";


        }

        private void inflate(string name , string info)
        {
            //Console.WriteLine("tbx: " + name+" "+info);
            //Control tbx1 = this.Controls.Find("Student_Name", true).FirstOrDefault();
            RichTextBox tbx = this.Controls.Find(name, true).FirstOrDefault() as RichTextBox;
            Console.WriteLine("tbx: "+tbx);
            
            //Console.WriteLine("tbx1: " + tbx1);
            if (tbx != null)
            {
                tbx.Text = info;
                tbx.Enabled = false;

            }
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            //Console.WriteLine(dataGridView1.Columns[e.ColumnIndex]);
            var students = this.Students;
            foreach (var rec in students)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].FormattedValue.ToString() == rec.id)
                {
                    foreach (var attr in rec.GetType().GetProperties())
                    {
                        this.inflate(attr.Name, attr.GetValue(rec, null).ToString());
                        Console.WriteLine(attr.Name);
                        Console.WriteLine(attr.GetValue(rec, null).ToString());
                    }

                }
            }

        }

        private void richTextBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "✅")
            {
                button4.Text = "";
            }
            else
            {
                button4.Text = "✅";
            }
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "✅")
            {
                button5.Text = "";
            }
            else
            {
                button5.Text = "✅";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
