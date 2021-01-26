using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float speed = 30f;
    private Vector3 move = new Vector3();
    public Camera MainCamera;

    // Use this for initialization
    void Start () {
        MainCamera = GetComponent<Camera>();
        MainCamera.orthographicSize = 100;
    }
	
	// Update is called once per frame
	void Update () {
        move.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        move.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;


        //move.z = Input.GetAxis("Lateral") * speed * Time.deltaTime;

        //this.GetComponent<Camera>().orthographicSize = Input.GetAxis("Lateral") * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q)) // Change From Q to anyother key you want
        {
            MainCamera.orthographicSize = MainCamera.orthographicSize + speed * Time.deltaTime;
          
        }

        if (Input.GetKey(KeyCode.E)) // Change From Q to anyother key you want
        {
            MainCamera.orthographicSize = MainCamera.orthographicSize - speed * Time.deltaTime;

        }


        //MainCamera.orthographicSize = Input.GetAxis("Lateral") * MainCamera.orthographicSize * Time.deltaTime;
        //Input.GetAxis("Lateral") * MainCamera.orthographicSize + 1 * Time.deltaTime;

        if (MainCamera.orthographicSize > 500)
        {
            MainCamera.orthographicSize = 500; // Max size
        }

        if (MainCamera.orthographicSize < 25)
        {
            MainCamera.orthographicSize = 25; // Max size
        }

        move = transform.TransformDirection(move);
        transform.position += move;
    }
}
