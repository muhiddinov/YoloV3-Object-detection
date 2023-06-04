using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoloV3_Object_detection
{
    internal class HelperClass
    {
        public static List<float[]> Arrayto2DList(Array array)
        {
            IEnumerator enumerator = array.GetEnumerator();
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            List<float[]> list = new List<float[]>();
            List<float> temp = new List<float>();

            for (int i = 0; i < rows; i++)
            {
                temp.Clear();
                for (int j = 0; j < cols; j++)
                {
                    temp.Add(float.Parse(array.GetValue(i, j).ToString()));
                }
                list.Add(temp.ToArray());
            }
            return list;
        }
    }
}
