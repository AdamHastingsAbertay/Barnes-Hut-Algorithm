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
	private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

	void Start(){
		 Vector3 a = new Vector3(1, 2, 3);
		 Vector3 b = new Vector3(4, 3, 2);
	
			print(Vector3.Min(a, b));
		compute =true;
		circle = false;
		size = bodys.Count;
		Debug.Log ("##### start #####");
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("space"))
			compute = !compute;

		if (Input.GetButtonDown("Fire1")) {
			Vector3 mouse = Input.mousePosition;
			mouse = Camera.main.ScreenToWorldPoint(mouse);
			mouse.z = 0;
			GameObject dotGO = Instantiate(dot,  mouse, Quaternion.identity) as GameObject;
			bodys.Add(new Body(dotGO));
			size = bodys.Count;
		}
		framecount++;
		if(circle && framecount%10 ==0 ){
			GameObject dotGO = Instantiate(dot,  new Vector3(Mathf.Cos(Time.time)*10,Mathf.Sin(Time.time)*10,0), Quaternion.identity) as GameObject;
			bodys.Add(new Body(dotGO));
			size = bodys.Count;
		}

		if(compute){
			stopwatch.Start()	;
			foreach(Body bodyFirst in bodys){
				foreach(Body bodySecond in bodys){
					bodyFirst.interac(bodySecond);
				}
				bodyFirst.update();
			}
			stopwatch.Stop();
			print("plop "+size+";"+stopwatch.ElapsedTicks);
			stopwatch.Reset();
		}
	}
}
