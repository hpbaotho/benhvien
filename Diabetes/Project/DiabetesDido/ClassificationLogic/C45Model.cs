﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Statistics.Filters;

namespace DiabetesDido.ClassificationLogic
{
    public class C45Model : DecisionTreeModel
    {
        // Trainning decision tree with C4.5 algorithm
        public override void TrainningModel(ClassificationData classificationData)
        {
            Codification codification = classificationData.DiscreteCodification;
            double[][] inputs = classificationData.DoubleTrainningAttributes;
            int[] outputs = classificationData.ClassifierAttribute;            

            // Create tree
            this.Tree = this.CreateDecisionTree(codification);            
            // Creates a new instance of the C4.5 learning algorithm
            C45Learning c45 = new C45Learning(this.Tree);

            // Learn the decision tree
            double error = c45.Run(inputs, outputs);
        }
    }
}
