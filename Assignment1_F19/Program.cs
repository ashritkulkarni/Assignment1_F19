using System;
using System.Linq;

// Name: Ashrit Kulkarni
// Date: 09/22/2019

namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inputs for First code
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);
            Console.Write("\n");
            Console.WriteLine("---------------- End of First Code----------------");
            Console.Write("\n");

            // Inputs for Second code
            int n2 = 5;
            printSeries(n2);
            Console.Write("\n");
            Console.Write("\n");
            Console.WriteLine("---------------- End of Second Code----------------");
            Console.Write("\n");

            // Inputs for Third code
            int n3 = 5;
            printTriangle(n3);
            Console.Write("\n");
            Console.WriteLine("---------------- End of Third Code----------------");
            Console.Write("\n");

            // Inputs for Fourth code
            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones(J, S);
            Console.WriteLine(r4);
            Console.Write("\n");
            Console.WriteLine("---------------- End of Fourth Code----------------");
            Console.Write("\n");

            // Inputs for Fifth code
            int[] arr1 = new int[] { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 3, 4, 5 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            Console.WriteLine(r5);
            Console.Write("\n");
            Console.WriteLine("---------------- End of Fifth Code----------------");
            

        }

 /////////////////////////////////////        Print Self Diving Numbers          //////////////////////////////////////
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                int first = x;
                int last = y;
                int N = last - first + 1;
                //int[] a = new int[N];
                for (int i = first; i <= last; i++)
                {
                    //Calling the isSelfDividing method to check the selfdivisibility rule
                    if (isSelfDividing(i))
                    {

                        Console.Write(i + " ");
                    }

                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        // Check the selfdivisibility rule
        static bool isSelfDividing(int n)
        {
            string[] intList = n.ToString().Select(digit => digit.ToString()).ToArray<string>();

            // To check if any of the digit within the number is '0', as number cannot be divisible by '0'
            if (intList.Contains("0"))
            {
                return false;
            }
            for (int i = 0; i < intList.Length; i++)
            {
                // To check if atleast one of the digits is not dividing the number so as to return false
                if (n % int.Parse(intList[i]) != 0)
                {
                    return false;
                }
            }
            return true;
        }
      

///////////////////////////////////////////////     Print Series     /////////////////////////////////////////////////
public static void printSeries(int n)
        {
            try
            {
                //declaring variable for loops
                int i, j;

                int count = 0;

                for (i = 0; i < n; i++)
                {
                    //Loop to have the number 'n' to be printed 'n' number of times
                    for (j = 0; j < i; j++)
                    {

                        Console.Write(i + " "); //Displaying the digits for each iteration
                        count = count + 1; // Increament of count

                        // Check if the count of numbers printed is not exceeding the lenght. If yes then exit
                        if (count == n)
                        {
                            return;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

////////////////////////////////////////////   Print Triangle Pattern    //////////////////////////////////////////////
        public static void printTriangle(int n)
        {
            try
            {
                int i, j;

                for (i = n; i > 0; i--) // loop for number of rows
                {
                    for (j = n - i; j > 0; j--) // loop to create spaces in order to display the reverse triangle
                    {
                        Console.Write(" ");
                    }
                    for (j = (2 * i - 1); j > 0; j--) // loop to display the number of stars per each row
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }
///////////////////////////////////////////    Jewels in Stones     /////////////////////////////////////////////////
        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                int i, j, r;
                r = 0;
                for (i = 0; i < S.Length; i++) // Loop to compare each and every element with the Jewel Set
                {
                    for (j = 0; j < J.Length; j++) // Loop to get compared with each and every of Jewel set with each element of Stone set
                    {
                        if (S[i] == J[j])
                        {
                            r = r + 1; // Store the count of number of stones which are jewels

                        }

                    }

                }

                return r;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }

////////////////////////////////////////////    Largest Common Sub Array     //////////////////////////////////////////
        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            try
            {
                int i, j, l;
                j = 0;
                int len = 0;
                int maxlen = 0;
                int end = 0;
                for (i = 0; i < a.Length; i++) // Loop to consider each and every element of 'a' set to compare
                    // with the subsequent element of 'b' set to to find the array
                {
                    if (j >= b.Length) // if the initial point of the loop which is getting compared by each element 
                        // pointer exceeds the length of 'b' set then exit to stop storing garbage value
                    {
                        break;
                    }
                    for (; j < b.Length; j++) // Loop which helps in comparing each element of set 'b'
                    {
                        if (a[i] == b[j]) // if element of set 'a' is equal to set 'b' then increase the length (counter)
                            // and also increase the count of j                           
                        {
                            len++;
                            j++;
                            break;
                        }
                        else // if element is not equal it should get compared with the next elements of the relevant arrays
                        {
                            if (len >= maxlen)
                            {
                                maxlen = len; // to have a track of the maximum length of the consequency
                                end = i - 1; // to set the index of the last similar element in each array
                            }

                            len = 0; // reset the value once the max length is replaced to have a new counter
                            if (a[i] < b[j]) // To compare with the next element of set 'a' for tracking the similarity
                            {
                                break;
                            }
                        }
                    }
                }
                if (len >= maxlen) // Updating the maximum length and Index if the loop exits at the end
                {
                    maxlen = len;
                    end = i - 1;
                }
                for (l = end - maxlen + 1; l <= end; l++) // Display the elements of the array
                {
                    Console.Write(a[l] + " ");
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing getLargestCommonSubArray()");
            }

            return null; // return the actual array
        }

       
        }
    }


