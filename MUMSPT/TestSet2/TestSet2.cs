﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUMSPT.TestSet2
{
    public static class TestSet2
    {
        /// <summary>
        ///<![CDATA[
        /// Define a square pair to be the tuple <x, y> 
        /// where x and y are positive, non-zero integers, 
        /// x<y and x + y is a perfect square. 
        /// A perfect square is an integer whose square root is also an integer, 
        /// e.g. 4, 9, 16 are perfect squares 
        /// but 3, 10 and 17 are not. 
        /// Write a function named countSquarePairs that takes 
        /// an array and returns the number of square pairs that can be 
        /// constructed from the elements in the array. 
        /// For example, if the array is {11, 5, 4, 20} 
        /// the function would return 3 because the only square pairs 
        /// that can be constructed from those numbers are <5, 11>,<5, 20> and<4, 5>.
        /// ]]> 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int countSquarePairs(int[] a)
        {
            int count = 0;
            int x = 0, y = 0;
            for (int i = 0; i < a.Length ; i++)
            {
                x = a[i];
                for (int j = 0; j < a.Length && x > 0; j++)
                {
                    y = a[j];
                    if (x < y && Helper.isPerfectSquare(x + y))
                        count++;
                }
            }
            
            return count;
        }

        /// <summary>
        /// A prime number is an integer that is divisible only by 1 and itself.
        ///  A porcupine number is a prime number whose last digit is 9 
        /// and the next prime number that follows it also ends with the digit 9.
        ///  For example 139 is a porcupine number because:
        /// </summary>
        /// <param name="n"></param>
        /// <returns>A porcupine number</returns>
        public static int findPorcupineNumber(int n)
        {
            int porcupine = -1,nextPrime = -1;
            do
            {
                n++;
                if (porcupine == -1 && Helper.isPrime(n) &&  (n % 10 == 9))
                {
                    porcupine = n;
                }

               while (porcupine > -1 && nextPrime == -1) // check for next prime
                {
                    n++;
                    if (Helper.isPrime(n))
                    {
                        nextPrime = n;
                        if (nextPrime % 10 != 9)
                        {
                            // reset the porcupine and nextprime 
                            porcupine = -1; nextPrime = -1;
                        }
                    }
                }
            }
            while (porcupine == -1 && nextPrime == -1);

            return porcupine;
        }

        /// <summary>
        /// The Guthrie sequence of a positive number n is defined to be the numbers generated by the above algorithm.
        /// For example, the Guthrie sequence of the number 7 is
        /// 7,  22, 11, 34, 17, 52, 26, 13, 40, 20, 10, 5, 16, 8, 4, 2, 1
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int isGuthrieSequence(int[] a)
        {
            int isGuthie = 1;
            // check for the last element
            if (a[a.Length - 1] != 1) return 0;

            int currentnumber = a[0];

            for (int i = 1; i < a.Length && isGuthie == 1; i++)
            {
                if (currentnumber % 2 == 0)
                {
                    if (a[i] != currentnumber / 2) isGuthie = 0;
                }
                else
                {
                    if (a[i] != currentnumber * 3 + 1) isGuthie = 0;
                }
                currentnumber = a[i];
            }

            return isGuthie;
        }
    }
}