using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
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

namespace Project
{
    public partial class Pages : Form
    {
        public List<Student> Students { get; set; }
        public int id;
        public Color modify_clr = Color.LightGray;
        public Color main_clr = Color.LightSlateGray;
        public Button curr_form;
        public string acc;
        public string stud_id;

        public Pages( string acct , string id , string name = "testAccount")
        {
            this.acc = acct;
            this.stud_id = id;

            Students = GetStudents();
            InitializeComponent();
            curr_form = Form1;

            //THis makes sure all the keybinds go through the form first rather than focued controls
            this.KeyPreview = true;
            
            
            if (acct == "student")
            {
                button11.Visible = false;
                button10.Visible = false;
                groupBox1.Visible = false;
                label90.Text = "Student";
                
            }

            if (name != "" && name != "\n" && name != null)
            {
                label89.Text = name;
            }
            else
            {
                label89.Text = "testAccount";
            }
        }


        // Function Used to Retrive all Case info from the Json file ( data.txt ) Parse it to a Dictionary<string, Student> type and throw it in a list to be used by the program at will
        private List<Student> GetStudents()
        {

            StreamReader read = new StreamReader("data.txt");//change back to data.txt
            String Textdata = read.ReadToEnd();

            var studentRecords = JsonConvert.DeserializeObject<Dictionary<string, Student>>(Textdata);
            read.Close();


            var list = new List<Student>();//Now i think about it all tehe reck migth just me student classes

            //Try changing it to list.Add(rec) or return studentRecords or list.Add(rec.Value)
            //Just checked and it worked, but Refactoring of the whole codebase is needed and I aint got the energy for that ----> list.Add(rec) mainly problems with the id

            //Refactored Code
            foreach (var rec in studentRecords)
            {
                rec.Value.id = rec.Key;
                Console.WriteLine("asdf acc " + acc);
                if (acc == "student")
                {
                    if (rec.Value.Student_Number == stud_id)
                    {
                        list.Add(rec.Value);
                    }
                }
                else
                {
                    list.Add(rec.Value);
                }
            }
            return list;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Hiding all panels(Forms) and leaving only the first ones visible
            panel1.AutoScroll = true;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            // Getting the student lisr from the global variable Students and passing it to the DGV
            var students = this.Students;
            dataGridView1.DataSource = students;

            int last = dataGridView1.ColumnCount - 1;
            // This code makes sure the last column color stays red, but doesnt handle the case when the DGV is reloaded
            DataGridViewCellStyle specificCellStyle = new DataGridViewCellStyle();
            specificCellStyle.BackColor = System.Drawing.Color.FromArgb(150,0,10);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                row.Cells[last].Style.ApplyStyle(specificCellStyle);

            }
            // Adding nodes the treeview node 
            treeView1.Nodes.Add("Form1");
            treeView1.Nodes.Add("Form2");
            treeView1.Nodes.Add("Form3");
            treeView1.Nodes.Add("Form4");
            treeView1.Nodes.Add("Form5");
            treeView1.Nodes.Add("Form6");
            treeView1.Nodes.Add("Form7");
            
            //Populating Each of the nodes
            populate(panel0,0);
            populate(panel1,1);
            populate(panel2,2);
            populate(panel3,3);
            populate(panel4,4);
            populate(panel5,5);
            populate(panel6,6);
            


        }

        // this function populates each of the nodes by looking for values in this order TableLayoutPanel > FlowLayoutPanel > RichTextBox or the topmost RichTextBox
        public void populate( Panel p , int num)
        {
            //Recursion is never a good idea but fk it we balll
            foreach (Control ctrl in p.Controls)
            {
                //Console.WriteLine("Not txt"+ctrl.Text);
                //Console.WriteLine("Type: " + ctrl.GetType().Name);
                if (ctrl.GetType().Name == "TableLayoutPanel")
                {
                    foreach (Control ctrl2 in ctrl.Controls)
                    {
                        if (ctrl2.GetType().Name == "FlowLayoutPanel")
                        {
                            foreach (Control ctrl3 in ctrl2.Controls)
                            {
                                if (ctrl3.GetType().Name == "RichTextBox")
                                {
                                    Console.WriteLine("Sub: " + ctrl3.Name);
                                    if (!(ctrl3.Name).Contains("richTextBox"))
                                    {
                                        treeView1.Nodes[num].Nodes.Add(ctrl3.Name);
                                    }

                                }
                            }
                        }


                    }

                }
                else if (ctrl.GetType().Name == "RichTextBox")
                {
                    Console.WriteLine("Main: " + ctrl.Name);
                    if (!(ctrl.Name).Contains("richTextBox"))
                    {
                        treeView1.Nodes[num].Nodes.Add(ctrl.Name);
                    }

                }
            }
        }

       

   
       
        //This function is responsible for excecuting the python script that runs the CRUD operations. It takes the the parameters of the script as an argument
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
            if (res.Trim() == "OK" )// If the file prints ok to the standard output that means the crud operation was sucessfull otherwise it was not
            {
                // Reloading the DBV with new data
                this.Students = GetStudents();//or i could just edit student object directly( would be faster)
                dataGridView1.DataSource = this.Students;
                return true;
                
            }
            else
            {
                return false;
            }
        }

        // This is the delete function 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine(e.ColumnIndex);
            


            if (e.ColumnIndex == 9)
            {
                String ID = dataGridView1.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].FormattedValue.ToString();
                //Console.WriteLine("DELETE");
                Console.WriteLine(this.run($"delete {ID}"));

            }

        }

        // This configures the DBV's colums and rows
        private void config()
        {
            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = 10;
        }


        // Logic for the checkboxes
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

        // This method inflates( fills ) not only fills the TextBoxes but also manages their state , the file parameter is depreacated i should remove it later
        private void inflate(string name , string info , Boolean file= false , Boolean disable = false)
        {
            

            //Console.WriteLine("tbx: " + name+" "+info);
            //Control tbx1 = this.Controls.Find("Student_Name", true).FirstOrDefault();
            RichTextBox tbx = this.Controls.Find(name, true).FirstOrDefault() as RichTextBox;
            //Console.WriteLine("tbx: " + tbx);

            //logic for inflating the checkboxes
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

            //Logic for control states
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
            //Inflating the textboxes
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

       
        // Function for the enabled checkbox, this function is responible for passing the accruate info to the inflate function to diable or enable controls
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
        //This function is responsible for sure all the textboxes are populated with information from the file
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;

            //Changing tab view to Case Tab
            tabControl1.SelectedTab = tabPage4;
            //Console.WriteLine(dataGridView1.Columns[e.ColumnIndex]);
            var students = this.Students; // Getting List of Students
            foreach (var rec in students)// Looping through student and finding the one that matches the ID we wanna display
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["idDataGridViewTextBoxColumn"].FormattedValue.ToString() == rec.id)
                {
                    this.id = int.Parse(rec.id);//setting the global variable id to for reference to the student info we are working with currently
                    foreach (var attr in rec.GetType().GetProperties())//Looping through each attribute in the student class
                    {
                        this.inflate(attr.Name, attr.GetValue(rec, null).ToString(),false,true);// Inflating the attributes to the textboxes i.e Filling all the textboexes with the students case info
                        //Console.WriteLine(attr.Name);
                        //Console.WriteLine(attr.GetValue(rec, null).ToString());
                    }

                }
            }

        }

       
        //Checkbutton logic
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

        //Checkbutton logic 
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


        //Checkbutton logic ... why are they so many of these???
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

       
        // This function works as an adapter between the C# and Python as it gets all the data from the textboxes and sends them off to python to excute the changes ( Mainly for additon and modification) delete and view are handling by other functions
        private void update(String type)
        {
            Console.WriteLine("ID" + this.id);
            var students = this.Students;
            var id = this.id;
            String text = "["; // Setting text to start of python list
            String t = "";
            Boolean d = false;// If true means txtbx was left empty
            StreamWriter writer = new StreamWriter("update.txt");// this is incase we dont pass the info directly to python and choose to pass it to a file instead

            foreach (var rec in students)// FInding student object, the id part may not be needed .. note to self to reevalute later - it's not need since attr.Value isnt called
            {
                //Remove this if statement
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

            //closing the python list type string
            text += "]";
            
            //Writing to the output file just in case
            writer.WriteLine(text);
            writer.Close();
            
            if (d) // Checking if any field was left empty
            {
                DialogResult result = MessageBox.Show("You may be missing some info, Do you wish to coutinue?",
                                             "Exit Confirmation",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question);
                if (!(result == DialogResult.Yes))
                {
                    type = "non";
                }
                
            }


            /*
            Sending data this way isn't mandatory, 
            just omit the -i flag and python will take the data from the output.txt file 
            */
            Console.WriteLine(this.run($"{type} {id} -o -i \"{text}\" "));//Calling run to Excute the python file where type is the operation id is the id and text is the data being sent 
            tabControl1.SelectedTab = tabPage3;
            checkBox1.Checked = false;
            if (type != "non")
                MessageBox.Show("Data Sucessfully Saved!.");
            

        }

        //Depending on the mode this function saves or modifys the database
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

        // This function clears the form
        private void button8_Click(object sender, EventArgs e)
        {
            var students = this.Students;
            foreach (var rec in students)
            {
                    this.id = int.Parse(rec.id);
                    foreach (var attr in rec.GetType().GetProperties())
                    {
                        this.inflate(attr.Name, "");// It does this by inflating it but with empty strings
                        
                    }

            }
        }

       
        //This function switches the modes ( Add,Edit)
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

        
        // This function is responsible for diplaying the forms by only making the required form visible and hiding the others
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

            Form1.BackColor = main_clr;
            Form2.BackColor = main_clr;
            Form3.BackColor = main_clr;
            Form4.BackColor = main_clr;
            Form5.BackColor = main_clr;
            Form6.BackColor = main_clr;
            Form7.BackColor = main_clr;

            Console.WriteLine(panel.Name);
            form.BackColor = modify_clr;
            String p = Char.ToString((panel.Name)[5]);

            treeView1.CollapseAll();
            Console.WriteLine(p);
            treeView1.BringToFront();
            treeView1.Nodes[int.Parse(p)].Expand();
            button1.BringToFront();
        }

        // These are Just the form buttons that call the change function to display the desired form
        private void button13_Click(object sender, EventArgs e)
        {
            this.change(Form1, panel0);
            panel0.AutoScroll = true;

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

        private void Form7_Click(object sender, EventArgs e)
        {
            this.change(Form7, panel6);
        }

        // This function handles the logic of the next and previous buttons 
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

        //Previous button
        private void button19_Click(object sender, EventArgs e)
        {
            nextOrnot(1);

        }
        //Next button
        private void button20_Click(object sender, EventArgs e)
        {
            nextOrnot(-1);
        }

       //Checkbox Button functions
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


        //This function handles all the shortcut keys
        private void Pages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control) // Ctrl + S
            {
                
               //Implment this
            }else if (e.KeyCode == Keys.N && e.Control)
            {
                nextOrnot(-1);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.B && e.Control)
            {
                nextOrnot(1);
                e.Handled = true;
            }else if (e.KeyCode == Keys.C && e.Control)
            {
                button10.PerformClick();
                e.Handled = true;
            }
        }

        
        // THis function expands or minimized the treeview
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == ">")
            {
                button1.Text = "<";
                Size s = new Size(200, 783);
                treeView1.Size = s;
            }
            else
            {
                button1.Text = ">";
                Size s = new Size(84, 783);
                treeView1.Size = s;
            }
            
        }


        //Minimal function that binds each node in the tree view to its corresspondig attribute
        private void treeView1_AfterSelect_2(object sender, TreeViewEventArgs e)
        {
            //This is as far as I'm going... I have a life to live T_T
            RichTextBox tbx = this.Controls.Find(e.Node.Text, true).FirstOrDefault() as RichTextBox;
            Button b = this.Controls.Find(e.Node.Text, true).FirstOrDefault() as Button;
            Console.WriteLine(e.Node.Text);
            if (tbx != null)
            {
                tbx.Focus();
                tbx.Select();
            }

            if (b != null)
            {
                b.PerformClick();
            }

        }

        //This is the sign_out function ... It essentially signs you out
        private void button6_Click(object sender, EventArgs e)
        {
            
            //Auth auth = new Auth();
            //auth.Show();
            StreamWriter write = new StreamWriter("sess.txt", false);
            write.Write("");
            write.Close();
            this.Close();
        }

       
    }
}
