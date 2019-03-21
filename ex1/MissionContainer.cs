using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
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
                return null;
            }
            set
            {
                if ( container[action] == null)
                {
                    Add(action);
                }
            }
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

        public void Add(string func)
        {
            this.container.Add(func, null);
        }

        public double Double(double value)
        {
            return value * 2;
        }

        public double Triple(double value)
        {
            return value * 3;
        }

        public double Square(double value)
        {
            return value * value;
        }

        public double Sqrt(double value)
        {
            if (value < 0)
            {
                Console.WriteLine("cannot square root a negative number");
                return value;
            }
            return Math.Sqrt(value);
        }

        public double Plus2(double value)
        {
            return value + 2;
        }




    }
}
