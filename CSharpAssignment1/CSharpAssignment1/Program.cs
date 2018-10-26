using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment1
{
    class _TwoDArray1
    {
        //static void Main(string[] args)
        public void run()         {

            string[,] _matrix = new string[,]
            {
                {"AElement1","AElement2","AElement3" },
                {"BElement1","BElement2","BElement3" },
                {"CElement1", "CElement2","CElement3"}

            };

            for (int i = 0; i <= _matrix.GetUpperBound(0); i++)
            {
                Console.WriteLine("{0}  {1}  {2}", _matrix[i,0], _matrix[i, 1], _matrix[i, 2]);
            }

            Console.ReadLine();
           
        }
    }
}
