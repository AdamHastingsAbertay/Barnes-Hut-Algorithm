﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuadNode { 

	private List<Body> bodys = new List<Body>();
	private Body averageBody = null;

	private Vector3 center;
	private float size;
	private int level;

	private int MAX_OBJECTS = 1;
	private int MAX_LEVELS = 15;

	public QuadNode(int level,Vector3 center, float size){
		this.center = center;
		this.size = size ;
		this.level = level;
		childs = new QuadNode[4];
	}

	private QuadNode[] childs;

	public void interact(Body body,float complexity){
		if(averageBody == null)
			return;
		float distance = Vector3.Distance(body.position,averageBody.position);
		if(distance == 0)
			return;

		if(size/distance >complexity && childs[0] != null){
			for(int i=0;i<4;i++){
				childs[i].interact(body,complexity);
			}
		}else{
			body.interac(averageBody);
		}
	}

	public void addBody(Body body){

		if(averageBody == null){
			averageBody = new Body(null);
			averageBody.position = body.position;
			averageBody.mass = body.mass;
		}else{
			averageBody.addBody(body);
		}

	 	if(childs[0] != null){
			int index = getSplitIndex(body);
			if(index != -1){
				childs[index].addBody(body);

				return;
			}
		}
		if(!bodys.Contains(body)){
			bodys.Add(body);
		}

		if(bodys.Count > MAX_OBJECTS && level < MAX_LEVELS){
			if(childs[0] == null){
				split();
			}
			foreach(Body bo in bodys){
				int index=getSplitIndex(bo);
				if(index != -1){
					childs[index].addBody(body);
				}
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
		for(int i=0;i<4;i++){   //4
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
		//
		//
		//
		//
	}

	public void getAllQuad(List<Quad> quads){
		if(averageBody == null){
			quads.Add(new Quad(center,size,level,Vector3.zero,0));
		}else{
			quads.Add(new Quad(center,size,level,averageBody.position,averageBody.mass));
		}
		if(childs[0] == null)
			return;
		for(int i=0;i<4;i++){ //4
			childs[i].getAllQuad(quads);
		}
	}
}
