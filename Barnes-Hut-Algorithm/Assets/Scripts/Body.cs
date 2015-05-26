using UnityEngine;
using System.Collections;

public class Body  {

	private GameObject dot;
	public float mass;
	public Vector3 position;
	private Vector3 velocity;
	private Vector3 acceleration;
	private float G = 0.4f;

	public Body(GameObject _dot){
		mass = 2.0f;
		dot = _dot;
		velocity = Vector3.zero;
		acceleration = Vector3.zero;
		if(_dot != null)
			position = CopyVector(_dot.transform.position);
		 else 
			position = Vector3.zero;
	}

	public void update(){
		velocity += acceleration;
		position += velocity;
		acceleration = Vector3.zero;

		dot.transform.position = CopyVector(position);
	}

	public void interac(Body b){
		this.applyForce(b.attract(this));
	}

	public void applyForce(Vector3 force){
		acceleration += new Vector3(force.x/mass,force.y/mass,force.z/mass);
	}

	public Vector3 attract(Body b){
		Vector3 forc = position - b.position;
		float distance = forc.magnitude;
		distance = Mathf.Clamp(distance,50f,250f);

		forc.Normalize();
		float strenght = (G*mass*mass)/(distance*distance);
		return new Vector3(forc.x*strenght,forc.y*strenght,forc.z*strenght);

	}

	public void addBody(Body body){
		float m = mass + body.mass;
		float x = (position.x * mass + body.position.x * body.mass) / m ;
		float y = (position.y * mass + body.position.y * body.mass) / m ;
		mass = m;
		position = new Vector3(x,y,0);
	}
	
	private Vector3 CopyVector(Vector3 vec) {
		return new Vector3(vec.x,vec.y,vec.z);
	}
}
