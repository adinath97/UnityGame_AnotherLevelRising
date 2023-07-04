using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInstantiator : MonoBehaviour
{
    [SerializeField] GameObject missilePrefab;
    [SerializeField] float timer = -5f;

    private float firingTimerCap, firingTimer;

    private bool startFiring = false;

    private void Start() {
        firingTimerCap = Random.Range(0.0f,4.0f);
    }

    // Update is called once per frame
    void Update()
    {   
        if(startFiring) {
            timer += Time.deltaTime;
        } else {
            firingTimer += Time.deltaTime;
            if(firingTimer > firingTimerCap) {
                startFiring = true;
            }
        }
        
        if(timer > 0) {
            timer = -5f;
            InstantiateMissile();
        }
    }

    void InstantiateMissile() {
        GameObject missileInstance = Instantiate(
            missilePrefab,
            this.transform.position,
            Quaternion.Euler(new Vector3(0,0,90)) ); 
    }
}
