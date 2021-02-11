using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity;
using UnityEngine.UI;


public class BoardManager2 : MonoBehaviour
{

    public GameObject dot;

    public List<Body> bodys = new List<Body>();
    private bool compute;
    public bool displayOct;
    private bool circle;
    public bool bruteForce;
    public int size;
    private double framecount = 0;
    private Boundary boundary;
    private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
    public Octree octTree;
    private float dist;
    public List<Oct> octs = new List<Oct>();
    public float Theta = 0.5f;

    public Text NodeCount;
    public Text ThetaCount;

    void Start()
    {
        boundary = new Boundary(1000);
        dist = 0;
        compute = false;
        circle = false;
        bruteForce = false;
        displayOct = true;
        Debug.Log("##### &start =#####");

        for (int i = -2; i < 2; i++) //5 5
        {

            for (int j = -2; j < 2; j++) //5 5
            {

                for (int k = -2 ; k < 2; k++) //4 5
                {
                    GameObject dotGO = Instantiate(dot, new Vector3(i * 15, j * 15, k * 15), Quaternion.identity) as GameObject;
                    bodys.Add(new Body(dotGO));
                }
            }

        }

        size = bodys.Count;
        NodeCount.text = "Node Count: " + size;

    }

    // Update is called once per frame
    void Update()
    {
        createBodyIfNeeded();

        boundary.update(bodys);
        float sized = Mathf.Max((boundary.max.x - boundary.min.x), (boundary.max.y - boundary.min.y), (boundary.max.z - boundary.min.z));
        Vector3 center = new Vector3((boundary.max.x + boundary.min.x) / 2, (boundary.max.y + boundary.min.y) / 2, (boundary.max.z + boundary.min.z) / 2);
        octTree = new Octree(1, center, sized);

        stopwatch.Start();
        foreach (Body bod in bodys)
        {
            octTree.addBody(bod);
        }
        if (compute)
        { }

        if (bruteForce)
        {
            bruteFroceUpdate();
            ThetaCount.text = "θ Value: 0";
        }
        else
        {
            BarnesHut();
            ThetaCount.text = "θ Value: " + Theta;
        }
        stopwatch.Stop();
        //Debug.Log("plop "+bodys.Count+";"+stopwatch.ElapsedTicks);
        stopwatch.Reset();
    }

    void BarnesHut()
    {
        foreach (Body body in bodys)
        {
            octTree.interact(body, Theta);

            body.update();
        }
    }

    void bruteFroceUpdate()
    {
        foreach (Body bodyFirst in bodys)
        {
            foreach (Body bodySecond in bodys)
            {
                bodyFirst.interac(bodySecond);
            }
            bodyFirst.update();
        }
    }

    private void createBodyIfNeeded()
    {
        if (Input.GetKeyDown("space"))
            compute = !compute;

        if (Input.GetKeyDown("b"))
            displayOct = !displayOct;

        if (Input.GetKeyDown("n"))
            bruteForce = !bruteForce;


        if (Input.GetButtonDown("Fire1"))
        {
            //circle = !circle;
            Vector3 mouse = Input.mousePosition;
            mouse = Camera.main.ScreenToWorldPoint(mouse);
            mouse.z = 50;
            GameObject dotGO = Instantiate(dot, mouse, Quaternion.identity) as GameObject;
            bodys.Add(new Body(dotGO));
            size = bodys.Count;

            NodeCount.text = "Node Count: " + size;
        }
        framecount++;
        if (circle)
        {
            GameObject dotGO = Instantiate(dot, new Vector3(Mathf.Cos(Time.time) * dist, Mathf.Sin(Time.time) * dist, 0), Quaternion.identity) as GameObject;
            bodys.Add(new Body(dotGO));
            dist += 0.05f;
            size = bodys.Count;

            NodeCount.text = "Node Count: " + size;
        }
    }

    public void OnDrawGizmos()
    {
        if (displayOct)
        {
            octTree.getAllOct(octs);
            foreach (Oct oct in octs)
            {
                Gizmos.color = oct.color;
                Gizmos.DrawWireCube(oct.position, oct.size);
               // if (oct.gravityCenter != Vector3.zero) { }
                //Gizmos.DrawSphere(quad.gravityCenter,quad.mass);
            }
            octs.Clear();
        }
    }
}
