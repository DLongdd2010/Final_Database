using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databases_ASM1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            InitializeCombobox();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem.ToString();
            bool isvalid = ValidateData(username, password, role);
            if (isvalid)
            {
                SqlConnection connection = Database_Connection.GetConnection();
                if (connection != null)
                {
                    string query = "SELECT EmployeeId, PasswordChanged FROM Employee WHERE Username = @username" +
                                   " AND Password = @password AND AuthorityLevel = @role";
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue ("password", password);
                    command.Parameters.AddWithValue("role", role);
                    SqlDataReader reader = command.ExecuteReader();
                    int employeeId = 0;
                    bool passwordChanged = false;
                    while (reader.Read())
                    {
                        employeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                        passwordChanged = reader.GetBoolean(reader.GetOrdinal("PasswordChanged"));
                    }
                    if (employeeId > 0)
                    {
                        MessageBox.Show("Login success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RedirectPage(role, employeeId, passwordChanged);
                    }
                    else
                    {
                        MessageBox.Show("Invalid login credential", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearData();
                    }
                    connection.Close();
                }
                
            }
        }
        private void ClearData()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbRole.SelectedIndex = 0;
            txtPassword.Focus();
        }

        public void InitializeCombobox()
        {
            cbRole.Items.Add("Admin");
            cbRole.Items.Add("Warehouse");
            cbRole.Items.Add("Sale");
            cbRole.SelectedIndex = 0;
        }

        private bool ValidateData(string username, string password, string role)
        {
            bool isValid = true;
            if (username == null || username == string.Empty)
            {
                MessageBox.Show("Username cannot be blank", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
                txtUsername.Focus();
            }
            else if (password == null || password == string.Empty)
            {
                MessageBox.Show("Password cannot be blank", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
                txtPassword.Focus();
            }
            else if (role == null || role == string.Empty)
            {
                MessageBox.Show("No role selected", "waring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
                cbRole.Focus();
            }
            return isValid;
        }

        private void RedirectPage(string selectedRole, int employee, bool ischangePassword)
        {
            if (ischangePassword)
            {
                if (selectedRole != null)
                {
                    if (selectedRole == "Admin")
                    {
                        AdminForm adminForm = new AdminForm(selectedRole, employee);
                        this.Hide();
                        adminForm.Show();
                    }
                    else if (selectedRole == "Warehouse")
                    {
                        WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(selectedRole, employee);
                        this.Hide();
                        warehouseManagerForm.Show();
                    }
                    else if (selectedRole == "Sale")
                    {
                        SaleForm sale = new SaleForm(selectedRole, employee);
                        this.Hide();
                        sale.Show();
                    }
                }
            }
            else
            {
                ChangePassword changPassword = new ChangePassword(employee, selectedRole);
                changPassword.Show();
                this.Hide();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
