using UnityEngine;
using System.Collections;

public class QuadNode  : MonoBehaviour  {

	private Body body;
	private Body quadBody;

	private Vector3 center;
	private float size;

	private QuadNode nw;
	private QuadNode ne;
	private QuadNode sw;
	private QuadNode se;

	public QuadNode(Vector3 center, float size){
		this.center = center;
		this.size = size ;
	}

	public void addBody(Body body){
		if(!contains(body))
			return;
		if(body == null){
			this.body = body;
			return;
		}
		createChildNodeifNeeded();
		nw.addBody(body);
		ne.addBody(body);
		sw.addBody(body);
		se.addBody(body);

		if(quadBody==null){
			quadBody = new Body(null);
			quadBody.position = body.position;
		}else{
			quadBody.addBody(body);
		}
	}

	public bool contains(Body body){
		if(body.position.x > center.x +(size/2f))
			return false;
		if(body.position.x < center.x -(size/2f))
			return false;
		if(body.position.y > center.y +(size/2f))
			return false;
		if(body.position.y < center.y -(size/2f))
			return false;
		return true;
	}

	private void createChildNodeifNeeded(){
		if(nw !=null)
			return;
		float newSize = size/2f;
		nw = new QuadNode(new Vector3(center.x-newSize,center.y+newSize,0f),newSize);
		ne = new QuadNode(new Vector3(center.x+newSize,center.y+newSize,0f),newSize);
		sw = new QuadNode(new Vector3(center.x-newSize,center.y-newSize,0f),newSize);
		se = new QuadNode(new Vector3(center.x+newSize,center.y-newSize,0f),newSize);
	}

	public void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(center,new Vector3(size,size,size));
	}

}
