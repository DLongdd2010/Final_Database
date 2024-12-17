using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databases_ASM1
{
    public partial class AdminForm : Form
    {
        int employeeId;
        string authorityLevel;
        public AdminForm(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.authorityLevel = authorityLevel;
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            ManageEmployee manageEmployee = new ManageEmployee(authorityLevel, employeeId);
            this.Hide();
            manageEmployee.Show();
        }

        private void btnManegoryCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void btnManageImport_Click(object sender, EventArgs e)
        {
            
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            ManageProduct manageProduct = new ManageProduct(this.authorityLevel, this.employeeId);
            this.Hide();
            manageProduct.Show();
        }

        private void btnManageOrder_Click(object sender, EventArgs e)
        {
            OrderHistory orderHistory = new OrderHistory(this.authorityLevel, this.employeeId);
            this.Hide();
            orderHistory.Show();
        }

        private void btnViewStatistic_Click(object sender, EventArgs e)
        {

        }
    }
}
