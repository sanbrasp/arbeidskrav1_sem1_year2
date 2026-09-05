// using Task1_LinearSearchAndBinarySearch.Models;
//
// namespace Task1_LinearSearchAndBinarySearch;
//
// // Delete this file once it's no longer needed.
//
// internal static class ScratchFile
// {
//     private static int _binaryComparisons = 0;
//     internal static int BinaryComparisons => _binaryComparisons;
//     
//     internal static int BinarySearch(int[] array, int target)
//     {
//         ResetBinaryComparisons();
//
//         int left = 0;
//         int right = array.Length - 1;
//         int lowestMatchResult = -1; // Initialized with sentinel -1, must store the INDEX of first match
//
//         while (left <= right) // condition
//         {
//             int mid = left + (right - left) / 2; // mid calculation
//             
//             _binaryComparisons++; // counter!
//             if (array[mid] == target)
//             {
//                 lowestMatchResult = mid; // store the index, not the value
//                 right = mid - 1; // adjusted?
//             }
//             
//             else if (array[mid] < target)
//             {
//                 _binaryComparisons++;
//                 left = mid + 1;
//             }
//                 
//             else
//             {
//                 right = mid - 1;
//                 _binaryComparisons++;
//             }
//         }
//         return lowestMatchResult;
//     }
//
//     private static void ResetBinaryComparisons()
//     {
//         _binaryComparisons = 0;
//     }
// }