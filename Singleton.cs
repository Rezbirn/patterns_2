using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_2
{
    public class Singleton
    {
        private static Singleton instance;
        private static object locker = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get 
            {
                lock(locker) 
                {
                    if (instance == null) 
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }

        public void DoSomething()
        {
            Console.WriteLine($"{nameof(Singleton)}: Something");
        }

    }
}
