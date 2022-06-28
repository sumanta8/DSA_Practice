namespace ConsoleAppCollection
{
    internal static class Utility
    {
        public static int BinarySearch(int[] nums, int target, int start, int end)
        {
            while (start <= end)
            {
                int index = start + (end - start) / 2;
                if (nums[index] == target)
                {
                    return index;
                }
                else if (target > nums[index])
                {
                    start = index + 1;
                }
                else if (target < nums[index])
                {
                    end = index - 1;
                }
            }
            return -1;
        }

        public static int BinarySearch(int[] nums, int target)
        {
            return BinarySearch(nums, target, 0, nums.Length - 1);
        }
    }
}
