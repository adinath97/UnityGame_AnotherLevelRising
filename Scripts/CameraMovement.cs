using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 1f;
    private float timer, movementThisFrame;
    private int waypointIndex = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = waypoints[0].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waypointIndex < waypoints.Count) {
            movementThisFrame = moveSpeed * Time.deltaTime;
            var targetPosition = waypoints[waypointIndex].transform.position;
            transform.position = Vector3.MoveTowards(transform.position,targetPosition,movementThisFrame);
            if(targetPosition == transform.position) {
                waypointIndex++;
            }
        }

        timer += Time.deltaTime;

        if(timer >= 5.0f) {
            timer = 0.0f;
            moveSpeed += .25f;
        }
    }
}
