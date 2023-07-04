using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCrusher : MonoBehaviour
{
    float max_y_pos = 5.0f, min_y_pos = -5.0f;

    [SerializeField] List<GameObject> children;

    private void Start() {
        //assign random y pos to them within specified range
        foreach(GameObject child in children) {
            float y_pos = Random.Range(min_y_pos, max_y_pos);

            child.GetComponent<MovingObstacle>().UpdatePosition(y_pos);

        }

    }
}
