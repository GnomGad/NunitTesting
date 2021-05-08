using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Lib
{
    public class ArrayProcessor
    {
        public double[] SortAndFilter(double[] a)
        {
            double[] new_a = a.Distinct().ToArray();

            for (int i = 0; i < new_a.Length; i++)
            {
                new_a[i] = GetChanged(new_a[i]);
            }

            Sort(ref new_a);
            return new_a;
        }

        public void Sort(ref double[] a)
        {
            double temp;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] < a[j])
                    {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }
        public double GetChanged(double a) => a < 0 ? -1 * a : a;
    }

    public class MyComparer : IComparer
    {
        public int Compare(object x, object y) => (double)x < (double)y ? 1 : -1;
    }
}

