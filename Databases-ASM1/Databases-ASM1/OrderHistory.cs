using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databases_ASM1
{
    public partial class OrderHistory : Form
    {
        int employeeId;
        string authorityLevel;
        public OrderHistory(string authorityLevel, int employeeId)
        {
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
            InitializeComponent();
        }
        private void LoadOrderHistory()
        {
            SqlConnection connection = Database_Connection.GetConnection();
            if (connection != null )
            {
                connection.Open();
                string query = "SELECT s.SaleDate, " +
                               "e.EmployeeName, " +
                               "c.CustomerName " +
                               "FROM Sale s " +
                               "INNER JOIN Employee e ON s.EmployeeID = e.EmployeeID " +
                               "INNER JOIN Customer c ON s.CustomerID = c.CustomerID " +
                               "WHERE s.EmployeeID = @employeeId " +
                               "GROUP BY s.SaleDate, e.EmployeeName, c.CustomerName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("employeeId", employeeId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dtgOrderHistory.DataSource = dataTable;
            }
        }
        private void RedirectPage()
        {
            switch (this.authorityLevel)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(authorityLevel, employeeId);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse Manager":
                    {
                        WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(authorityLevel, employeeId);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm saleForm = new SaleForm(authorityLevel, employeeId);
                        this.Hide();
                        saleForm.Show();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            LoadOrderHistory();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            RedirectPage();
        }
    }
}
