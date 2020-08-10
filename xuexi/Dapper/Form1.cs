using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;//导入dapper

namespace dapperssss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.textBox8.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PersonService ps = new PersonService();
            List<Person> list= ps.FindeListByLastName(this.textBox1.Text.Trim());
            listBox1.DataSource = list;
            listBox1.DisplayMember = "Email";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonServic2 ps = new PersonServic2();
            Person person = new Person
            {
                FirstName = this.textBox2.Text,
                LastName = this.textBox3.Text,
                Email = this.textBox4.Text,
            };

            var success = ps.InsertData(person);

            MessageBox.Show(success?"成功":"失败");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim()!="")
            {
                this.textBox6.Enabled = true;
                this.textBox7.Enabled = true;
                this.textBox8.Enabled = true;
                this.textBox5.ReadOnly = true;
                PersonServic3 ps = new PersonServic3();
                int thisid = int.Parse(textBox5.Text.Trim());
                Person person = ps.FindByPersonId(thisid);

                this.textBox6.Text = person.FirstName;
                this.textBox7.Text = person.LastName;
                this.textBox8.Text = person.Email;
            }
            else
            {
                MessageBox.Show("请先填写ID");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Person person = new Person
            {
                Id=int.Parse(this.textBox5.Text),
                FirstName = this.textBox6.Text,
                LastName = this.textBox7.Text,
                Email = this.textBox8.Text,
            };
            PersonServic3 ps = new PersonServic3();
            bool success = ps.UpdateDate(person);

            MessageBox.Show(success ? "成功" : "失败");

        }
    }
}
