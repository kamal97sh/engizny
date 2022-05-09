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
    public partial class Order : Form
    {
        Customer_servise cu = new Customer_servise();

        public Order(Customer_servise cu3)
        {
            InitializeComponent();
            this.cu = cu3;

            textBox1.Text = cu3.Get_office_numper();
            textBox2.Text = cu3.Get_your_turn();
            textBox3.Text =" "+ cu3.Get_your_time().ToString()+" min";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (cu.f_Customer_servise == true)
            {
                decreament_Customer_Service();
            }
            else if (cu.f_withdrawal == true)
            {
                decreament_withdrowal();
            }
            else if (cu.f_Deposit == true)
            {
                decreament_Deposite();
            }
            else
            {

            }
            Application.Exit();
            
        }

        public void decreament_Customer_Service()
        {   
             this.tbl_Customer_Service1TableAdapter.Get_Count_Customer_Service_Query();
             this.tbl_Customer_Service1TableAdapter.Delete_last_customer(cu.connect()-1);
        }
        private void decreament_withdrowal()
        {
            this.tbl_Count_withdrowalTableAdapter.select_Count_withdrowal_Query();          
            this.tbl_Count_withdrowalTableAdapter.Delete_last_customer_Query(cu.connect1() - 1);     
        }
        private void decreament_Deposite()
        {
            this.tbl_Count_DepositTableAdapter.Select_Count_Deposit_Query();
            this.tbl_Count_DepositTableAdapter.Delete_last_Row(cu.connect2() - 1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Order_Load(object sender, EventArgs e)
        {

        }
    }
}