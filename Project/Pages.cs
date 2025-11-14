using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Project
{
    public partial class Pages : Form
    {
        public List<Student> Students { get; set; }
        public int id;
        String text = "";
        public Pages()
        {
            Students = GetStudents();
            InitializeComponent();
        }


        private List<Student> GetStudents()
        {

            StreamReader read = new StreamReader("data.txt");//change back to data.txt
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
                    Assignment_Number_Or_Exam = rec.Value.Assignment_Number_Or_Exam,
                    Department = rec.Value.Department,
                    Term_Or_Semester = rec.Value.Term_Or_Semester,
                    Description_Violation = rec.Value.Description_Violation,
                    Faculty_Member_Name = rec.Value.Faculty_Member_Name,

                    Step_One_Date = rec.Value.Step_One_Date,
                    Recommendations_For_Sanction = rec.Value.Recommendations_For_Sanction,
                    Student_Advised_1 = rec.Value.Student_Advised_1,
                    Student_Advised_2 = rec.Value.Student_Advised_2,
                    Student_Name_Step2 = rec.Value.Student_Name_Step2,
                    MyTRU_Email = rec.Value.MyTRU_Email,
                    Step2_Date = rec.Value.Step2_Date,
                    Student_Agreement = rec.Value.Student_Agreement,
                    Student_Comments = rec.Value.Student_Comments,
                    Faculty_Member_Name_2 = rec.Value.Faculty_Member_Name_2,
                    Date_Step3 = rec.Value.Date_Step3,
                    Department_Chair_Name = rec.Value.Department_Chair_Name,
                    Agree_Step4 = rec.Value.Agree_Step4,
                    Comments_Step4 = rec.Value.Comments_Step4,
                    If_Agree_No_Explain_Step4 = rec.Value.If_Agree_No_Explain_Step4,
                    Date_Step4 = rec.Value.Date_Step4,
                    Dean_Name = rec.Value.Dean_Name,
                    Agree_Step5 = rec.Value.Agree_Step5,
                    Comments_Step5 = rec.Value.Comments_Step5,
                    If_Agree_No_Explain_Step5 = rec.Value.If_Agree_No_Explain_Step5,
                    Step5_Date = rec.Value.Step5_Date,
                    Faculty_Comments = rec.Value.Faculty_Comments,
                    Student_Comments_Page5 = rec.Value.Student_Comments_Page5,
                    OSA_Use_Only = rec.Value.OSA_Use_Only

                });
            }
            

            
            return list;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var students = this.Students;
            dataGridView1.DataSource = students;
            int last = dataGridView1.ColumnCount - 1;
            DataGridViewCellStyle specificCellStyle = new DataGridViewCellStyle();
            specificCellStyle.BackColor = System.Drawing.Color.FromArgb(150,0,10);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                row.Cells[last].Style.ApplyStyle(specificCellStyle);

            }
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

        public Boolean run(String args)
        {
            string pythonPath = @"C:\Users\Jp\AppData\Local\Programs\Python\Python313\python.exe";//change this l8r
            string scriptPath = "ProjectRevamp.py"; 

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pythonPath;
            start.Arguments = $"{scriptPath} {args} --output";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            start.CreateNoWindow = true;
            String res;
            using (Process pro = Process.Start(start))
            {
                string result = pro.StandardOutput.ReadToEnd();
                Console.WriteLine("result"+ result);
                res = result;
                string err = pro.StandardError.ReadToEnd();
                Console.WriteLine(result);
                Console.WriteLine("errr"+err);
            }
            //Console.ReadKey();
            Console.WriteLine("result", res);
            if (res.Trim() == "OK" )
            {
                Console.WriteLine("INNN");
                this.Students = GetStudents();//or i could just edit student object directly( would be faster)
                dataGridView1.DataSource = this.Students;
                return true;
                
            }
            else
            {
                return false;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.ColumnIndex);
            


            if (e.ColumnIndex == 9)
            {
                String ID = dataGridView1.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].FormattedValue.ToString();
                Console.WriteLine("DELETE");
                Console.WriteLine(this.run($"delete {ID}"));

            }

        }

        private void config()
        {
            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = 10;


        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.BackColor = System.Drawing.Color.FromArgb(0, 152, 254);
            button11.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 102, 204);
            
            
            button11.Size  = new Size(50, 30);
            button11.Location = new Point(button11.Location.X, button11.Location.Y-5);

            button10.BackColor = SystemColors.Control;
            button10.FlatStyle = FlatStyle.Standard;
            button10.Size = new Size(40, 20);
            button10.Location = new Point(19, 92);

            groupBox1.Text = "Edit";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.BackColor = System.Drawing.Color.FromArgb(0, 152, 254);
            button10.FlatStyle = FlatStyle.Flat;
            button10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 102, 204);
            button10.Size = new Size(50, 30);
            button10.Location = new Point(10, 87);

            button11.BackColor = SystemColors.Control;
            button11.FlatStyle = FlatStyle.Standard;
            button11.Size = new Size(40, 20);
            button11.Location = new Point(button11.Location.X, button11.Location.Y + 5);
            //button11.Location = new Point(button11.Location.X, button11.Location.Y - 15);

            groupBox1.Text = "Add";
            


        }

        private void inflate(string name , string info , Boolean file= false , Boolean disable = false)
        {
            if (file)
            {
                RichTextBox tbx = this.Controls.Find(name, true).FirstOrDefault() as RichTextBox;
                if (tbx != null)
                {
                    
                    this.text += $"('{name}','{tbx.Text}'),";
                }
                

            }
            else
            {
                //Console.WriteLine("tbx: " + name+" "+info);
                //Control tbx1 = this.Controls.Find("Student_Name", true).FirstOrDefault();
                RichTextBox tbx = this.Controls.Find(name, true).FirstOrDefault() as RichTextBox;
                //Console.WriteLine("tbx: " + tbx);
                if (name == "Student_Advised_1")
                {
                    if (info == "true")
                    {
                        button4.Text = "✅";
                    }
                    else
                    {
                        button4.Text = "";
                    }
                }else if(name == "Student_Advised_2")
                {
                    if (info == "true")
                    {
                        button5.Text = "✅";
                    }
                    else
                    {
                        button5.Text = "";
                    }
                }
                //Console.WriteLine("tbx1: " + tbx1);
                if (tbx != null)
                {
                    tbx.Text = info;
                    if (disable)
                    {
                        tbx.Enabled = false;
                    }
                    else
                    {
                        tbx.Enabled = true;

                    }


                }
            }
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var students = this.Students;
            
            foreach (var rec in students)
            {
                if (this.id == int.Parse(rec.id))
                {
                    foreach (var attr in rec.GetType().GetProperties())
                    {
                        if (checkBox1.Checked)
                        {
                            this.inflate(attr.Name, attr.GetValue(rec, null).ToString());
                        }
                        else
                        {
                            this.inflate(attr.Name, attr.GetValue(rec, null).ToString(),false,true);
                        }
                            

                    }

                }
            }
            
            
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            tabControl1.SelectedTab = tabPage1;
            //Console.WriteLine(dataGridView1.Columns[e.ColumnIndex]);
            var students = this.Students;
            foreach (var rec in students)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].FormattedValue.ToString() == rec.id)
                {
                    this.id = int.Parse(rec.id);
                    foreach (var attr in rec.GetType().GetProperties())
                    {
                        this.inflate(attr.Name, attr.GetValue(rec, null).ToString(),false,true);
                        //Console.WriteLine(attr.Name);
                        //Console.WriteLine(attr.GetValue(rec, null).ToString());
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

        private void update(String type)
        {
            Console.WriteLine("ID" + this.id);
            var students = this.Students;
            var id = this.id;
            this.text = "[";
            StreamWriter writer = new StreamWriter("update.txt");

            foreach (var rec in students)
            {
                if (id == int.Parse(rec.id)) // I actually dont have to make id a int, id doesnt have to be an int throught out but i feel like it's better if i follow the canonical way of initializing ids
                {
                    foreach (var attr in rec.GetType().GetProperties())
                    {
                        this.inflate(attr.Name, attr.GetValue(rec, null).ToString(), true);
                    }

                }
            }

            // Huh... forgot that changes do not directly reflect the Student class
            //foreach (var rec in students)
            //{
            //    if (id == int.Parse(rec.id)) // I actually dont have to make id a int, id doesnt have to be an int throught out but i feel like it's better if i follow the canonical way of initializing ids
            //    {
            //        foreach (var attr in rec.GetType().GetProperties())
            //        {
            //            text += $"'{attr.Name}','{attr.GetValue(rec, null).ToString()}'";
            //        }

            //    }
            //}
            this.text += "]";
            writer.WriteLine(text);
            writer.Close();
            Console.WriteLine(text);
            //String text = richTextBox2.Text;
            //StreamWriter write = new StreamWriter("update.txt");
            //write.WriteLine(text);
            //write.Close();
            Console.WriteLine(this.run($"{type} {id} -o -i \"{text}\" "));
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (groupBox1.Text == "Add")
                this.update("add");

            if (groupBox1.Text == "Edit")
                this.update("edit");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var students = this.Students;
            foreach (var rec in students)
            {
                    this.id = int.Parse(rec.id);
                    foreach (var attr in rec.GetType().GetProperties())
                    {
                        this.inflate(attr.Name, "");
                        //Console.WriteLine(attr.Name);
                        //Console.WriteLine(attr.GetValue(rec, null).ToString());
                    }

            }
        }

        private void Student_Number_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if(groupBox1.Text == "Add")
            {
                button11.Text = "Edit";
                button11.BackColor = Color.CornflowerBlue;
                //button11.FlatStyle = FlatStyle.Flat;
                button11.FlatAppearance.BorderColor = Color.Blue;


                //button11.Size = new Size(50, 30);
                //button11.Location = new Point(button11.Location.X, button11.Location.Y - 5);

                //button10.BackColor = SystemColors.Control;
                //button10.FlatStyle = FlatStyle.Standard;
                //button10.Size = new Size(40, 20);
                //button10.Location = new Point(19, 92);
                groupBox1.Text = "Edit";
            }
            else
            {
                button11.Text = "Add";
                button11.BackColor = Color.Lime;
                //button11.FlatStyle = FlatStyle.Flat;
                button11.FlatAppearance.BorderColor = Color.DarkGreen;


                //button11.Size = new Size(50, 30);
                //button11.Location = new Point(button11.Location.X, button11.Location.Y - 5);

                //button10.BackColor = SystemColors.Control;
                //button10.FlatStyle = FlatStyle.Standard;
                //button10.Size = new Size(40, 20);
                //button10.Location = new Point(19, 92);
                groupBox1.Text = "Add";

            }
            

            
        }
    }
}
