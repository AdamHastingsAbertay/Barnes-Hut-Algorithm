using UnityEngine;
using System.Collections;

public class Boundary{

	public Vector3 min;
	public Vector3 max;

	public Boundary(float limit){
		min = new Vector3(limit,limit,0);
		max = new Vector3(-limit,-limit,0);
	}

	public void getLimit(Vector3 vec){
		max = Vector3.Max(max,vec);
		min = Vector3.Min(min,vec);
	}

}
