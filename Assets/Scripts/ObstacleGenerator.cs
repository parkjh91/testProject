using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;

    float span = 0.2f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            delta = 0;
            GameObject obstacle;
            int dice = Random.Range(1, 4);
            if(dice == 1)
            {
                obstacle = Instantiate(plane1) as GameObject;
            }
            else if(dice == 2)
            {
                obstacle = Instantiate(plane2) as GameObject;
            }
            else if(dice == 3)
            {
                obstacle = Instantiate(plane3) as GameObject;
            }
        }
    }
}