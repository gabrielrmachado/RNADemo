using System.Diagnostics;
using System.IO;
using System.Linq;
using SharpLearning.Containers.Matrices;
using SharpLearning.CrossValidation.TrainingTestSplitters;
using SharpLearning.InputOutput.Csv;
using SharpLearning.Metrics.Classification;
using SharpLearning.Neural.Models;
using SharpLearning.Neural;
using SharpLearning.Neural.Optimizers;
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
        public short NumEpocas { get; set; }
        public double TaxaAprendizado { get; set; }
        public double TaxaMomento { get; set; }
        public short AlgoritmoOtimizador { get; set; }

        public MLP()
        {
            _numProcessadoresPorCamada = new List<short>();
            // to load
            // var learner = ClassificationNeuralNetModel().
            // var learner = new ClassificationNeuralNetLearner()

            //// learn the model
            //var model = learner.learn(observations, targets);

            // use the model for predicting new observations

            // save the model for use with another application
            //model.Save(() => new StreamWriter("randomforest.xml"));
        }
    }
}

//public void Classification_Standard_Neural_Net()
//{
//    #region Read Data
//    // Use StreamReader(filepath) when running from filesystem
//    var trainingParser = new CsvParser(() => new StringReader(Resources.mnist_small_train));
//    var testParser = new CsvParser(() => new StringReader(Resources.mnist_small_test));

//    var targetName = "Class";

//    var featureNames = trainingParser.EnumerateRows(c => c != targetName).First().ColumnNameToIndex.Keys.ToArray();

//    // read feature matrix (training)
//    var trainingObservations = trainingParser
//        .EnumerateRows(featureNames)
//        .ToF64Matrix();
//    // read classification targets (training)
//    var trainingTargets = trainingParser.EnumerateRows(targetName)
//        .ToF64Vector();

//    // read feature matrix (test) 
//    var testObservations = testParser
//        .EnumerateRows(featureNames)
//        .ToF64Matrix();
//    // read classification targets (test)
//    var testTargets = testParser.EnumerateRows(targetName)
//        .ToF64Vector();
//    #endregion

//    // transform pixel values to be between 0 and 1.
//    trainingObservations.Map(p => p / 255);
//    testObservations.Map(p => p / 255);

//    // the output layer must know the number of classes.
//    var numberOfClasses = trainingTargets.Distinct().Count();

//    var net = new NeuralNet();
//    net.Add(new InputLayer(width: 28, height: 28, depth: 1)); // MNIST data is 28x28x1.
//    net.Add(new DropoutLayer(0.2));
//    net.Add(new DenseLayer(800, Activation.Relu));
//    net.Add(new DropoutLayer(0.5));
//    net.Add(new DenseLayer(800, Activation.Relu));
//    net.Add(new DropoutLayer(0.5));
//    net.Add(new SoftMaxLayer(numberOfClasses));

//    // using only 10 iteration to make the example run faster.
//    // using classification accuracy as error metric. This is only used for reporting progress.
//    var learner = new ClassificationNeuralNetLearner(net, iterations: 10, loss: new AccuracyLoss());
//    var model = learner.Learn(trainingObservations, trainingTargets);

//    var metric = new TotalErrorClassificationMetric<double>();
//    var predictions = model.Predict(testObservations);

//    Trace.WriteLine("Test Error: " + metric.Error(testTargets, predictions));
//}
