using System;
using System.Diagnostics;
using System.IO;
using AlgorithmLibrary;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var timer = new Stopwatch();
            
            var text = File.ReadAllText("text.txt");
            var subtext = File.ReadAllText("subtext.txt");

            timer.Start();
            var ind = KnuthMorrisPratt.Find(text, subtext);
            timer.Stop();

            Console.WriteLine("My algo:" + "\n" + ind + "\nElapsed time: " + timer.ElapsedMilliseconds + " ms");
            
            timer.Restart();
            var ind2 = text.IndexOf(subtext);
            timer.Stop();
            
            Console.WriteLine("\n.NET algo:" + "\n" + ind2 + "\nElapsed time: " + timer.ElapsedMilliseconds + " ms");
            
        }
    }
}