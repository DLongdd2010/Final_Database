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
    public partial class ChangePassword : Form
    {
        string role;
        int employeeId;

        public ChangePassword(int employeeId, string role)
        {
            InitializeComponent();
            this.role = role;
            this.employeeId = employeeId;
        }
        private void ClearData()
        {
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtConfirmPassword.Focus();
        }

        private void RedirectPage(int employeeId, string authorityLevel)
        {
            if (authorityLevel == "Admin")
            {
                AdminForm adminForm = new AdminForm(authorityLevel, employeeId);
                this.Hide();
                adminForm.Show();
            }
            else if (authorityLevel == "Warehouse Manager")
            {
                WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(authorityLevel, employeeId);
                this.Hide();
                warehouseManagerForm.Show();
            }
            else if (authorityLevel == "Sale")
            {
                SaleForm saleForm = new SaleForm(authorityLevel,employeeId);
                this.Hide();
                saleForm.Show();
            } 
        }

        private void UpdateEmployee(int employeeId, string newPasswrod)
        {
            SqlConnection connection = Database_Connection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Employee SET Password = @newPassword, " +
                             "PasswordChanged = 1  " +
                             "WHERE EmployeeID = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("newPassword", newPasswrod);
                command.Parameters.AddWithValue("employeeId", employeeId);
                int ischanged = command.ExecuteNonQuery();
                if (ischanged > 0) 
                {
                    MessageBox.Show("Succesfully change password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RedirectPage(employeeId, role);
                }
                else
                {
                    MessageBox.Show("An error occur white change password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearData();
                }
                connection.Close();
            }
        }
        private bool ValidateData(string newPassword, string confirmPassswrod)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("New password cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassword.Focus();
                isValid = false;
            }
            else if (string.IsNullOrEmpty(confirmPassswrod))
            {
                MessageBox.Show("Confirm passwrod cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            else if (newPassword != confirmPassswrod)
            {
                MessageBox.Show("New & confirm passwords are not similar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearData();
                isValid = false;
            }
            return isValid;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            bool isValid = ValidateData(newPassword, confirmPassword);
            if (isValid)
            {
                UpdateEmployee(employeeId, newPassword);
            }
        }
    }
}
