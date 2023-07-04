using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float speed;
    private Rigidbody myRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5.0f,7.5f);
        myRigidbody = this.GetComponent<Rigidbody>();
        myRigidbody.AddForce(-transform.up * speed,ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
