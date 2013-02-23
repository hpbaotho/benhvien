﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DiabetesDido.UI;

namespace DiabetesDido.ClassificationLogic
{
    public class Function
    {
        public static void LamSachDuLieu(DataTable dataSetDT,List<decimal> danhSachViTri)
        {
            for (int i = 0; i < dataSetDT.Rows.Count-1; i++)
            {
                int Flag=0;
                for (int j = 0; j < danhSachViTri.Count; j++)
                {
                    decimal iD=Convert.ToDecimal(dataSetDT.Rows[i][0]);
                    if ( iD == danhSachViTri[j])
                    {
                        Flag = 1;
                        break;
                    }
                }
                if (Flag == 0)
                {
                    for (int j = i + 1; j < dataSetDT.Rows.Count; j++)
                    {
                        decimal iMaBN = Convert.ToDecimal(dataSetDT.Rows[i][1]);
                        decimal jMaBN = Convert.ToDecimal(dataSetDT.Rows[j][1]);
                        if (iMaBN == jMaBN)
                            danhSachViTri.Add(Convert.ToDecimal(dataSetDT.Rows[j][0]));
                        else
                            break;
                    }
                }
            }
        }

        public static String RoiRacHoaTuoi(decimal namSinh)
        {
            if (namSinh < 10)
                return "[0,10)";
            else if (namSinh < 20)
                return "[10,20)";
            else if (namSinh < 30)
                return "[20,30)";
            else if (namSinh < 40)
                return "[30,40)";
            else if (namSinh < 50)
                return "[40,50)";
            else if (namSinh < 60)
                return "[50,60)";
            else if (namSinh < 70)
                return "[60,70)";
            else if (namSinh < 80)
                return "[70,80)";
            else
                return "[80,+)";
        }
        
        //Hàm dùng để xác định khoảng rời rạc của một cột dữ liệu
        public static int XacDinhKhoang(String colName)
        {
            DiabetesDido.DAL.DiabetesDataSetTableAdapters.BayesObjectTableAdapter bayesObjectTA = new DAL.DiabetesDataSetTableAdapters.BayesObjectTableAdapter();
            DataTable dtBayesObject = bayesObjectTA.GetData();
            DataRow[] dtRow = dtBayesObject.Select("TenThuocTinh='" + colName + "'");
            int khoang = 0;
            khoang = dtRow.Count()/2;
            return khoang;
        }

        //Hàm dùng để rời rạc giá trị của cột trong bảng dữ liệu chẩn đoán
        public static String DataDiscretizationForDiagnosis(decimal colValue, String colName)
        {
            
            List<double> listIntervalValues = GetListIntervalValue(colName);
            String DiscretizationValue = FormCustomDataDiscretization.DataDiscretization(colValue, listIntervalValues);
            return DiscretizationValue;
        }

        //Hàm dùng để lấy một tập gồm các khoảng rời rạc của một cột
        public static List<double> GetListIntervalValue(String colName)
        {
            List<double> listIntervalValues = new List<double>();
            if (colName != "GioiTinh")
            {
                DiabetesDido.DAL.DiabetesDataSetTableAdapters.BayesObjectTableAdapter bayesObjectTableAdapter = new DAL.DiabetesDataSetTableAdapters.BayesObjectTableAdapter();
                DataRow[] dtIntervalValue = bayesObjectTableAdapter.GetData().Select("TenThuocTinh='" + colName + "'");
                foreach (DataRow dtRow in dtIntervalValue)
                {
                    String[] listString = dtRow[2].ToString().Split(',');
                    String str = listString[0].Substring(1, listString[0].Length - 1);
                    double intervalValue = Convert.ToDouble(str);
                    if (!listIntervalValues.Contains(intervalValue))
                        listIntervalValues.Add(intervalValue);
                    //Dành cho trường hợp thuộc tính chỉ có 1 khoảng
                    if (dtIntervalValue.Count() == 2)
                    {
                        String secondStr = listString[1].Substring(0, listString[1].Length - 1);
                        double secondIntervalValue = Convert.ToDouble(secondStr);
                        if (!listIntervalValues.Contains(secondIntervalValue))
                            listIntervalValues.Add(secondIntervalValue);
                    }
                }
            }
            return listIntervalValues;
        }
        //Hàm dùng để rời rạc giá trị của cột trong bảng dữ liệu
        public static String DataDiscretization(decimal giaTri,String colName, int khoang)
        {
            DiabetesDido.DAL.DiabetesDataSetTableAdapters.DataSetTableAdapter dataSetTA = new DiabetesDido.DAL.DiabetesDataSetTableAdapters.DataSetTableAdapter();
            DataTable dt = dataSetTA.GetData();
            decimal minValue = Convert.ToDecimal(dt.Compute("min(" + colName + ")", string.Empty));
            decimal maxValue = Convert.ToDecimal(dt.Compute("max(" + colName + ")", string.Empty));
            decimal giaTriMoi=Math.Round((minValue+maxValue)/khoang,3);
            decimal giaTriTrungBinhKhoang = giaTriMoi;
            String giaTriRoiRac = "";
            int iCount=1;

            while (giaTriMoi < giaTri)
            {
                iCount++;
                if (iCount == khoang) break;
                giaTriMoi = giaTriMoi + giaTriTrungBinhKhoang;
                
            };
            if (iCount == 1)
                giaTriRoiRac = "(0," + giaTriMoi.ToString()+")";
            else if (iCount == khoang)
                giaTriRoiRac = "[" + giaTriMoi.ToString() + ",+)";
            else
                giaTriRoiRac ="["+ (giaTriMoi - giaTriTrungBinhKhoang).ToString() + "," + giaTriMoi.ToString() + ")";
            return giaTriRoiRac;
        }

        //Hàm dùng để tại ra các khoảng giá trị đã rời rạc
        public static void TaoBayesObject(String colName,int khoang)
        {
            DiabetesDido.DAL.DiabetesDataSetTableAdapters.BayesObjectTableAdapter BayesObjectTA = new DiabetesDido.DAL.DiabetesDataSetTableAdapters.BayesObjectTableAdapter();
            DiabetesDido.DAL.DiabetesDataSetTableAdapters.DataSetTableAdapter dataSetTA = new DiabetesDido.DAL.DiabetesDataSetTableAdapters.DataSetTableAdapter();
            DataTable dt = dataSetTA.GetData();
            decimal minValue = Convert.ToDecimal(dt.Compute("min(" + colName + ")", string.Empty));
            decimal maxValue = Convert.ToDecimal(dt.Compute("max(" + colName + ")", string.Empty));
            decimal giaTriMoi=Math.Round((minValue+maxValue)/khoang,3);
            decimal giaTriTrungBinhKhoang = giaTriMoi;
            for (int i = 1; i <= khoang; i++)
            {
                String khoangRoiRac="";
                if (i == 1)
                    khoangRoiRac = "(0," + giaTriMoi.ToString() + ")";
                else if (i == khoang)
                    khoangRoiRac = "[" + giaTriMoi.ToString() + ",+)";
                else
                    khoangRoiRac = "[" + (giaTriMoi - giaTriTrungBinhKhoang).ToString() + "," + giaTriMoi.ToString() + ")";
                BayesObjectTA.Insert(colName, khoangRoiRac, 0, "True");
                BayesObjectTA.Insert(colName, khoangRoiRac, 0, "False");
                if (i != khoang - 1)
                    giaTriMoi = giaTriMoi + giaTriTrungBinhKhoang;
            }
        }

        //Hàm dùng để cập nhập lại bảng DataSetTemp sau khi rời rạc hóa một thuộc tính
        public static void CapNhapDataSetTemp(DiabetesDido.DAL.DiabetesDataSetTableAdapters.DataSetTempTableAdapter dataSetTempTA, decimal maBN, String colName, String giaTriRoiRac)
        {
            DataTable dataSetTempTable = dataSetTempTA.GetDataByOne(maBN);
            DataRow newRow = dataSetTempTable.NewRow();
            foreach(DataRow dtRow in dataSetTempTable.Rows)
            {
                newRow = dtRow;
            }
            int colIndex = dataSetTempTA.GetData().Columns.IndexOf(colName);
            newRow[colIndex] = giaTriRoiRac;
            dataSetTempTA.Update(newRow);
        }

        ////Hàm dùng để huấn luyện dữ liệu cho thuật toán Bayes
        //public static void HuyenLuyenBayes()
        //{ 
            
        //}

        ////Hàm dùng để chia dữ liệu theo tỉ lệ nhập vào
        //public void ChiaDuLieu(int phanTramDuLieu)
        //{
        //    DiabetesDido.DAL.DiabetesDataSetTableAdapters.TrainingSetTableAdapter trainingSetTA = new DiabetesDido.DAL.DiabetesDataSetTableAdapters.TrainingSetTableAdapter();
        //    DiabetesDido.DAL.DiabetesDataSetTableAdapters.TestSetTableAdapter testSetTA = new DiabetesDido.DAL.DiabetesDataSetTableAdapters.TestSetTableAdapter();
        //    DiabetesDido.DAL.DiabetesDataSetTableAdapters.DataSetTempTableAdapter dataSetTempTA = new DiabetesDido.DAL.DiabetesDataSetTableAdapters.DataSetTempTableAdapter();
        //    DataTable dtSetTemp=dataSetTempTA.GetData();
        //    int luongDuLieu = dtSetTemp.Rows.Count * phanTramDuLieu / 100;
        //    int iCount = 0;
        //    trainingSetTA.DeleteAll();
        //    testSetTA.DeleteAll();
        //    foreach (DataRow dtRow in dtSetTemp.Rows)
        //    {
                
        //        if (iCount < luongDuLieu)
        //        {
        //            trainingSetTA.Insert(Convert.ToDecimal(dtRow[1]),dtRow[2].ToString(), dtRow[3].ToString(), dtRow[4].ToString(), dtRow[5].ToString(), dtRow[6].ToString(), dtRow[7].ToString(), dtRow[8].ToString(), dtRow[9].ToString(), dtRow[10].ToString(), dtRow[11].ToString(), dtRow[12].ToString(), dtRow[13].ToString(), dtRow[14].ToString(), dtRow[15].ToString(), dtRow[16].ToString(), dtRow[17].ToString(), dtRow[18].ToString(), dtRow[19].ToString(), dtRow[20].ToString(), dtRow[21].ToString(), dtRow[22].ToString(), dtRow[23].ToString(), dtRow[24].ToString(), dtRow[25].ToString(), dtRow[26].ToString(), dtRow[27].ToString(), dtRow[28].ToString(), dtRow[29].ToString(), dtRow[30].ToString(), dtRow[31].ToString(), dtRow[32].ToString(), dtRow[33].ToString(),dtRow[34].ToString());
        //        }
        //        else
        //        {
        //            testSetTA.Insert(Convert.ToDecimal(dtRow[1]), dtRow[2].ToString(), dtRow[3].ToString(), dtRow[4].ToString(), dtRow[5].ToString(), dtRow[6].ToString(), dtRow[7].ToString(), dtRow[8].ToString(), dtRow[9].ToString(), dtRow[10].ToString(), dtRow[11].ToString(), dtRow[12].ToString(), dtRow[13].ToString(), dtRow[14].ToString(), dtRow[15].ToString(), dtRow[16].ToString(), dtRow[17].ToString(), dtRow[18].ToString(), dtRow[19].ToString(), dtRow[20].ToString(), dtRow[21].ToString(), dtRow[22].ToString(), dtRow[23].ToString(), dtRow[24].ToString(), dtRow[25].ToString(), dtRow[26].ToString(), dtRow[27].ToString(), dtRow[28].ToString(), dtRow[29].ToString(), dtRow[30].ToString(), dtRow[31].ToString(), dtRow[32].ToString(), dtRow[33].ToString(), dtRow[34].ToString());
        //        }
        //        iCount++;
        //    }

        //}        
        
    }
}