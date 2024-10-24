using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoi8
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolDBDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.schoolDBDataSet.Students);
            // Gán DataSource cho BindingSource
            bindingSource.DataSource = schoolDBDataSet.Students;

            // Gán BindingSource cho DataGridView
            dgvSinhVien.DataSource = bindingSource;

            // Thiết lập data binding cho các control
            txtTen.DataBindings.Add("Text", bindingSource, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTuoi.DataBindings.Add("Text", bindingSource, "Age", true, DataSourceUpdateMode.OnPropertyChanged);

            cmbNghanh.DataSource = new List<string> { "Computer Science", "Business Administration", "Mechanical Engineering" }; // Danh sách chuyên ngành
            cmbNghanh.DataBindings.Add("SelectedItem", bindingSource, "Major", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo mới một dòng trong DataTable
                DataRow newRow = schoolDBDataSet.Students.NewRow();

                // Gán giá trị cho các cột
                newRow["FullName"] = txtTen.Text;
                newRow["Age"] = int.Parse(txtTuoi.Text);
                newRow["Major"] = cmbNghanh.SelectedItem.ToString();

                // Thêm dòng mới vào DataTable
                schoolDBDataSet.Students.Rows.Add(newRow);

                // Cập nhật lại cơ sở dữ liệu
                studentsTableAdapter.Update(schoolDBDataSet.Students);

                // Hiển thị thông báo thêm thành công
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới DataGridView
                dgvSinhVien.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Logic để sửa sinh viên
                if (bindingSource.Current is DataRowView currentRow)
                {
                    currentRow["FullName"] = txtTen.Text;
                    currentRow["Age"] = int.Parse(txtTuoi.Text);
                    currentRow["Major"] = cmbNghanh.SelectedItem.ToString();
                    studentsTableAdapter.Update(schoolDBDataSet.Students); // Cập nhật cơ sở dữ liệu

                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới DataGridView
                    bindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Logic để xóa sinh viên
                if (bindingSource.Current is DataRowView currentRow)
                {
                    currentRow.Delete();
                    studentsTableAdapter.Update(schoolDBDataSet.Students); // Cập nhật cơ sở dữ liệu

                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới DataGridView
                    bindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTuoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbNghanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // Di chuyển đến sinh viên trước đó
            if (bindingSource.Position > 0)
            {
                bindingSource.MovePrevious();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (bindingSource.Position < bindingSource.Count - 1)
            {
                bindingSource.MoveNext();
            }
        }
    }
}
