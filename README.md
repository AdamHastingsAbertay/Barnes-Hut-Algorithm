# Barnes-Hut-Algorithm
This simulator uses the [Barnes-Hut algorithm](https://en.wikipedia.org/wiki/Barnes%E2%80%93Hut_simulation) to simulate gravity
on n bodies. It is notable for having order O(n log n) compared to a direct-sum algorithm which would be O(n2).

Performance
-------
Compare to the Brute force solution, this simulation is more performante, despite the aproximation the behavior is pretty the same as Brute force.
![perf1](https://raw.github.com/TristanBrismontier/Barnes-Hut-Algorithm/master/image/Barnes-Hut-Compare.png)
Execution time for N Body N->[1-1000], 10 mesures per N. 

Quad-Tree and Center-Gravity visualisation.
---------
<img src="https://raw.github.com/TristanBrismontier/Barnes-Hut-Algorithm/master/image/barnes-hut-visu.png" alt="Drawing" style="width: 200px;"/>

More
---------
This article : [The Barnes-Hut Algorithm](http://arborjs.org/docs/barnes-hut) by Tom Ventimiglia & Kevin Wayne, was realy usefull for me to have a good understanding of the Barnes-Hut-Algorithm.
</br> 
My friend [Martin Magakian](https://github.com/martin-magakian) was building a [Barnes-Hut in Rust](https://github.com/martin-magakian/Barnes-Hut).<br />

License
---------
![License](https://i.creativecommons.org/l/by/4.0/88x31.png)<br />
Licensed under Creative Commons Attribution 4.0<br />
http://creativecommons.org/licenses/by/4.0/<br />
