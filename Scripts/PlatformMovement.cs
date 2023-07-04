using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    ScoreManager score_manager;
    private float timer, movementThisFrame;
    Vector3 targetPosition;
    string current_name, new_name;
    static bool incremented_score;
    public static bool start_game = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //targetPosition = new Vector3(this.transform.position.x, transform.position.y - 20.0f, this.transform.position.z);
        targetPosition = transform.position;
        score_manager = FindObjectOfType<ScoreManager>();
        incremented_score = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!start_game) { return; }
        
        if(targetPosition.y != transform.position.y) {
            incremented_score = false;
            movementThisFrame = moveSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position,targetPosition,movementThisFrame);
        } else {
            InfiniteCameraMovement.move = true;
            if(!incremented_score) {
                incremented_score = true;
                score_manager.GetComponent<ScoreManager>().IncrementScore();
            }
        }
        
        timer += Time.deltaTime;

        if(timer >= 5.0f) {
            timer = 0.0f;
            moveSpeed += .25f;
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
}
