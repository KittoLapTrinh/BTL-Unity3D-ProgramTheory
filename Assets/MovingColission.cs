using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingColission : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject destination;
    public float speed;
    public float rollSpeed = 50f; 
    private Vector3 originalPosition;
 

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, destination.transform.position, speed);
        gameObject.transform.Rotate(-rollSpeed * Time.deltaTime, 0, 0, Space.Self);
        if (Vector3.Distance(gameObject.transform.position, destination.transform.position) < 0.1f)
        {
            // Respawn the gameObject at its original position
            gameObject.transform.position = originalPosition;
        }
    }
}
