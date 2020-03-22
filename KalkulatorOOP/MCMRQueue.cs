using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorException;

//namespace KalkulatorOOP
//{
    public class MCMRQueue<T> : Queue<T>
    {
        private int maxElmt;
        public MCMRQueue() : base()
        {

        }

        public MCMRQueue(int cap) : base(cap)
        {
            this.maxElmt = cap;
        }

        public void Push(T val)
        {
            if (this.Count == this.maxElmt)
            {
                this.Dequeue();
            }
            this.Enqueue(val);
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new QueueEmptyException();
            } else
            {
                return this.Dequeue();
            }
        }

        public void PrintQueue()
        {
            foreach(T elmt in this)
            {
                Console.WriteLine("- {0}", elmt);
            }
        }
    }
//}
