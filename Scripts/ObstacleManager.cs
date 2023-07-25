using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<Transform> obstacle_instantiation_positions;
    [SerializeField] List<GameObject> obstacle_set;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.name == "InitialPlatforms(Clone)") {
            //obstacle_instantiation_positions.Add(this.transform.GetChild(6).transform);
            obstacle_instantiation_positions.Add(this.transform.GetChild(7).transform);    
            obstacle_instantiation_positions.Add(this.transform.GetChild(8).transform);    
            obstacle_instantiation_positions.Add(this.transform.GetChild(9).transform);  
            obstacle_instantiation_positions.Add(this.transform.GetChild(10).transform);
        } else {
            obstacle_instantiation_positions.Add(this.transform.GetChild(2).transform);
            obstacle_instantiation_positions.Add(this.transform.GetChild(3).transform);    
            obstacle_instantiation_positions.Add(this.transform.GetChild(4).transform);    
            obstacle_instantiation_positions.Add(this.transform.GetChild(5).transform);  
            obstacle_instantiation_positions.Add(this.transform.GetChild(6).transform);
        }
        
        
        //at each instantation point, select random obstacle and instantiate
        for(int i = 0; i < obstacle_instantiation_positions.Count; i++) {
            //select random obstacle
            int random_obstacle = Random.Range(0,5);

            if(random_obstacle == 4) {
                random_obstacle = Random.Range(4,10);
            }

            GameObject obstacle_instance = Instantiate(
            obstacle_set[random_obstacle],
            obstacle_instantiation_positions[i].position,
            Quaternion.identity );

            obstacle_instance.transform.parent = this.transform;

        }
    }
}
