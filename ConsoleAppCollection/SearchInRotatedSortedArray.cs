
/*There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]] (0 - indexed).For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.*/

/// 
/// https://leetcode.com/problems/search-in-rotated-sorted-array/
///

namespace ConsoleAppCollection
{
    internal static class SearchInRotatedSortedArray
    {
        public static int Search(int[] nums, int target)
        {
            if (nums[0] == target)
            {
                return 0;
            }
            if(nums.Length == 1)
            {
                return -1;
            }
            if (nums[nums.Length - 1] == target)
            {
                return nums.Length - 1;
            }

            int pivot = FindPivot(nums);

            // If there is no pivot
            if (pivot == -1)
            {
                return Utility.BinarySearch(nums, target, 0, nums.Length - 1);
            }
            // If pivot element is equal to target
            if (nums[pivot] == target)
            {
                return pivot;
            }

            // If starting element of both halves are greater than target, the target is not found
            if (nums[0] > target && nums[pivot + 1] > target)
            {
                return -1;
            }
            // If end element of both halves are less than target, the target is not found
            if (nums[pivot] < target && nums[nums.Length-1] < target)
            {
                return -1;
            }
            // If starting element of first half is less than target and the end element of first half is greater than target
            // Target might be in first half
            if (nums[0] < target && nums[pivot] > target)
            {
                return Utility.BinarySearch(nums, target, 0, pivot);
            }
            // If starting element of second half is less than target and the end element of second half is greater than target
            // Target might be in second half
            if (nums[pivot + 1] <= target && nums[nums.Length - 1] >= target)
            {
                return Utility.BinarySearch(nums, target, pivot + 1, nums.Length - 1);
            }
            return -1;
        }

        public static int FindPivot(int[] nums)
        {
            int start = 0, end = nums.Length - 1;
            while (start <= end)
            {
                int index = start + (end - start) / 2;

                // Case 1: index is the not the last index and it is the pivot
                if (index < end && nums[index] > nums[index + 1])
                {
                    return index;
                }
                // Case 2: index is the not the first index and it is the pivot
                if (index > start && nums[index] < nums[index -1])
                {
                    return index - 1;
                }
                // Case 3: index is the not the pivot and value at index is smaller than value starting index
                // Ignore the right side.
                if (nums[index] < nums[start])
                {
                    end = index - 1;
                }
                // Case 4: index is the not the pivot and value at index is greater than value starting index
                // Ignore the left side.
                else
                {
                    start = index + 1;
                }
            }
            return -1;
        }
    }
}
