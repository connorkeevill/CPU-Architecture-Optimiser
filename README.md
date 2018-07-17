# CPU-Architecture-Optimiser
A solution to demonstrate the effects of speculative execution

This project demonstrates how speculative execution can improve CPU performance. It does this by iterating through two (large) arrays and calculating the sum of the even numbers - one of the arrays is sorted, the other is not. The time to calculate this sum will be recorded and then displayed to highlight any difference. The sorted array *should* be quicker, demonstrating that the pattern of odd-even-odd... has enabled speculative execution to guess whether the next item in the array will be even or not.
