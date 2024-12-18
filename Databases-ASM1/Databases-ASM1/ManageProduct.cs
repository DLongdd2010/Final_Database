﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databases_ASM1
{
    public partial class ManageProduct : Form
    {
        private int bookId;
        private int employeeId;
        private string authorityLevel;
        public ManageProduct(string authorityLevel, int employeeId)
        {
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
            bookId = 0;
            InitializeComponent();
        }

        private void LoadCategoryCombobox()
        {
            SqlConnection connection = Database_Connection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string query = "SELECT CategoryID, CategoryName FROM  Category";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbCategory.DataSource = dataTable;
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryID";
            }
        }

        private bool ValidateData(String bookCode, String bookName, String productPrice, String inventoryQuantity)
        {
            double temp;
            int temp2;
            if (string.IsNullOrEmpty(bookName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(productPrice))
            {
                return false;
            }
            if (double.TryParse(productPrice, out temp))
            {
                return false;
            }
            if (string.IsNullOrEmpty(inventoryQuantity))
            {
                return false;
            }
            return int.TryParse(inventoryQuantity, out temp2);
        }

        private void UploadFile(String filter, String path)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            openFileDialog.Title = "Select a file to upload";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFilePath =  openFileDialog.FileName;
                string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads");
                string targetFilePath = Path.Combine(targetDirectory, Path.GetFileName(sourceFilePath));
                try
                {
                    if (Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }
                    File.Copy(sourceFilePath, targetFilePath, overwrite: true);
                    txtProductImage.Text = targetFilePath;
                    MessageBox.Show("File uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error uploading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadProductData()
        {
            SqlConnection connection = Database_Connection.GetConnection();
            if  (connection != null)
            {
                connection.Open();
                string query = "SELECT * FROM Book";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dtgProduct.DataSource = dataTable;
                connection.Close();
            }
        }

        private void ClearData()
        {
            FlushProductId();
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductImage.Text= string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        //private void ChangeButtonStatus(bool buttonStatus)
        //{
        //    btnUpdate.Enabled = buttonStatus;
        //    btnDelete.Enabled = buttonStatus;
        //    btnClear.Enabled = buttonStatus;
        //    btnAdd.Enabled = buttonStatus;
        //}

        private void FlushProductId()
        {
            this.bookId = 0;
            //ChangeButtonStatus(false);
        }

        private void AddProduct()
        {
            SqlConnection connection = Database_Connection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string bookCode = txtProductCode.Text;
                string bookName = txtProductName.Text;
                string productImage = txtProductImage.Text;
                string price = txtProductPrice.Text;
                string quantity = txtProductQuantity.Text;
                int categoryId = Convert.ToInt32(cbCategory.SelectedValue);
                if (ValidateData(bookCode, bookName, price, quantity))
                {
                    string sql = "INSERT INTO Book VALUES (" +
                        "@bookCode, @bookName, @productPrice, @inventoryQuantity, @productImage, @categoryId)";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("bookCode", bookCode);
                    command.Parameters.AddWithValue("bookName", bookName);
                    command.Parameters.AddWithValue("productPrice", Convert.ToDouble(price));
                    command.Parameters.AddWithValue("inventoryQuantity", Convert.ToInt32(quantity));
                    command.Parameters.AddWithValue("productImage", productImage);
                    command.Parameters.AddWithValue("categoryId", categoryId);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Successfully add new product", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearData();
                        LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show("Cannot add new product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();
            }
        }

        private void UpdateProduct()
        {
            SqlConnection connection = Database_Connection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string bookCode = txtProductCode.Text;
                string bookName = txtProductName.Text;
                string productImage = txtProductImage.Text;
                string price = txtProductPrice.Text;
                string quantity = txtProductQuantity.Text;
                int categoryId = Convert.ToInt32(cbCategory.SelectedValue);
                if (ValidateData(bookCode, bookName, price, quantity))
                {
                    string sql = "UPDATE Book  SET BookCode =  @bookCode, " +
                                  "BookName = @bookName, " +
                                  "Price = @productPrice, " +
                                  "InventoryQuantity = @productQuantity, " +
                                  "ProductImage = @productImage, " +
                                  "CategoryID = @categoryId " +
                                  "WHERE ProductID =  @productId";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("bookCode", bookCode);
                    command.Parameters.AddWithValue("bookName", bookName);
                    command.Parameters.AddWithValue("productPrice", Convert.ToDouble(price));
                    command.Parameters.AddWithValue("iventoryQuantity", Convert.ToInt32(quantity));
                    command.Parameters.AddWithValue("produtImage", productImage);
                    command.Parameters.AddWithValue("categoryId", categoryId);
                    command.Parameters.AddWithValue("productId", this.bookId);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Successfully update new product", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearData();
                        LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show("Cannot update new product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();
            }
        }

        private void DeleteProduct()
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete the product", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection connection = Database_Connection.GetConnection();
                if (connection != null)
                {
                    connection.Open();
                    string sql = "DELETE Product WHERE ProductID  = @productId";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("productId", this.bookId);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Successfully delete product", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearData();
                        LoadProductData();
                    }
                    else
                    {
                        MessageBox.Show("Cannot delete product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Product is in another order\nCannot delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsProductInOrder(int bookId)
        {
            SqlConnection connection = Database_Connection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT COUNT (*) FROM OrderDetail WHERE BookID = @bookId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("bookId", bookId);
                int result = (int)command.ExecuteNonQuery();
                connection.Close();
                return result > 0;
            }
            return false;
        }

        private void SearchProduct(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadProductData();
            }
            else
            {
                SqlConnection connection = Database_Connection.GetConnection();
                if (connection != null)
                {
                    connection.Open();
                    string sql = "SELECT p.BookID, p.BookName, p.Price,  " +
                        "p.InventoryQuantity, p.ProductImage, c.CategoryName " +
                        "FROM Book p " +
                        "INNER JOIN Category c " +
                        "ON p.CategoryID = c.CategoryID " +
                        "WHERE p.BookCode LIKE @search " +
                        "OR p.BookName LIKE @search " +
                        "OR c.CategoryName LIKE  @search";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("search", "&" + search + "&");
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dtgProduct.DataSource = data;
                    connection.Close();
                }
            }
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            LoadProductData();
            LoadCategoryCombobox();
            //ChangeButtonStatus(false);
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (authorityLevel)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(this.authorityLevel, employeeId);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse":
                    {
                        WarehouseManagerForm warehouseManagerForm = new WarehouseManagerForm(this.authorityLevel, employeeId);
                        this.Hide();
                        warehouseManagerForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm saleForm = new SaleForm(this.authorityLevel, employeeId);
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

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchProduct(search);
        }

        private void dtgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgProduct.CurrentCell.RowIndex;
            if (index != -1/* && dtgProduct.Rows[index].IsNewRow*/)
            {
                bookId = Convert.ToInt32(dtgProduct.Rows[index].Cells[0].Value);
                //ChangeButtonStatus(true);
                txtProductCode.Text = dtgProduct.Rows[index].Cells[1].Value.ToString();
                txtProductName.Text = dtgProduct.Rows[index].Cells[2].Value.ToString();
                txtProductPrice.Text = dtgProduct.Rows[index].Cells[3].Value.ToString();
                txtProductQuantity.Text = dtgProduct.Rows[index].Cells[4].Value.ToString();
                txtProductImage.Text = dtgProduct.Rows[index].Cells[5].Value.ToString();
                string categoryName = dtgProduct.Rows[index].Cells[6].Value.ToString();
                for (int i = 0; i < dtgProduct.Rows.Count; i++)
                {
                    if (cbCategory.SelectedText == categoryName)
                    {
                        cbCategory.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}
