# Barnes-Hut-Algorithm [Unity - C#]
This simulator uses the [Barnes-Hut algorithm](https://en.wikipedia.org/wiki/Barnes%E2%80%93Hut_simulation) to simulate gravity
on n bodies. It is notable for having order O(n log n) compared to a direct-sum algorithm which would be O(n2).

Performance
-------
This solution, using Barnes-Hut, perform better than the brute force solution.<br />
Despite approximation the behavior remain very similar to the brute force.

<img src="https://raw.github.com/TristanBrismontier/Barnes-Hut-Algorithm/master/image/Barnes-Hut-Compare.png" alt="Drawing" width=600px/></br>
Execution time for N Body N->[1-1000], 10 mesures per N. 

Quad-Tree and Center-Gravity visualisation.
---------
<img src="https://raw.github.com/TristanBrismontier/Barnes-Hut-Algorithm/master/image/barnes-hut-visu.png" alt="Drawing" width=400px/>

More
---------
[The Barnes-Hut Algorithm](http://arborjs.org/docs/barnes-hut) article by Tom Ventimiglia & Kevin Wayne, was really useful for me to have a good understanding of the Barnes-Hut-Algorithm.
</br> 
My friend [Martin Magakian](https://github.com/martin-magakian) was building a [Barnes-Hut in Rust](https://github.com/martin-magakian/Barnes-Hut).<br />

License
---------
![License](https://i.creativecommons.org/l/by/4.0/88x31.png)<br />
Licensed under Creative Commons Attribution 4.0<br />
http://creativecommons.org/licenses/by/4.0/<br />
