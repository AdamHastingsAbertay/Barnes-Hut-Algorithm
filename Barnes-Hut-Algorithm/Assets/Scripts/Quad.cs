using UnityEngine;
using System.Collections;

public class Quad {
	public Vector3 position;
	public Vector3 size;
	public Color color;

	public Quad(Vector3 position, float size, float index){
		this.position = position ;
	 	this.size = new Vector3(size,size,size);
		this.color = new Color(1-(index*0.066f),0f,index*0.066f,0.1f);	
	}


}
