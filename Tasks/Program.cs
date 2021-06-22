using System;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 1, 5, 10, 25, 15, 13} ;
            
            ShowArray(nums);

            MyTree myTree = new MyTree(nums[0]);
            for(int i = 1; i<nums.Length; i++)
            {
                myTree.Add(nums[i]);
            }
            myTree.Remove(nums[3]);
        }

        private static void ShowArray(int[] arr)
        {
            Console.WriteLine("Array:");
            foreach(int el in arr)
            {
                Console.Write(el + "; ");
            }
        }
    }
}
