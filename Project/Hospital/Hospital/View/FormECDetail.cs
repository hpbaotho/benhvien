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
    public partial class FormECDetail : Form
    {
        public ExaminationCertificate ECDetail { get; set; }
        public String UserAction { get; set; }
        
        public FormECDetail()
        {
            InitializeComponent();
        }
        public FormECDetail(int staffID, int patientID)
        {
            InitializeComponent();
            textBoxPatientID.Text = patientID.ToString();
            textBoxStaffID.Text = staffID.ToString();
            dateCreate.Value = DateTime.Today;
            comboBoxState.SelectedIndex = 0;
            textBoxResult.Text = "Không có";
            this.UserAction = "add";

            textBoxResult.ReadOnly = true;
            comboBoxState.Enabled = false;
            dateCreate.Enabled = false;
        }
        public FormECDetail(ExaminationCertificate ecDetail, String userAction)
        {
            InitializeComponent();
            this.ECDetail = ecDetail;
            this.UserAction = userAction;
            SetECDetail(ecDetail);
        }
        public FormECDetail(ExaminationCertificate ecDetail, String userAction,int staffID)
        {
            InitializeComponent();
            this.ECDetail = ecDetail;
            this.UserAction = userAction;
            SetECDetail(ecDetail,staffID);
        }
        //This method is for update
        private void SetECDetail(ExaminationCertificate ecDetail)
        {
            textBoxECID.Text = ecDetail.ECID.ToString();;
            textBoxPatientID.Text = ecDetail.PatientID.ToString();
            textBoxStaffID.Text = ecDetail.StaffID.ToString();
            dateCreate.Value = ecDetail.Date;
            textBoxResult.Text = ecDetail.Result;
            textBoxResult.Enabled = false;
            comboBoxState.Enabled = false;
            comboBoxState.SelectedIndex = ecDetail.State;
        }
        //This method is for update result
        private void SetECDetail(ExaminationCertificate ecDetail,int staffID)
        {
            textBoxECID.Text = ecDetail.ECID.ToString(); ;
            textBoxPatientID.Text = ecDetail.PatientID.ToString();
            textBoxStaffID.Text = staffID.ToString(); ;
            dateCreate.Value = ecDetail.Date;
            textBoxResult.Text = ecDetail.Result;
            comboBoxState.SelectedIndex = ecDetail.State;

            dateCreate.Enabled = false;
            comboBoxState.Enabled = false;
        }
        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            try
            {

                if (!superValidator1.Validate())
                    return;
                    if (this.UserAction.Equals("edit"))
                    {
                        ExaminationCertificate newEC = new ExaminationCertificate();
                        newEC = this.ECDetail;
                        newEC.Result = textBoxResult.Text;
                        newEC.State = comboBoxState.SelectedIndex;
                        newEC.Date = dateCreate.Value;
                        DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin phiếu khám bệnh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (ExaminationCertificate.UpdateEC(newEC) > 0)
                                MessageBox.Show("Cập nhập thông tin phiếu khám bệnh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                        
                        
                    }
                    else if (this.UserAction == "updateResult")
                    {
                        ExaminationCertificate newEC = new ExaminationCertificate();
                        newEC.ECID = Convert.ToInt32(textBoxECID.Text);
                        newEC.PatientID = Convert.ToInt32(textBoxPatientID.Text);
                        newEC.StaffID = Convert.ToInt32(textBoxStaffID.Text);
                        newEC.State = 1;
                        newEC.Date = dateCreate.Value;
                        newEC.Result = textBoxResult.Text;
                        if (ExaminationCertificate.UpdateEC(newEC) > 0)
                            MessageBox.Show("Cập nhập kết quả khám bệnh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ExaminationCertificate newEC = new ExaminationCertificate();
                        newEC.ECID = 0;
                        newEC.PatientID = Convert.ToInt32(textBoxPatientID.Text);
                        newEC.StaffID = Convert.ToInt32(textBoxStaffID.Text);
                        newEC.State = comboBoxState.SelectedIndex;
                        newEC.Date = dateCreate.Value;
                        newEC.Result = textBoxResult.Text;
                        if (ExaminationCertificate.InsertEC(newEC) > 0)
                            MessageBox.Show("Thêm phiếu khám bệnh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
