using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacle : MonoBehaviour
{
    public void UpdatePosition(float y_pos) {

        transform.position = transform.position + new Vector3(0, y_pos,0);
    }
}
