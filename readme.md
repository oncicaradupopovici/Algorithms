# Algorithms

This is a study project meant to implement a few famous algorithms

## 1. Merge sort

Because we're using divide-and-conquer to sort, we need to decide what our subproblems are going to look like. The full problem is to sort an entire array. Let's say that a subproblem is to sort a subarray. In particular, we'll think of a subproblem as sorting the subarray starting at index p and going through index r. 
It will be convenient to have a notation for a subarray, so let's say that array[p..r] denotes this subarray of array. In terms of our notation, for an array of n elements, we can say that the original problem is to sort array[0..n-1].

Here's how merge sort uses divide-and-conquer:

1. Divide by finding the number q of the position midway between p and r. Do this step the same way we found the midpoint in binary search: add p and r, divide by 2, and round down.
2. Conquer by recursively sorting the subarrays in each of the two subproblems created by the divide step. That is, recursively sort the subarray array[p..q] and recursively sort the subarray array[q+1..r].
3. Combine by merging the two sorted subarrays back into the single sorted subarray array[p..r].

We need a base case. The base case is a subarray containing fewer than two elements, that is, when p >= r, since a subarray with no elements or just one element is already sorted. So we'll divide-conquer-combine only when p < r.