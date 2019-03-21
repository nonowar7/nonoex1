using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    class SingleMission : IMission
    {
        private string Name;
        private string Type;
        private FunctionsContainer.func function;

        string IMission.Name => throw new NotImplementedException();

        string IMission.Type => throw new NotImplementedException();

        public event EventHandler<double> OnCalculate;

        public SingleMission(FunctionsContainer.func action, string name)
        {
            function = action;
            Type = "Single";
            Name = name;
        }

        public double Calculate(double value)
        {
            Console.WriteLine("starting...");
            Thread.Sleep(2000);

            if (OnCalculate != null)
            {
                double result = this.function(value);
                OnCalculate(this, result);
                return result;
            }
            return 0;
        }
    }
}
