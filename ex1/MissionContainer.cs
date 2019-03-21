using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    static class Constants
    {
        public const string TYPE_COMPOSED = "Composed";
        public const string TYPE_SINGLE = "Single";
    }

    class FunctionsContainer
    {
        public delegate double func(double value);

        private Dictionary<string, func> container;

        public FunctionsContainer()
        {
            this.container = new Dictionary<string, func>();
        }

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
                return Stam;
            }
            set
            {
                container[action] = value;
            }
        }

        public double Stam(double value)
        {
            return value;
        }

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
