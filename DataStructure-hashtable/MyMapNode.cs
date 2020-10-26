// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyMapNode.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures_HashTable
{
    class MyMapNode<K, V>
    {
        public struct KeyValue<k, v>
        {
            /// <summary>
            /// Initialising data 
            /// </summary>
            public k Key { get; set; }
            public v Value { get; set; }
            ///struct is basically used to hold data Together like key value in this case
            /// it can be used just like a class and it is helping to link key value together in a linkedlist  
        }
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        /// it is basically an array with data type LinkedList 
        /// LinkedList can store all key value pairs 

        /// <summary>
        /// Parameterised Constructor
        /// </summary>
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
            ///initialising array with size           
        }

        /// <summary>
        /// Getting array position 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        protected int GetArrayPosition(K Key)
        {
            ///we are storing linkedlist with key value pairs at different positions of array
            ///each linkedlist has a node which stores key value pairs 
            ///we are assigning a position of an array to a likedlist
            ///when we have multiple key value pairs so it becomes difficult to access 
            ///that is the reason for storing it at different array positions

            ///using gethascode function(inbuilt) we get a random value to store our linkedlist
            int hash = Key.GetHashCode();
            ///to store our linkedlist at systematic positions in array we take remainder by dividing with size
            int position = Key.GetHashCode() % size;
            ///sometimes negative values are there we use Maths.Abs to take modulus
            return Math.Abs(position);
        }

        /// <summary>
        /// Getting the value
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public V Get(K Key)
        {
            ///here we are getting the value stored at that particular key 
            ///first we get the position in array for that key
            ///then we get the linkedlist for that position
            ///using foreach we find out the the value using key
            ///otherwise return default 
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(Key))
                    return item.Value;
            }
            return default(V);
        }

        /// <summary>
        /// Adding key and value to linkedlist
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            ///given key and value we find the array position and get the linkedlist with that
            ///adding item into linkedlist
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>()
            { Key = key, Value = value };
            ///checking so that no duplicate value is added to linkedlist when add is called from main
            foreach (KeyValue<K, V> element in linkedList)
            {
                for (int i = 0; i < linkedList.Count; i++)
                {
                    if (linkedList.Contains(item))
                    {
                        return;
                    }
                }
            }
            linkedList.AddLast(item);
            Console.WriteLine("Added  " + item.Key + ":" + item.Value);
        }

        /// <summary>
        /// removing a key value pair
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            ///getting position in array
            ///getting a linkedlist with the position
            ///then checking if item is found while iterating
            ///if founditem is true then it removes the item from linkedlist
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> Founditem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> element in linkedList)
            {
                if (element.Key.Equals(key))
                {
                    itemFound = true;
                    Founditem = element;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(Founditem);
            }
        }

        /// <summary>
        /// getting the linkedlist
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            ///accesing the linkedlist present at position in items array 
            ///if the linkedlist is empty it is initialising a new linkedlist
            ///otherwise return the same accessed linkedlist because it contains some element
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        /// <summary>
        /// Display Function
        /// </summary>
        public void Display()
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                    foreach (var element in linkedList)
                    {
                        string value = element.ToString();//converting element to string from KeyValue<k,v>                     
                        if (value != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
            }
        }
    }
}