using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace engizny
{
    public partial class login : Form
    {
        rong_user_or_password rong_User_Or_Passwmmord = new rong_user_or_password();
        public string user_id;
        public login()
        {
           
            InitializeComponent();
            
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sign_in s_in = new sign_in();   
            s_in.Show();
            this.Hide();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var x = this.tbl_UserTableAdapter.check_user_and_password(textBox1.Text, textBox2.Text);
                if (x.First().User_Id != null || x.First().Password != null)
                {
                    Customer_servise cu = new Customer_servise();
                    cu.Show();
                    this.Hide();
                }


            }
            catch
            {
                
                rong_User_Or_Passwmmord.Show();
            }
        }
        private void tbl_UserBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            feed_back  feed_Back = new feed_back();
            feed_Back.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
