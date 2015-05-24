using UnityEngine;
using System.Collections;

public class Body  {

	private GameObject dot;
	private float mass;
	private Vector3 velocity;
	private Vector3 acceleration;
	private float G = 0.4f;

	public Body(GameObject _dot){
		mass = 2.0f;
		dot = _dot;
		velocity = Vector3.zero;
		acceleration = Vector3.zero;
	}

	public void update(){
		velocity += acceleration;
		dot.transform.position += velocity;
		acceleration = Vector3.zero;
	}

	public void interac(Body b){
		this.applyForce(b.attract(this));
	}

	public void applyForce(Vector3 force){
		acceleration += new Vector3(force.x/mass,force.y/mass,force.z/mass);
	}

	public Vector3 attract(Body b){
		Vector3 forc = dot.transform.position - b.getDot().transform.position;
		float distance = forc.magnitude;
		distance = Mathf.Clamp(distance,50f,250f);

		forc.Normalize();
		float strenght = (G*mass*mass)/(distance*distance);
		return new Vector3(forc.x*strenght,forc.y*strenght,forc.z*strenght);

	}

	public GameObject getDot(){
		return dot;
	}

	public float getMass(){
		return mass;
	}
}
