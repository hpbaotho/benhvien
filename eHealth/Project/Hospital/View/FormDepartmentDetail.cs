﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hospital.Model;

namespace Hospital.View
{
    public partial class FormDepartmentDetail : Form
    {
        public Department DepartmentDetail { get; set; }
        public String UserAction { get; set; }
        public FormDepartmentDetail()
        {
            InitializeComponent();
        }
        public FormDepartmentDetail(Department departmentDetail, String userAction)
        {
            InitializeComponent();
            this.DepartmentDetail = departmentDetail;
            this.UserAction = userAction;
            if (this.UserAction == "edit")
                SetDepartmentDetail(departmentDetail);
        }
        private void SetDepartmentDetail(Department departmentDetail)
        {
            textBoxDepartmentID.Text = departmentDetail.DepartmentID.ToString();
            textBoxDepartmentName.Text = departmentDetail.DepartmentName;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!superValidator1.Validate())
                return;
                try
                {
                    if (UserAction == "edit")
                    {
                        DepartmentDetail.DepartmentName = textBoxDepartmentName.Text;
                        DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin phòng ban", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (Department.UpdateDepartment(DepartmentDetail) > 0)
                                MessageBox.Show("Cập nhập thông tin phòng ban thành công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    else
                    {
                        Department newDepartment = new Department(0, textBoxDepartmentName.Text);
                        if (Department.InsertDepartment(newDepartment) > 0)
                            MessageBox.Show("Thêm phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            this.Close();
        }
    }
}
