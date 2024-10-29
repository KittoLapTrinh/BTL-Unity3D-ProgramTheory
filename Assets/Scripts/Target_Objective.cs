using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject Cube;
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sphere.transform.position = Vector3.MoveTowards(Sphere.transform.position, Cube.transform.position, speed);
    }
}
