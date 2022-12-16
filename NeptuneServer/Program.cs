using System.Text;

namespace NeptuneServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NeptuneEnvironment.GetNeptuneEnvironment().Initialize();

            while(true)
            {
                Console.ReadKey();
            }
        }
    }
}