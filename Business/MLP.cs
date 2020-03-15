using System.Diagnostics;
using System.IO;
using System.Linq;
using SharpLearning.Containers.Matrices;
using SharpLearning.CrossValidation.TrainingTestSplitters;
using SharpLearning.InputOutput.Csv;
using SharpLearning.Metrics.Classification;
using SharpLearning.InputOutput.Csv;
using RNADemo.Properties;
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
using System;

namespace RNADemo.Business
{
    public class MLP
    {
        private List<int> _numProcessadoresPorCamada;
        private NeuralNet _net;
        public ClassificationNeuralNetModel Modelo;
        public F64Matrix AmostrasTreinamento, AmostrasTeste;
        public double[] ClassesTreinamento, ClassesTeste;

        public int this[int index]
        {
            get 
            {
                try { return _numProcessadoresPorCamada[index]; }
                catch { return 0; }
            }
            set { _numProcessadoresPorCamada.Add(value); }
        }

        public short NumCamadasEscondidas { get; set; }
        public int NumeroAmostrasTreinamento { get; set; }
        public short NumEpocas { get; set; }
        public double TaxaAprendizado { get; set; }
        public double TaxaMomento { get; set; }
        public short AlgoritmoOtimizador { get; set; }

        public MLP()
        {
            _numProcessadoresPorCamada = new List<int>();
            _net = new NeuralNet();
        }

        public void ConstruirRede()
        {
            

            _net.Add(new InputLayer(20));

            foreach (var numProcessadores in _numProcessadoresPorCamada)
                _net.Add(new DenseLayer(numProcessadores, Activation.Sigmoid));
        }

        public void TreinarRede()
        {
            _net.Add(new SoftMaxLayer(ClassesTreinamento.Distinct().Count()));

            var learner = new ClassificationNeuralNetLearner(_net, loss: new AccuracyLoss(), learningRate: TaxaAprendizado, iterations: NumEpocas,
                        batchSize: 1, optimizerMethod: (OptimizerMethod)AlgoritmoOtimizador, momentum: TaxaMomento);

            Modelo = learner.Learn(AmostrasTreinamento, ClassesTreinamento);
        }

        public Dictionary<double,double> AvaliarAmostra(double[] amostra)
        {
            return Modelo.PredictProbability(amostra).Probabilities;
        }

        public void SalvarAmostras(string path)
        {
            using (StreamWriter outfile = new StreamWriter(Path.Combine(path, "amostrasTreinamento.csv")))
            {
                for (int i = 0; i < AmostrasTreinamento.RowCount; i++)
                {
                    string content = "";
                    for (int j = 0; j < AmostrasTreinamento.ColumnCount; j++)
                    {
                        if (j < AmostrasTreinamento.ColumnCount-1)
                            content += AmostrasTreinamento[i, j].ToString() + ";";
                        else
                            content += AmostrasTreinamento[i, j].ToString();
                    }
                    outfile.WriteLine(content);
                }
            }

            using (StreamWriter outfile = new StreamWriter(Path.Combine(path, "classesTreinamento.csv")))
            {
                string content = "";
                for (int i = 0; i < ClassesTreinamento.Length; i++)
                {
                    if (i < ClassesTreinamento.Length - 1)
                            content += ClassesTreinamento[i].ToString() + ";";
                        else
                        content += ClassesTreinamento[i].ToString();
                }
                outfile.WriteLine(content);
            }
        }

        public ClassificationNeuralNetModel CarregarRede(string path)
        {
            var modelo = ClassificationNeuralNetModel.Load(() => new StreamReader(path));
            return modelo;
        }

        public void CarregarAmostras(string[] paths)
        {
            if (paths.Length != 2)
                throw new ArgumentException("Devem ser fornecidos dois arquivos .CSV, correspondentes às amostras e às classes.");

            using (StreamReader reader = new StreamReader(paths[1]))
            {
                var classesAmostra = reader.ReadLine().Split(';');
                
                NumeroAmostrasTreinamento = classesAmostra.Length;
                AmostrasTreinamento = new F64Matrix(NumeroAmostrasTreinamento, 20);
                ClassesTreinamento = new double[NumeroAmostrasTreinamento];

                for (int i = 0; i < classesAmostra.Length; i++)
                    ClassesTreinamento[i] = double.Parse(classesAmostra[i]);
            }

            using (StreamReader reader = new StreamReader(paths[0]))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    var valoresAmostra = reader.ReadLine().Split(';');
                    
                    for (int j = 0; j < valoresAmostra.Length; j++)
                        AmostrasTreinamento[i, j] = double.Parse(valoresAmostra[j]);

                    i++;                    
                }
            }
        }

        public string getNomeAlgoritmoOtimizacao()
        {
            return Enum.GetName(typeof(OptimizerMethod), AlgoritmoOtimizador).ToUpper();
        }

        public string getTopologiaRedeNeural()
        {
            string topologia = "20 - ";
            foreach (var camada in _numProcessadoresPorCamada)
            {
                topologia += string.Format("{0} - ", camada);
            }
            return topologia += "10";
        }

        public void SalvarRede(string path)
        {
            Modelo.Save(() => new StreamWriter(Path.Combine(path, "rede.xml")));
        }
    }
}
