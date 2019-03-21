using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    /// <summary>
    /// handling calculation of composition of functions
    /// </summary>
    class ComposedMission : IMission
    {
        // members
        private List<FunctionsContainer.func> missions;

        // properties
        public string Name {get;}
        public string Type {get;}

        // ctor
        public ComposedMission(string name)
        {
            Name = name;
            Type = Constants.TYPE_COMPOSED;
            missions = new List<FunctionsContainer.func>();
        }

        public event EventHandler<double> OnCalculate;
        
        /// <summary>
        /// adds a new delegate ptr to known formula function to the private list 
        /// </summary>
        /// <param name="f">a delegate</param>
        /// <returns>this ComposedMission object</returns>
        public ComposedMission Add(FunctionsContainer.func f)
        {
            missions.Add(f);
            return this;
        }

        /// <summary>        
        /// calculates the result of the function's composition
        /// based on the functions in the list and given value.
        /// informes all listeners to this mission.
        /// also informes all listeners to this mission.
        /// </summary>
        /// <param name="value"> a double for composition start</param>
        /// <returns>final result</returns>
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



