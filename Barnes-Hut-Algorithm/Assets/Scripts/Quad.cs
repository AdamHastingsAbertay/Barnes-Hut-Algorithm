using UnityEngine;
using System.Collections;

public class Quad {
	public Vector3 position;
	public Vector3 size;

	public Quad(Vector3 position, float size){
		this.position = position ;
	 	this.size = new Vector3(size,size,size);
	}
}
