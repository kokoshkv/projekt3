using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace P3
{
    class Program
    {
        public static Stopwatch liczczas = new Stopwatch();
        
        
        private static int[] Losowe(int size)
        {
            Random rnd = new Random();
            int[] tab = new int[size];
            for (int i = 0; i < tab.Length; i++)
                tab[i] = rnd.Next();
            return tab;
        }


        private static int[] Stale(int size)
        {
            return new int[size];
        }


        private static int[] Rosnaco(int size)
        {
            int[] tab = new int[size];
            for (int i = 0; i < tab.Length; i++)
                tab[i] = i;
            return tab;
        }


        private static int[] Malejaco(int size)
        {
            int[] tab = new int[size];
            for (int i = 0; i < tab.Length; i++)
                tab[tab.Length-1-i] = i;
            return tab;
        }


        private static int[] Vksztaltne(int size)
        {
            int[] array = new int[size];
            int Vsh = size / 2;

            for(int i = 0; i < size; i++)
            {
                if (i < size / 2)
                    array[i] = Vsh--;
                else
                    array[i] = Vsh++;
            }

            return array;
        }
        

        static void CocktailSort (int[] tab)
        {
            bool swapped = true;
            uint start = 0;
            int end = tab.Length;

            while (swapped == true)
            {
                swapped = false;
                for (uint i = start; i < end - 1; ++i )
                {
                    if(tab[i] > tab [i+1])
                    {
                        int temp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;

                swapped = false;
                end = end - 1;

                for(int i = end - 1; i >= start; i--)
                {
                    if(tab[i]>tab[i+1])
                    {
                        int temp = tab[i];
                        tab[i] = tab[i + 1];
                        tab[i + 1] = temp;
                        swapped = true;
                    }
                }

                start = start + 1;
            }
        }


        static void InsertionSort(int[] tab)
        {
            for(uint i = 1; i < tab.Length; i++)
            {
                uint j = i;
                int temp = tab[j];

                while((j>0)&&(tab[j-1]>temp))
                {
                    tab[j] = tab[j - 1];
                    j--;
                }
                tab[j] = temp;
            }
        }


        static void SelectionSort(int[] tab)
        {
            uint x;
            for(uint i = 0; i < (tab.Length - 1); i++)
            {
                int temp = tab[i];
                x = i;
                for (uint j = i + 1; j < tab.Length; j++)
                {
                    
                    if (tab[j] < temp)
                    {
                        x = j;
                        temp = tab[j];
                    }
                }
                tab[x] = tab[i];
                tab[i] = temp;
            }
        }


        public void heapSort(int[] tab)
        {
            int left = tab.Length / 2;
            int right = tab.Length - 1;
            while (left > 0)
            {
                left--;
                heapify(ref tab, left, right);
            }

            while (right > 0)
            {
                int temp = tab[left];
                tab[left] = tab[right];
                tab[right] = temp;
                right--;
                heapify(ref tab, left, right);
            }
        }


        private void heapify(ref int[] tab, int left, int right)
        {
            int i = left,
                j = 2 * i + 1;
            int temp = tab[i];
            while (j <= right)
            {
                if (j < right)
                    if (tab[j] < tab[j + 1])
                        j++;
                if (temp >= tab[j]) break;
                tab[i] = tab[j];
                i = j;
                j = 2 * i + 1;
            }

            tab[i] = temp;
        }
    

    static void Main(string[] args)
        {
            Program hip = new Program();
            
            liczczas.Restart();
            liczczas.Start();
            
            for (int i = 50_000; i <= 200_000; i += 5_000)
              {
                    hip.heapSort(Vksztaltne(i));
                    Console.WriteLine($"{i};{liczczas.ElapsedMilliseconds}");
              }

            liczczas.Stop();
            Console.ReadKey();
        }
    }
}
