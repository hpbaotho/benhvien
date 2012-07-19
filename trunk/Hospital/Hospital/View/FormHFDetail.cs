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
    public partial class FormHFDetail : Form
    {
        public HeathFile HFDetail { get; set; }
        public String UserAction { get; set; }
        public FormHFDetail()
        {
            InitializeComponent();
            SetAutoComplete();
        }
        public FormHFDetail(int patientID)
        {
            InitializeComponent();
            SetHFDetail(patientID);
        }
        public FormHFDetail(HeathFile hfDetail, String userAction)
        {
            InitializeComponent();
            this.UserAction = userAction;
            SetHFDetail(hfDetail);
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //For add feature
        private void SetHFDetail(int patientID)
        {
            textBoxPatientID.Text = patientID.ToString();
            dateCreate.Enabled = false;
            dateCreate.Value = DateTime.Today;
        }
        //For edit feature
        private void SetHFDetail(HeathFile hfDetail)
        {
            textBoxHFID.Text = hfDetail.HeathFileID.ToString();
            textBoxPatientID.Text = hfDetail.PatientID.ToString();
            dateCreate.Value = hfDetail.Date;
            textBoxPatientState.Text = hfDetail.PatientState;
            textBoxPrehistory.Text = hfDetail.PreHistory;
            textBoxDisease.Text = hfDetail.PreHistory;
            textBoxTreatment.Text = hfDetail.Treament;
        }
        private void SetAutoComplete()
        {
            DataTable dtPatientID = Patient.GetListPatientID();
            for (int i = 0; i < dtPatientID.Rows.Count; i++)
            {
                textBoxPatientID.AutoCompleteCustomSource.Add(dtPatientID.Rows[i][0].ToString());
            }
        }

        private void buttonOk_Click(object sender, System.EventArgs e)
        {
            if (!superValidator1.Validate())
                return;
                if (Patient.IsPatientExist(int.Parse(textBoxPatientID.Text)))
                {
                    try
                    {
                        if (UserAction == "edit")
                        {
                            HeathFile newHF = new HeathFile();
                            newHF.HeathFileID = int.Parse(textBoxHFID.Text);
                            newHF.PatientID = int.Parse(textBoxPatientID.Text);
                            newHF.PatientState = textBoxPatientState.Text;
                            newHF.PreHistory = textBoxPrehistory.Text;
                            newHF.Disease = textBoxDisease.Text;
                            newHF.Treament = textBoxTreatment.Text;
                            newHF.Date = dateCreate.Value;
                            DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin bệnh án", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (HeathFile.UpdateHeathFile(newHF) > 0)
                                    MessageBox.Show("Cập nhập thông tin bệnh án thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                        }
                        else
                        {
                            if (HeathFile.DidPatientHaveHF(int.Parse(textBoxPatientID.Text)))
                            {
                                MessageBox.Show("Bệnh nhân đã có bệnh án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                HeathFile newHF = new HeathFile();
                                newHF.HeathFileID = 0;
                                newHF.PatientID = int.Parse(textBoxPatientID.Text);
                                newHF.PatientState = textBoxPatientState.Text;
                                newHF.PreHistory = textBoxPrehistory.Text;
                                newHF.Disease = textBoxDisease.Text;
                                newHF.Treament = textBoxTreatment.Text;
                                newHF.Date = dateCreate.Value;
                                if(HeathFile.InsertHeathFile(newHF)>0)
                                    MessageBox.Show("Thêm bệnh án thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Bệnh nhân không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
            this.Close();
        }
    }
}
