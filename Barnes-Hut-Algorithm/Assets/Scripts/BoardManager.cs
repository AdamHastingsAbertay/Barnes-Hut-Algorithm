using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public GameObject dot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Vector3 mouse = Input.mousePosition;
			mouse = Camera.main.ScreenToWorldPoint(mouse);
			mouse.z = 0;
			Instantiate(dot,  mouse, Quaternion.identity);
		}
	}
}
