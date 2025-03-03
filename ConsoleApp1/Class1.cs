using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Class1
    {
        private int[] arr;
        private int index;
        public Class1(int[] ar, int ind)
        {
            arr = ar;
            index = ind;
        }
        public void Swap(ref int value1, ref int value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }
        public void CombSort()
        {
            var arrayLength = arr.Length;
            var currentStep = arrayLength - 1;

            for (var i = 1; i < arrayLength; i++)
            {

                for (var j = 0; j < arrayLength - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }

        public int selectid(int a)
        {
            foreach (int i in arr)
            {
                for (int j = 1; j < arr.Length; j++)
                    if (i == a)
                    {
                        return i;
                    }
            }
            return -1;
        }

        public void ShillSort()
        {
            int size = arr.Length;
            for (int i = size / 2; i > 0; i /= 2)
            {
                for (int j = i; j < size; j++)
                {
                    var arrayJ = arr[j];
                    var J = j;
                    while (J >= i && arr[J - i] > arrayJ)
                    {
                        arr[J] = arr[J - i];
                        J -= i;
                    }
                    arr[J] = arrayJ;
                }
            }
        }

        public void bSort()
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int k = 0; k < arr.Length - 1; k++)
                {

                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (arr[j + 1] > arr[j])
                        {
                            temp = arr[j + 1];
                            arr[j + 1] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }
        }
        public string Print()
        {
            string result = "";
            foreach (int i in arr)
            {
                result += Convert.ToString(i) + " ";
            }
            return result;
        }
    }
}
