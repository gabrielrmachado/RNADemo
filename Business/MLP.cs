using System.Diagnostics;
using System.IO;
using System.Linq;
using SharpLearning.Containers.Matrices;
using SharpLearning.CrossValidation.TrainingTestSplitters;
using SharpLearning.InputOutput.Csv;
using SharpLearning.Metrics.Classification;
using SharpLearning.Neural.Models;
using SharpLearning.Neural;
using SharpLearning.Neural.Activations;
using SharpLearning.Neural.Layers;
using SharpLearning.Neural.Learners;
using SharpLearning.Neural.Loss;
using SharpLearning.DecisionTrees;
using SharpLearning.DecisionTrees.Models;
using System.Collections.Generic;

namespace RNADemo.Business
{
    public class MLP
    {
        private List<short> _numProcessadoresPorCamada;
        private NeuralNet _mlp;

        public short this[int index]
        {
            get 
            {
                try
                {
                    return _numProcessadoresPorCamada[index];
                }
                catch
                {
                    return 0;
                }
            }
            set { _numProcessadoresPorCamada.Add(value); }
        }

        public short NumCamadasEscondidas { get; set; }
        public short NumeroAmostrasTreinamento { get; set; }

        public MLP()
        {
            _numProcessadoresPorCamada = new List<short>();
            // to load
            //var learner = ClassificationNeuralNetModel().
            //var learner = new ClassificationNeuralNetLearner()

            //// learn the model
            //var model = learner.learn(observations, targets);

            // use the model for predicting new observations

            // save the model for use with another application
            //model.Save(() => new StreamWriter("randomforest.xml"));
        }
    }
}
