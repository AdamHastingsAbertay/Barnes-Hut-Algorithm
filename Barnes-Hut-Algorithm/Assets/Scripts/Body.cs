using UnityEngine;
using System.Collections;

public class Body  {

	private GameObject dot;
	private float mass;
	private Vector3 velocity;
	private Vector3 force;

	public Body(GameObject _dot){
		mass = 2.0f;
		dot = _dot;
		velocity = Vector3.zero;
		force = Vector3.zero;
	}

	public void update(float deltatime){
		velocity += new Vector3(deltatime * force.x /mass,deltatime * force.y /mass,deltatime * force.z /mass);
		dot.transform.position += new Vector3(velocity.x * deltatime,velocity.y * deltatime,velocity.z * deltatime);
	}

	public float distance(Body b){
		return Vector3.Distance(dot.transform.position,b.getDot().transform.position);
	}

	public void resetForce(){
		force = Vector3.zero;
	}

	public void addForce(Body b){
		float G = 6.67e-11f;
		float EPS = 3E4f;
		Vector3 delta = b.getDot().transform.position - dot.transform.position;
		float dist = distance(b);
		float F = (G*mass * b.getMass()) / (dist*dist + EPS*EPS);
		dot.transform.position += new Vector3 (F* delta.x/dist,F* delta.y/dist,F* delta.z/dist);
	}

	public GameObject getDot(){
		return dot;
	}

	public float getMass(){
		return mass;
	}
}
