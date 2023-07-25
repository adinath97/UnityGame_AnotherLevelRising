using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingSet : MonoBehaviour
{
    float max_y_pos = 5.0f, min_y_pos = -5.0f, min_per = 1f, max_per = 5f;

    [SerializeField] List<GameObject> children;

    private void Start() {
        var parent_tag = transform.tag;

        //assign random y pos to them within specified range
        foreach(GameObject child in children) {
            float y_pos = Random.Range(min_y_pos, max_y_pos);
            float per = Random.Range(min_per, max_per);

            if(parent_tag == "DynamicTwo") {
                child.GetComponent<MovingObstacle>().UpdatePeriod(per);
            } else {
                child.GetComponent<MovingObstacle>().UpdatePosition(y_pos);
            }
        }

    }
}
