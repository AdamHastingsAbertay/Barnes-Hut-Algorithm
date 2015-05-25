using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BoardManager : MonoBehaviour {

	public GameObject dot;

	private List<Body> bodys = new List<Body>();
	private bool compute;
	private bool circle;
	private int size;
	private double framecount = 0;
	private Boundary boundary;
	private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

	void Start(){
		boundary = new Boundary(1000);
		compute =true;
		circle = false;
		size = bodys.Count;
		Debug.Log ("##### start #####");
	}

	// Update is called once per frame
	void Update () {
		boundary.update(bodys);



		createBodyIfNeeded ();

		if(compute){
			stopwatch.Start();

			bruteFroceUpdate ();

			stopwatch.Stop();
			print("plop "+size+";"+stopwatch.ElapsedTicks);
			stopwatch.Reset();
		}
	}

	void bruteFroceUpdate ()
	{
		foreach (Body bodyFirst in bodys) {
			foreach (Body bodySecond in bodys) {
				bodyFirst.interac (bodySecond);
			}
			bodyFirst.update ();
		}
	}

	private void createBodyIfNeeded ()
	{
		if(Input.GetKeyDown("space"))
			compute = !compute;

		if (Input.GetButtonDown ("Fire1")) {
			Vector3 mouse = Input.mousePosition;
			mouse = Camera.main.ScreenToWorldPoint (mouse);
			mouse.z = 0;
			GameObject dotGO = Instantiate (dot, mouse, Quaternion.identity) as GameObject;
			bodys.Add (new Body (dotGO));
			size = bodys.Count;
		}
		framecount++;
		if (circle && framecount % 10 == 0) {
			GameObject dotGO = Instantiate (dot, new Vector3 (Mathf.Cos (Time.time) * 10, Mathf.Sin (Time.time) * 10, 0), Quaternion.identity) as GameObject;
			bodys.Add (new Body (dotGO));
			size = bodys.Count;
		}
	}

	public void OnDrawGizmos(){
		float size = Mathf.Max((boundary.max.x-boundary.min.x),(boundary.max.y-boundary.min.y));
		Vector3 center = new Vector3((boundary.max.x+boundary.min.x)/2,(boundary.max.y+boundary.min.y)/2,(boundary.max.z+boundary.min.z)/2);
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(center,new Vector3(size,size,size));
	}
}
