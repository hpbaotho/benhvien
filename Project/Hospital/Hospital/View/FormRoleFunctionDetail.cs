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
    public partial class FormRoleFunctionDetail : Form
    {
        public RoleFunction Function { get; set; }
        public String UserAction { get; set; }
        public FormRoleFunctionDetail()
        {
            InitializeComponent();
        }
        public FormRoleFunctionDetail(RoleFunction function, String usertAction)
        {
            InitializeComponent();
            this.Function = function;
            this.UserAction = usertAction;
            if(UserAction == "edit")
                SetRoleFunctionDetail(function);
        }
        private void SetRoleFunctionDetail(RoleFunction function)
        {
            textBoxFunctionID.Text = function.FunctionID.ToString();
            textBoxFunctionName.Text = function.FucntionName;
            textBoxButton.Text = function.Button;
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
                    Function.FucntionName = textBoxFunctionName.Text;
                    Function.Button = textBoxButton.Text;
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn cập nhập thông tin chức năng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (RoleFunction.UpdateFunction(Function) > 0)
                            MessageBox.Show("Cập nhập chức năng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    
                }
                else
                {
                    RoleFunction newFunction = new RoleFunction(0, textBoxFunctionName.Text, textBoxButton.Text);
                    if (RoleFunction.InsertFunction(newFunction) > 0)
                        MessageBox.Show("Thêm chức năng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.Close();
        }
    }
}