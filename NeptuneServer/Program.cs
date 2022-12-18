﻿using System.Text;

namespace NeptuneServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            NeptuneEnvironment.GetNeptuneEnvironment().Initialize();

            while(true)
            {
                Console.ReadKey();
            }
        }
    }
}