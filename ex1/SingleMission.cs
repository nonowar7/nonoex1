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
        private FunctionsContainer.func function;

        public string Name
        {
            get;
        }

        public string Type
        {
            get;
        }
        
        public event EventHandler<double> OnCalculate;

        public SingleMission(FunctionsContainer.func action, string name)
        {
            function = action;
            Type = Constants.TYPE_SINGLE;
            Name = name;
        }

        public double Calculate(double value)
        {
            double result = function(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}
