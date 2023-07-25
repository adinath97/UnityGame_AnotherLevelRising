using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public static float moveSpeed = 5f;
    ScoreManager score_manager;
    private float timer, movementThisFrame;
    Vector3 targetPosition;
    string current_name, new_name;
    public static bool start_game = false;
    private static bool updated = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //targetPosition = new Vector3(this.transform.position.x, transform.position.y - 20.0f, this.transform.position.z);
        targetPosition = transform.position;
        score_manager = FindObjectOfType<ScoreManager>(); 
        updated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!start_game) { return; }
        else { GroundSpawner.start_game = true; }

        updated = false;
        
        if(targetPosition.y != transform.position.y) {
            movementThisFrame = moveSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position,targetPosition,movementThisFrame);
        } else {
            updated = true; 
        }
    }

    public void UpdateMovement() {
        if(targetPosition.y == transform.position.y) {
            this.targetPosition.y -= 25.0f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        new_name = transform.name;
        if(current_name != new_name) {
            current_name = new_name;
            if(other.gameObject.tag == "Player") {
                GroundSpawner.spawn_next_tile = true;
            }
        }
    }

    public bool UpdateStatus() { return updated; }

    public void DestroySelf() {
        Destroy(gameObject); 
    }
}
