using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    class ComposedMission : IMission
    {
        private List<FunctionsContainer.func> missions;

        public string Name
        {
            get;
        }

        public string Type
        {
            get;
        }

        public event EventHandler<double> OnCalculate;

        public ComposedMission(string name)
        {
            Name = name;
            Type = Constants.TYPE_COMPOSED;
            missions = new List<FunctionsContainer.func>();
        }
        
        public ComposedMission Add(FunctionsContainer.func f)
        {
            missions.Add(f);
            return this;
        }

        public double Calculate(double value)
        {
            double result = value;
            foreach (FunctionsContainer.func f in missions)
            {
                result = f(result);
            }
            OnCalculate?.Invoke(this, result);
            return result;
            
        }
    }
}



