﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.MachineLearning.VectorMachines;
using Accord.Statistics.Filters;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Analysis;

namespace DiabetesDido.ClassificationLogic
{
    class SVMModel : ClassificationModel
    {
        private SupportVectorMachine svm;

        public SupportVectorMachine SVM
        {
            get { return svm; }
            set { svm = value; }
        }

        public override void TrainningModel(TrainningData trainningData)
        {
            Codification codification = trainningData.CodificationData;
            double[][] inputs = trainningData.TrainningAttributes;
            int[] outputs = trainningData.ClassifierAttributeForSVM;

            // Create a Support Vector Machine for the given inputs
            this.svm = new SupportVectorMachine(inputs[0].Length);

            // Instantiate a new learning algorithm for SVMs
            SequentialMinimalOptimization smo = new SequentialMinimalOptimization(svm, inputs, outputs);

            // Set up the learning algorithm
            smo.Complexity = 1.0;

            // Run the learning algorithm 
            double error = smo.Run();

        }

        public override List<Accord.Statistics.Analysis.ConfusionMatrix> TestModel(TrainningData trainningData)
        {
            int[] expected = trainningData.ClassifierAttributeForSVM;            
            int[] predicted = ComputeModel(trainningData.TrainningAttributes);
            int positiveValue = trainningData.PositiveValueForSVM;
            int negativeValue = trainningData.NegativeValueForSVM;

            ConfusionMatrix confusionMatrix = new ConfusionMatrix(predicted, expected, positiveValue, negativeValue);
            return new List<ConfusionMatrix> { confusionMatrix };
        }

        public override int[] ComputeModel(double[][] inputs)
        {            
            double[] temp = new double[inputs.Length];

            for (int i = 0; i < inputs.Length; i++)
                temp[i] = svm.Compute(inputs[0]);

            int[] predicted = new int[inputs.Length];
            for (int i = 0; i < inputs.Length; i++)
                predicted[i] = System.Math.Sign(svm.Compute(inputs[0]));
            return predicted;
        }
    }
}
