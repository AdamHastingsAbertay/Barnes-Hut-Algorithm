using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuadNode  {

	private List<Body> bodys = new List<Body>();
	private Body quadBody = null;

	private Vector3 center;
	private float size;
	private int level;

	private int MAX_OBJECTS = 1;
	private int MAX_LEVELS = 15;

	private QuadNode[] childs;

	public QuadNode(int level,Vector3 center, float size){
		this.center = center;
		this.size = size ;
		this.level = level;
		childs = new QuadNode[4];
	}

	public void addBody(Body body){
	 	if(childs[0] != null){
			int index = getSplitIndex(body);
			if(index != -1){
				childs[index].addBody(body);
				return;
			}
		}
		bodys.Add(body);

		if(bodys.Count > MAX_OBJECTS && level < MAX_LEVELS){
			if(childs[0] == null){
				split();
			}
			foreach(Body bo in bodys){
				int index=getSplitIndex(bo);
				childs[index].addBody(bo);
			}
			bodys.Clear();
		}
	}

	public bool contains(Body body){
		if(body.position.x >= center.x +(size/2f))
			return false;
		if(body.position.x <= center.x -(size/2f))
			return false;
		if(body.position.y >= center.y +(size/2f))
			return false;
		if(body.position.y <= center.y -(size/2f))
			return false;
		return true;
	}

	private int getSplitIndex(Body body){
		for(int i=0;i<4;i++){
			if(childs[i].contains(body)){
				return i;
			}
		}
		return -1;
	}

	private void split(){
		float newSize = size/2f;
		childs[0] = new QuadNode(level+1,new Vector3(center.x-newSize/2f,center.y+newSize/2f,0f),newSize);
		childs[1] = new QuadNode(level+1,new Vector3(center.x+newSize/2f,center.y+newSize/2f,0f),newSize);
		childs[2] = new QuadNode(level+1,new Vector3(center.x-newSize/2f,center.y-newSize/2f,0f),newSize);
		childs[3] = new QuadNode(level+1,new Vector3(center.x+newSize/2f,center.y-newSize/2f,0f),newSize);
	}

	public void getAllQuad(List<Quad> quads){
		quads.Add(new Quad(center,size));
		if(childs[0] == null)
			return;
		for(int i=0;i<4;i++){
			childs[i].getAllQuad(quads);

	}

}
}