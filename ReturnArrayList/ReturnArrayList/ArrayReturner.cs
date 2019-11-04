using System;
namespace ReturnArrayList
{
    public class ArrayReturner
    {
        public int tal;

        public ArrayReturner(int tal)
        {
            this.tal = tal;
        }

        static void ArrayReturn(int tal)
        {
            int[] array = new int[tal];
            int i = 0;
            while(i < tal)
            {
                array[tal] = i;
            }
            Console.WriteLine(array);
        }
    }
}
