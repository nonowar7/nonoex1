using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    /// <summary>
    /// static class for constants in the program
    /// </summary>
    static class Constants
    {
        public const string TYPE_COMPOSED = "Composed";
        public const string TYPE_SINGLE = "Single";
    }

    /// <summary>
    /// an instance of this class is a dictionary data structure that holds
    /// a reference from a function name to the function based on 'func' delegate.
    /// </summary>
    class FunctionsContainer
    {

        public delegate double func(double value);

        // members
        private Dictionary<string, func> container;
        
        // ctor
        public FunctionsContainer()
        {
            this.container = new Dictionary<string, func>();
        }

        /// <summary>
        /// indexer creation, based on the private dictionary
        /// if the key given does not exist we return the identity function
        /// </summary>
        /// <param name="action">a string(key)</param>
        /// <returns>delegate type ptr to function(value)</returns>
        public func this[string action]
        {
            get
            {
                foreach (string s in container.Keys)
                {
                    if (s.Equals(action))
                    {
                        return container[s];
                    }
                }
                container[action] = Identity;
                return Identity;
            }
            set
            {
                container[action] = value;
            }
        }

        /// <summary>
        /// identity function - returns the value that was given
        /// </summary>
        /// <param name="value">a double</param>
        /// <returns>a double</returns>
        public double Identity(double value)
        {
            return value;
        }

        /// <summary>
        /// creating a list of strings that represents the functios 
        /// stored in the dictionary
        /// </summary>
        /// <returns>list of strings</returns>
        public List<string> getAllMissions()
        {
            List<string> missions = new List<string>();
            foreach (var v in container )
            {
                missions.Add(v.Key);
            }
            return missions;
        }

    }
}
