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
    public partial class Customer_servise : Form
    {
        public Customer_servise()
        {
            InitializeComponent();
        }
        #region in/output
        public int count_Customer_servise = 0;
        public int count_withdrawal = 0;
        public int count_Deposit = 0;
        public bool f_Customer_servise = false;
        public bool f_withdrawal = false;
        public bool f_Deposit = false;
        public int your_turn;

        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false && radioButton2.Checked == false 
                                 && radioButton1.Checked == false)
            {
                MessageBox.Show("please choose your servise...");
            }
            else
            {
               
               // login login = new login();
               // string user_id = login.user_id;

                Get_office_numper();
                Get_your_turn();
                Get_your_time();

                Order O = new Order(this);
                O.Show();
                this.Hide();
            }
        }
        public string Get_office_numper()
        {
            if (f_Customer_servise == true)
            {
                return "1";
            }
            else if (f_withdrawal == true)
            {
                return "2";

            }
            else if (f_Deposit == true)
            {
                return "3";
            }
            return "0";
        }
        public string Get_your_turn()
        {
            if (f_Customer_servise == true && f_withdrawal == false && f_Deposit == false)
            {
                
                  return this.tbl_Customer_Service1TableAdapter.Get_Count_Customer_Service_Query().ToString();
            }
            else if (f_Customer_servise == false && f_withdrawal == true && f_Deposit == false)
            {
                return this.tbl_Count_withdrowalTableAdapter.select_Count_withdrowal_Query().ToString();
            }
            else if (f_Customer_servise == false && f_withdrawal == false && f_Deposit == true)
            {
                return this.tbl_Count_DepositTableAdapter.Select_Count_Deposit_Query().ToString();
            }
            return "0";

        }
        public string Get_your_time()
        {
            if (Get_office_numper() == "1")
            {
                int m = int.Parse(Get_your_turn()) * 3;
                return m.ToString();
            }
            if (Get_office_numper() == "2")
            {
                int m = int.Parse(Get_your_turn()) * 5;
                return m.ToString();
            }
            if (Get_office_numper() == "3")
            {
                int m = int.Parse(Get_your_turn()) * 7;
                return m.ToString();
            }
            return "-1";
        }
        #region radioButton
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                f_Customer_servise = true;
            }
            test();
            increament_Customer_Service();

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                f_withdrawal = true;
            }
            test();
            increament_withdrowal();
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked == true)
            {
                f_Deposit = true;
            }
            test();
            increament_Deposite();

        }
        private void test()
        {

            if (radioButton1.Checked == true && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;


            }
            if (radioButton1.Checked == false && radioButton2.Checked == true && radioButton3.Checked == false)
            {
                radioButton1.Enabled = false;
                radioButton3.Enabled = false;

            }
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == true)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;

            }
        }
        #endregion
        #region increament_Service
        public int cheacked()
        {

            if (f_Customer_servise == true)
            {
                return (int)increament_Customer_Service();
            }
            else if (f_withdrawal == true)
            {
                return (int)increament_withdrowal();
            }
            else if (f_Deposit == true)
            {
                return (int)increament_Deposite();
            }
            else
            {

            }
            return 0;

        }
        public int increament_Customer_Service()
        {
            this.tbl_Customer_Service1TableAdapter.Insert_New_Customer_Service_Query(3,"Customer Service");
            var x = this.tbl_Customer_Service1TableAdapter.Get_Count_Customer_Service_Query();
            
            var time = x * 3;
            return (int)time;
        }
        private int increament_withdrowal()
        {
            this.tbl_Count_withdrowalTableAdapter.Insert_new_time_withdrowal_Query(5,"withdrowal");
            var x = this.tbl_Count_withdrowalTableAdapter.select_Count_withdrowal_Query();
            var time = x * 5;
            return (int)time;

        }
        private int increament_Deposite()
        {
            this.tbl_Count_DepositTableAdapter.Insert_New_time_Query(7,"Deposit");
            var x = this.tbl_Count_DepositTableAdapter.Select_Count_Deposit_Query();
            var time = x * 7;
            return (int)time;

        }
        #endregion
        #region connection
        public int connect()
        {
            var c = this.tbl_Customer_Service1TableAdapter.Get_Count_Customer_Service_Query();
            return (int)c;
        }
        public int connect1()
        {
            var c = this.tbl_Count_withdrowalTableAdapter.select_Count_withdrowal_Query();
            return (int)c;
        }
        public int connect2()
        {
            var c = this.tbl_Count_DepositTableAdapter.Select_Count_Deposit_Query();
            return (int)c;
        }

        #endregion
    }
}
