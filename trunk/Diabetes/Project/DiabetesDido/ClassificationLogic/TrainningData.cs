﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Accord.Statistics.Filters;
using Accord.Math;

namespace DiabetesDido.ClassificationLogic
{
    public class TrainningData
    {
        private DataTable discreteValueDatatable;
        private Codification codificationData;
        private double[][] trainningAttributes;
        private int[] classifierAttribute;
        private string[] columnNames;
        private string lastColumnName;
        private int positiveValue = 1;
        private int negativeValue = 0;

        public DataTable DiscreteValueDatatable
        {
            get { return discreteValueDatatable; }
            set { discreteValueDatatable = value; }
        }

        public int NegativeValue
        {
            get { return negativeValue; }
            set { negativeValue = value; }
        }

        public int PositiveValue
        {
            get { return positiveValue; }
            set { positiveValue = value; }
        }

        public string LastColumnName
        {
            get { return lastColumnName; }
            private set { lastColumnName = value; }
        }

        public string[] ColumnNames
        {
            get { return columnNames; }
            private set { columnNames = value; }
        }

        public int[] ClassifierAttribute
        {
            get { return classifierAttribute; }
            private set { classifierAttribute = value; }
        }

        public double[][] TrainningAttributes
        {
            get { return trainningAttributes; }
            private set { trainningAttributes = value; }
        }

        public Codification CodificationData
        {
            get { return codificationData; }
            private set { codificationData = value; }
        }

        public TrainningData(DataTable dataTable, Codification codification)
        {
            Initialize(dataTable, codification);
        }

        private void Initialize(DataTable dataTable, Codification codification)
        {
            this.codificationData = codification;
            this.discreteValueDatatable = this.codificationData.Apply(dataTable);

            List<string> columnNames = new List<string>();

            // Get column's name of training data
            for (int columnIndex = 0; columnIndex < this.discreteValueDatatable.Columns.Count - 1; columnIndex++)
            {
                columnNames.Add(this.discreteValueDatatable.Columns[columnIndex].ColumnName);
            }

            this.ColumnNames = columnNames.ToArray();
            this.lastColumnName = this.discreteValueDatatable.Columns[this.discreteValueDatatable.Columns.Count - 1].ColumnName;

            // Create trainning data
            this.trainningAttributes = this.discreteValueDatatable.ToArray(this.ColumnNames);

            // Create classifier data for trainning
            string lastColumnName = this.discreteValueDatatable.Columns[discreteValueDatatable.Columns.Count - 1].ColumnName;
            this.classifierAttribute = this.discreteValueDatatable.ToIntArray(lastColumnName).GetColumn(0);

            // Set positive, negative value to test model            
            if (this.codificationData.Columns[this.lastColumnName].Mapping.ContainsKey(Properties.Settings.Default.positiveString))
            {
                this.positiveValue = this.codificationData.Columns[this.lastColumnName].Mapping[Properties.Settings.Default.positiveString];
            }

            if (this.codificationData.Columns[this.lastColumnName].Mapping.ContainsKey(Properties.Settings.Default.negativeString))
            {
                this.negativeValue = this.codificationData.Columns[this.lastColumnName].Mapping[Properties.Settings.Default.negativeString];
            }
            
        }
    }
}
