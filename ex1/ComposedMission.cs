using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    class ComposedMission : IMission
    {
        private string Name;
        private string Type;
        private List<FunctionsContainer.func> missions;

        string IMission.Name => throw new NotImplementedException();

        string IMission.Type => throw new NotImplementedException();

        public delegate double func(double value);

        public event EventHandler<double> OnCalculate;

        public ComposedMission(string name, List<FunctionsContainer.func> actions)
        {
            missions = actions;
            Type = "Composed";
            Name = name;
        }
        
        public void Add(FunctionsContainer.func f)
        {
            this.missions.Add(f);
        }

        public double Calculate(double value)
        {
            if (OnCalculate!= null)
            {
                double result=0;
                foreach ( FunctionsContainer.func f in missions)
                {
                    result += f(value);
                    OnCalculate(this, result);
                }
                return result;

            }
            return 0;
        }
    }
}
