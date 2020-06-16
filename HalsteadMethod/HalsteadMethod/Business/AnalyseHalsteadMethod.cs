using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalsteadMethod.Business
{
    class AnalyseHalsteadMethod
    {
        private Dictionary<String, int> list_operators;
        private Dictionary<String, int> list_operands;
        private int beta;
        private int totalOperators;
        private int numberOfOperators;
        private int totalOperands;
        private int numberOfOperands;

        public AnalyseHalsteadMethod(Dictionary<string, int> list_operators, Dictionary<string, int> list_operands)
        {
            this.list_operators = list_operators;
            this.list_operands = list_operands;
            this.CountNumberOfOperands();
            this.CountNumberOfOperators();
            this.CountTotalOperands();
            this.CountTotalOperators();
            this.beta = 18;
        }

        public int TotalOperators { get => totalOperators; set => totalOperators = value; }
        public int NumberOfOperators { get => numberOfOperators; set => numberOfOperators = value; }
        public int TotalOperands { get => totalOperands; set => totalOperands = value; }
        public int NumberOfOperands { get => numberOfOperands; set => numberOfOperands = value; }
        public int Beta { get => beta; set => beta = value; }

        private void CountTotalOperators()
        {
            int sum = 0;
            foreach (KeyValuePair<string, int> item in list_operators)
            {
                sum += item.Value;
            }
            this.totalOperators = sum;
        }
        private void CountTotalOperands()
        {
            int sum = 0;
            foreach (KeyValuePair<string, int> item in list_operands)
            {
                sum += item.Value;
            }
            this.totalOperands = sum;
        }

        private void CountNumberOfOperators()
        {
            this.numberOfOperators = list_operators.Count;
        }

        public void CountNumberOfOperands()
        {
            this.numberOfOperands = list_operands.Count;
        }

        public int ProgramVocaburary()
        {
            return this.numberOfOperands + this.numberOfOperators;
        }

        public int ProgramLength()
        {
            return this.totalOperands + this.totalOperators;
        }

        public double ProgramVolume()
        {
            return ProgramLength() * Math.Log(ProgramVocaburary(), 2);
        }

        public double ProgramDifficulty()
        {
            try
            {
                double x = (double)this.numberOfOperators/2;
                double y = (double)this.totalOperands / this.numberOfOperands;
                return x * y;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double ProgramLevel()
        {
            try
            {
                double x = (double) 2 / this.numberOfOperators;
                double y = (double) this.numberOfOperands / this.totalOperands;
                return x * y;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double ProgramEstimatedLength()
        {
            return this.numberOfOperators * Math.Log(this.numberOfOperators, 2)
                + this.numberOfOperands * Math.Log(this.numberOfOperands, 2);
        }

        public double CalculateEffort()
        {
            try
            {
                return this.ProgramVolume() / this.ProgramLevel();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double CalculateTime()
        {
            return this.CalculateEffort() / Beta;
        }

        public double CalculateRemainingBugs()
        {
            return Math.Pow(CalculateEffort(), (2 / 3)) / 3000;
        }
    }
}
