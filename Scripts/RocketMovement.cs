using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] ParticleSystem mainThruster;
    private float direction;
    private Rigidbody myRigidbody;
    private bool moved;
    public static bool gameOver, start_game = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody>();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!start_game) { return; }
        
        ApplyThrust();
        ApplyRotation();
    }

    void ApplyThrust() {
        if(Input.GetKey(KeyCode.Space)) {
            if(!moved) {
                RotationDirection(1f);
                moved = true;
            }
            myRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!mainThruster.isPlaying) {
                mainThruster.Play();
            }
        } else {
            mainThruster.Stop();
        }
    }

    void ApplyRotation() {
        if(Input.GetKey(KeyCode.RightArrow)) {
            moved = true;
            RotationDirection(-rotationThrust);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)) {
            moved = true;
            RotationDirection(rotationThrust);
        }
    }

    void RotationDirection(float rotationThrust) {
        myRigidbody.freezeRotation = true;
        this.transform.Rotate(Vector3.forward * Time.deltaTime * rotationThrust);
        myRigidbody.freezeRotation = false;
        myRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;

    }

    private void OnCollisionEnter(Collision other) {
        //Debug.Log("GAME OVER!");
        gameOver = true;
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "PlayerBounds") {
            gameOver = true;
        }
    }
}
