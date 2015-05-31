using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BoardManager : MonoBehaviour
{

	public GameObject dot;

	private List<Body> bodys = new List<Body> ();
	private bool compute;
	private bool displayQuad;
	private bool circle;
	private int size;
	private double framecount = 0;
	private Boundary boundary;
	private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch ();
	private QuadNode quadTree;
	private List<Quad> quads = new List<Quad> ();

	void Start ()
	{
		boundary = new Boundary (1000);
		compute = true;
		circle = false;
		displayQuad = true;
		size = bodys.Count;
		Debug.Log ("##### start #####");
	}

	// Update is called once per frame
	void Update ()
	{
		createBodyIfNeeded ();

		boundary.update (bodys);
		float sized = Mathf.Max ((boundary.max.x - boundary.min.x), (boundary.max.y - boundary.min.y));
		Vector3 center = new Vector3 ((boundary.max.x + boundary.min.x) / 2, (boundary.max.y + boundary.min.y) / 2, (boundary.max.z + boundary.min.z) / 2);
		quadTree = new QuadNode (1, center, sized);

		foreach (Body bod in bodys) {
			quadTree.addBody (bod);
		}
		if (compute) {
			bruteFroceUpdate ();
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
		if (Input.GetKeyDown ("space"))
			compute = !compute;

		if (Input.GetKeyDown ("b"))
			displayQuad = !displayQuad;

		if (Input.GetButtonDown ("Fire1")) {
			//circle = !circle;
			Vector3 mouse = Input.mousePosition;
			mouse = Camera.main.ScreenToWorldPoint (mouse);
			mouse.z = 0;
			GameObject dotGO = Instantiate (dot, mouse, Quaternion.identity) as GameObject;
			bodys.Add (new Body (dotGO));
			size = bodys.Count;
		}
		framecount++;
		if (circle && framecount % 20 == 0) {
			GameObject dotGO = Instantiate (dot, new Vector3 (Mathf.Cos (Time.time) * 20, Mathf.Sin (Time.time) * 20, 0), Quaternion.identity) as GameObject;
			bodys.Add (new Body (dotGO));
			size = bodys.Count;
		}
	}

	public void OnDrawGizmos ()
	{
		if (displayQuad) {
			quadTree.getAllQuad (quads);
			foreach (Quad quad in quads) {
				Gizmos.color = quad.color;
				Gizmos.DrawWireCube (quad.position, quad.size);
			}
			quads.Clear ();
		}
	}
}
