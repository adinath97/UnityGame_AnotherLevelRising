using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    [SerializeField] Vector3 local_offset;
    Vector3 update_offset;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }

        float cycles = Time.time / period;
        const float theta = Mathf.PI * 2;
        float rawSineWave = Mathf.Sin(cycles * theta);
        movementFactor = (rawSineWave + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = transform.parent.position + offset + local_offset + update_offset;
    }

    public void UpdatePosition(float y_update) {
        update_offset.y = y_update;
    }

    public void UpdatePeriod(float y_update) {
        period = y_update;
        movementVector.y *= period;

        int select = Random.Range(0,2);
        if(select == 0) {
            movementVector.y *= -1;
        }
    }
}
