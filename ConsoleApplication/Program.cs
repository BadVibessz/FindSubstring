using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
            var ind = KnuthMorrisPratt.FindAll(text, subtext);
            timer.Stop();

            Console.WriteLine("My algo:" + "\n" + ind + "\nElapsed time: " + timer.ElapsedMilliseconds + " ms");
            Console.WriteLine($"Text: {text.Length} Array: {ind.Length}");

            // timer.Restart();
            // var ind2 = text.ToList().FindAll(c => c == 'a'); // finds not indexes but chars
            // timer.Stop();
            //
            // Console.WriteLine("\n.NET algo:" + "\n" + ind2 + "\nElapsed time: " + timer.ElapsedMilliseconds + " ms");
            // Console.WriteLine($"Text: {text.Length} List: {ind2.Count}");


        }
    }
}