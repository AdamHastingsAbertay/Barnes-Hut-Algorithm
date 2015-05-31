# Barnes-Hut-Algorithm
This simulator uses the [Barnes-Hut algorithm](https://en.wikipedia.org/wiki/Barnes%E2%80%93Hut_simulation) to simulate gravity
on n bodies. It is notable for having order O(n log n) compared to a direct-sum algorithm which would be O(n2).

Performance
-------
Compare to the Brute force solution, this simulation is more performante, despite the aproximation the behavior is pretty the same as Brute force.
![perf1](https://raw.github.com/TristanBrismontier/Barnes-Hut-Algorithm/master/image/Barnes-Hut-Compare.png)
Execution time for N Body N->[1-1000], 10 mesures per N. 
