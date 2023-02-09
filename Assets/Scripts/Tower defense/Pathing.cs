using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    public float speed;
    public GameObject obj;
    //creates a list of points for the obj to travel to
    public GameObject[] pathPoints;
    public int numberOfPoints;
    public bool ThirdDimensionEnvironment;

    private Vector3 actualPosition;
    private int x;

    // Start is called before the first frame update
    void Start()
    {
        //sets the first point of travel
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ThirdDimensionEnvironment == true)
        {
            //allows us to use vector 3
            actualPosition = obj.transform.position;
            //using vector 3 to move the object towards the points in the list
            obj.transform.position = Vector3.MoveTowards(actualPosition, pathPoints[x].transform.position, speed * Time.deltaTime);
            //increments x to change which point the obj is moving towards
            if (actualPosition == pathPoints[x].transform.position && x != numberOfPoints - 1)
            {
                x++;
            }
        }
        else
        {
            // allows us to use Vector 2
            Vector2 actualPosition2D = (Vector2)obj.transform.position;
            // using Vector 2 to move towards the points in the list
            obj.transform.position = Vector2.MoveTowards(actualPosition2D, pathPoints[x].transform.position, speed * Time.deltaTime);
            //increments x to change which point the obj is moving towards
            if (actualPosition == pathPoints[x].transform.position && x != numberOfPoints - 1)
            {
                x++;
            }
        }
    }
    
}
