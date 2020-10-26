// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Threading;

namespace DataStructures_HashTable
{
    /// <summary>
    /// Program Class
    /// </summary>
    class Program
    {
        /// <summary>
        /// calling function in MyMapNodeClass t
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ///splitted the sentence and stored into array
            ///finding the frequency of each element in using count 
            MyMapNode<string, int> myMapNode = new MyMapNode<string, int>(20);
            Program program = new Program();
            string sentence = "Paranoids are paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations"; ;
            String[] word = sentence.Split(' ');
            foreach (string element in word)
            {
                int count = 1;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == element)
                    {
                        count++;
                    }
                }
                myMapNode.Add(element, count - 1);
            }
            Console.WriteLine("***********************************************");
            Console.WriteLine("The frequency of are is : " + myMapNode.Get("are"));
            Console.WriteLine("The frequency of paranoid is : " + myMapNode.Get("paranoid"));
            Console.WriteLine("The frequency of  because : " + myMapNode.Get("because"));
        }
    }
}