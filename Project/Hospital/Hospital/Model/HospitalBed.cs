﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Model
{
    class HospitalBed
    {
        private int bedID;
        private String patient;
        private int state;

        public int State
        {
            get { return state; }
            set { state = value; }
        }

        public String Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public int BedID
        {
            get { return bedID; }
            set { bedID = value; }
        }
        public Boolean InsertHospitalBed()
        {
            return true;
        }
        public Boolean UpdateHospitalBed()
        {
            return true;
        }
        public Boolean DeleteHospitalBed()
        {
            return true;
        }
        public Boolean ChangeHospitalBed()
        {
            return true;
        }
        public List<HospitalBed> GetListHospitalBed()
        {
            List<HospitalBed> lstHB = new List<HospitalBed>();

            return lstHB;
        }
        public HospitalBed GetHospitalBed()
        {
            HospitalBed hB = new HospitalBed();

            return hB;
        }
    }
}
