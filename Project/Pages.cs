using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Project
{
    public partial class Pages : Form
    {
        public List<Student> Students { get; set; }
        public int id;
        public Color modify_clr = Color.LightGray;
        public Button curr_form;
        public Pages()
        {
            Students = GetStudents();
            InitializeComponent();
            curr_form = Form1;
            this.KeyPreview = true;
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

                    Step_One_Date_1 = rec.Value.Step_One_Date_1,

                    Faculty_Member_Name_1 = rec.Value.Faculty_Member_Name_1,
                    Step_One_Date = rec.Value.Step_One_Date,
                    
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
                 
                    OSA_Use_Only = rec.Value.OSA_Use_Only

                });
            }
            

            
            return list;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.AutoScroll = true;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            var students = this.Students;
            dataGridView1.DataSource = students;
            int last = dataGridView1.ColumnCount - 1;
            DataGridViewCellStyle specificCellStyle = new DataGridViewCellStyle();
            specificCellStyle.BackColor = System.Drawing.Color.FromArgb(150,0,10);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                row.Cells[last].Style.ApplyStyle(specificCellStyle);

            }
            treeView1.Nodes.Add("Form1");
            treeView1.Nodes.Add("Form2");
            treeView1.Nodes.Add("Form3");
            treeView1.Nodes.Add("Form4");
            treeView1.Nodes.Add("Form5");
            treeView1.Nodes.Add("Form6");
            treeView1.Nodes.Add("Form7");
            int i;
            Console.WriteLine("Hkh");
            //Recursion is never a good idea but fk it we balll
            foreach ( Control ctrl in panel0.Controls)
            {
                //Console.WriteLine("Not txt"+ctrl.Text);
                Console.WriteLine("Type: " + ctrl.GetType().Name);
                if (ctrl.GetType().Name == "TableLayoutPanel" || ctrl.GetType().Name == "ListBox")
                {
                    
                    
                    foreach (Control panel in ctrl.Controls)
                    {
                        //Console.WriteLine("Not txt" + panel.GetType().Name);
                        if (panel.GetType().Name == "FlowLayoutPanel")
                        {
                            foreach (Control lbl in panel.Controls)
                            {
                                //Console.WriteLine("Bruh" + lbl.GetType().Name);
                                if (lbl.GetType().Name == "Label")
                                {
                                    Console.WriteLine("Not txt" + lbl.Text);
                                }
                            }
                        }
                    }
                }
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
            //StreamReader read = new StreamReader("C:\\Users\\T00749160\\OneDrive - Thompson Rivers University\\Documents\\Project\\Project\\obj\\Debug\\new 1.txt");
            //String Textdata = read.ReadLine();
            //read.Close();
            //richTextBox2.Text = Textdata;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //String text = richTextBox2.Text;
            //StreamWriter write = new StreamWriter("C:\\Users\\T00749160\\OneDrive - Thompson Rivers University\\Documents\\Project\\Project\\obj\\Debug\\new 1.txt");
            //write.WriteLine(text);
            //write.Close();
            
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
            //string pythonPath = @"C:\Users\Jp\AppData\Local\Programs\Python\Python313\python.exe";//change this l8r
            string pythonPath = @"py";
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
                //Console.WriteLine("result"+ result);
                res = result;
                string err = pro.StandardError.ReadToEnd();
                //Console.WriteLine(result);
                //Console.WriteLine("errr"+err);
            }
            //Console.ReadKey();
            //Console.WriteLine("result", res);
            if (res.Trim() == "OK" )
            {
                //Console.WriteLine("INNN");
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
            //Console.WriteLine(e.ColumnIndex);
            


            if (e.ColumnIndex == 9)
            {
                String ID = dataGridView1.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].FormattedValue.ToString();
                //Console.WriteLine("DELETE");
                //Console.WriteLine(this.run($"delete {ID}"));

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

        public String checkBoxes(String first , String second , Boolean adv = false)
        {
            if (adv)
            {
                if (first == "✅")
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                if (first == "" && second == "")
                {

                    return "";
                }
                else if (first == "✅")
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            
            
        }
        private void inflate(string name , string info , Boolean file= false , Boolean disable = false)
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
                
            }
            else if(name == "Student_Advised_2")
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

            if (name == "Student_Agreement")
            {
                if (info == "true")
                {
                    Review_Yes.Text = "✅";
                    Review_No.Text = "";
                }
                else
                {
                    Review_No.Text = "✅";
                    Review_Yes.Text = "";
                }
            }
                

            if (name == "Agree_Step4")
            {
                if (info == "true")
                {
                    button_dept_y.Text = "✅";
                }
                else
                {
                    button_dept_n.Text = "✅";
                }
            }

            if (name == "Agree_Step5")
            {
                if (info == "true")
                {
                    dean_y.Text = "✅";
                }
                else
                {
                    dean_n.Text = "✅";
                }
            }
            if (disable)
            {
                
                button4.Enabled = false;
                button5.Enabled = false;
                Review_Yes.Enabled = false;
                Review_No.Enabled = false;
                button_dept_y.Enabled = false;
                button_dept_n.Enabled = false;
                dean_y.Enabled = false;
                dean_n.Enabled = false;

                button11.Enabled = false;
                button10.Enabled = false;
                modify_clr = Color.LightGray;

                // Did this to reset the colors
                //button19.PerformClick();
                //button20.PerformClick(); // Abort this causes weird problems and lag

                // Choose the lazy route and made a global variable instead 
                curr_form.BackColor = modify_clr;


                button9.Enabled = false;
                button8.Enabled = false;

                button11.BackColor = Color.LightGray;
                //button11.FlatStyle = FlatStyle.Flat;
                button11.FlatAppearance.BorderColor = Color.DarkGray;
            }
            else
            {
                button4.Enabled = true;
                button5.Enabled = true;
                Review_Yes.Enabled = true;
                Review_No.Enabled = true;
                button_dept_y.Enabled = true;
                button_dept_n.Enabled = true;
                dean_y.Enabled = true;
                dean_n.Enabled = true;

                button11.Enabled = true;
                button10.Enabled = true;
                


                button9.Enabled = true;
                button8.Enabled = true;

                //Changing the color of the Add/Edit to original calling this twice will set the color apportiately instead of me having to check and set the color myself
                button10.PerformClick();
                button10.PerformClick();
                





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
            tabControl1.SelectedTab = tabPage4;
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

        public void changeBtn( Button mainBtn , Button subBtn)
        {
            if ( subBtn.Text == "✅")
            {
                subBtn.Text = "";
            }
            if (mainBtn.Text == "✅")
            {
                mainBtn.Text = "";
            }
            else
            {
                mainBtn.Text = "✅";
            }


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
            String text = "[";
            String t = "";
            Boolean d = false;
            StreamWriter writer = new StreamWriter("update.txt");

            foreach (var rec in students)
            {
                if (id == int.Parse(rec.id)) // I actually dont have to make id a int, id doesnt have to be an int throught out but i feel like it's better if i follow the canonical way of initializing ids
                {
                    foreach (var attr in rec.GetType().GetProperties())
                    {
                        RichTextBox tbx = this.Controls.Find(attr.Name, true).FirstOrDefault() as RichTextBox;

                        
                        
                        if (tbx != null || attr.Name == "Student_Agreement" || attr.Name == "Agree_Step4" || attr.Name == "Agree_Step5" || attr.Name == "Student_Advised_1" || attr.Name == "Student_Advised_2")
                        {
                            if (attr.Name == "Student_Agreement")
                            {
                                t = checkBoxes(Review_Yes.Text, Review_No.Text);
                            }
                            else if (attr.Name == "Agree_Step4")
                            {
                                t = checkBoxes(button_dept_y.Text, button_dept_n.Text);
                            }

                            else if (attr.Name == "Agree_Step5")
                            {
                                t = checkBoxes( dean_y.Text, dean_n.Text);
                            }
                            else if (attr.Name == "student_advised_1")
                            {
                                t = checkBoxes(button4.Text,"",true);
                            }
                            else if (attr.Name == "student_advised_2")
                            {
                                t = checkBoxes(button5.Text, "",true);
                            }
                            if (tbx != null)
                                t = tbx.Text;
                            text += $"('{attr.Name}','{t}'),";

                            if (t == "")
                                d = true;
                        }
                        //this.inflate(attr.Name, attr.GetValue(rec, null).ToString(), true);
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
            text += "]";
            

                writer.WriteLine(text);
            writer.Close();
            //Console.WriteLine(text);
            //String text = richTextBox2.Text;
            //StreamWriter write = new StreamWriter("update.txt");
            //write.WriteLine(text);
            //write.Close();
            
            if (d)
            {
                DialogResult result = MessageBox.Show("You may be missing some info, Do you wish to coutinue?",
                                             "Exit Confirmation",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    
                }
                else
                {
                    type = "non";
                }
            }
            
                
                
            Console.WriteLine(this.run($"{type} {id} -o -i \"{text}\" "));
            tabControl1.SelectedTab = tabPage3;
            checkBox1.Checked = false;
            if (type != "non")
                MessageBox.Show("Data Sucessfully Saved!.");
            

        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (groupBox1.Text == "Add")
                    this.update("add");

                else if (groupBox1.Text == "Edit")
                    this.update("edit");
            }
            else
            {
                MessageBox.Show("Please make sure you have enabled the operation before saving");
            }


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
                modify_clr = Color.Blue;


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
                modify_clr = Color.Lime;
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
            curr_form.BackColor = modify_clr;



        }

        private void button15_Click(object sender, EventArgs e)
        {
            //panel3.Visible = false;
            //panel3.Size = new Size(0,0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            //panel3.Visible = true;
        }

        private void change( Button form , Panel panel)
        {
            
            panel1.AutoScroll = false;
            panel0.AutoScroll = false;
            panel0.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            Console.WriteLine(panel.ToString());
            panel.Visible = true;
            //panel.BringToFront();

            Form1.BackColor = Color.LightSkyBlue;
            Form2.BackColor = Color.LightSkyBlue;
            Form3.BackColor = Color.LightSkyBlue;
            Form4.BackColor = Color.LightSkyBlue;
            Form5.BackColor = Color.LightSkyBlue;
            Form6.BackColor = Color.LightSkyBlue;
            Form7.BackColor = Color.LightSkyBlue;

            form.BackColor = modify_clr;
            treeView1.BringToFront();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            this.change(Form1, panel0);
            panel0.AutoScroll = true;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            changeBtn(Review_Yes, Review_No);
        }


        private void button16_Click_1(object sender, EventArgs e)
        {
            this.change(Form2, panel1);
            panel1.AutoScroll = true;

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.change(Form3, panel2);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.change(Form4, panel3);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.change(Form6, panel5);
        }

        private void Form5_Click(object sender, EventArgs e)
        {
            this.change(Form5, panel4);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Click(object sender, EventArgs e)
        {
            this.change(Form7, panel6);
        }

        private void nextOrnot(int num)
        {
            //Could make this code shorter but bruh..
            Control.ControlCollection coll = groupBox2.Controls;
            
            // If future jp is confused --- the list is in reverse order that's why i stuructured the loop like that
            for (int i = coll.Count - 1; i >= 0; i--)
            {
                Button ctrl = (Button) coll[i];
                Console.WriteLine(ctrl.Text);
                Console.WriteLine(ctrl.BackColor);
                Console.WriteLine(i);
                if (ctrl.BackColor == Color.LightGray || ctrl.BackColor == Color.Lime || ctrl.BackColor == Color.Blue )
                {
                    if (i == 0 && num == -1)
                    {
                        i = 7;
                    }
                    else if (i == 6 && num == 1)
                    {
                        i = -1;
                    }


                    ctrl = (Button)coll[i + num];
                    curr_form = ctrl;
                    ctrl.PerformClick();
                    Console.WriteLine(ctrl.Text);
                    Console.WriteLine(ctrl.BackColor);
                    Console.WriteLine(i);
                    break;
                }


            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            nextOrnot(1);

        }

        private void button20_Click(object sender, EventArgs e)
        {
            nextOrnot(-1);
        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void Review_No_Click(object sender, EventArgs e)
        {
            changeBtn(Review_No, Review_Yes);
        }

        private void button_dept_y_Click(object sender, EventArgs e)
        {
            changeBtn(button_dept_y, button_dept_n);
        }

        private void button_dept_n_Click(object sender, EventArgs e)
        {
            changeBtn(button_dept_n, button_dept_y);
        }

        private void dean_y_Click(object sender, EventArgs e)
        {
            changeBtn(dean_y, dean_n);
        }

        private void dean_n_Click(object sender, EventArgs e)
        {
            changeBtn(dean_n, dean_y);
        }

        private void Pages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control) // Ctrl + S
            {
                
                MessageBox.Show("Save action triggered!");
                e.Handled = true; 
            }else if (e.KeyCode == Keys.N)
            {
                nextOrnot(-1);
            }
            else if (e.KeyCode == Keys.B)
            {
                nextOrnot(1);
            }
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {

        }
    }
}
