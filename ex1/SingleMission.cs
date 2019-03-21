using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ex1
{
    /// <summary>
    /// handling a single function calculation
    /// </summary>
    class SingleMission : IMission
    {
        // members
        private FunctionsContainer.func function;

        // properties
        public string Name {get;}
        public string Type {get;}        

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="action">a delegate</param>
        /// <param name="name">mission's name</param>
        public SingleMission(FunctionsContainer.func action, string name)
        {
            function = action;
            Type = Constants.TYPE_SINGLE;
            Name = name;
        }

        public event EventHandler<double> OnCalculate;

        /// <summary>
        /// calculates based on the given variable and function and
        /// informes all listeners to this mission.
        /// </summary>
        /// <param name="value">the initial parameter for the function</param>
        /// <returns>double - calculation value</returns>
        public double Calculate(double value)
        {
            double result = function(value);
            OnCalculate?.Invoke(this, result);
            return result;
        }
    }
}
