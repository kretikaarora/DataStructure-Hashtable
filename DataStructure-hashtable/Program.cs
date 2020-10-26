// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;

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
            string sentence = "to be or not to be";
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
            Console.WriteLine("The frequency of to is : " + myMapNode.Get("to"));
            Console.WriteLine("The frequency of or is : " + myMapNode.Get("or"));
            Console.WriteLine("The frequency of not : " + myMapNode.Get("not"));
        }
    }
}