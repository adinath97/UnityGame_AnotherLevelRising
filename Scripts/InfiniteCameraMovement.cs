using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteCameraMovement : MonoBehaviour
{
    public static float moveSpeed = 5f;

    private float timer, movementThisFrame;
    Vector3 targetPosition;

    public static bool move = true, start_game = false;

    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(-19.3f, transform.position.y,-12f);
        targetPosition = new Vector3(36.9f, transform.position.y, -13f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!move || !start_game) { return; }
        
        if(targetPosition.x != transform.position.x) {
            movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,targetPosition,movementThisFrame);
        } else if(targetPosition.x == transform.position.x) {
            InfiniteCameraMovement.move = false;
            if(targetPosition.x == -19.3f) {
                targetPosition.x = 36.9f;
            } else {
                targetPosition.x = -19.3f;
            }
            
            GroundSpawner.MoveGround();
        }
    }
}
