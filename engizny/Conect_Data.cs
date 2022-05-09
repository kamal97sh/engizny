using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace engizny
{
    public partial class Conect_Data 
    {
        SqlConnection cnn;
        string connectionString = "Data Source=DESKTOP-V3SFL7Q'\'MSSQLSERVER01;Initial Catalog=engizny;Integrated Security=True";

        Conect_Data()
        {
            Console.WriteLine(connectionString);
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            MessageBox.Show("Connection Open  !");
            cnn.Close();
        }

    }
    
}
