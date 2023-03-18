using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PlayerLoop;

public class Pathing : MonoBehaviour
{
    public float speed;
    public EmuTakeDamage ETD;
    public GameObject obj;
    //creates a list of points for the obj to travel to
    public GameObject[] pathPoints;
    public int numberOfPoints;
    public bool ThirdDimensionEnvironment;
    private GameObject Player,farm;

    private Vector3 actualPosition;
    private int x;

    // Start is called before the first frame update
    void Start()
    {
        
        //sets the first point of travel
        x = 1;
        Player = GameObject.FindGameObjectWithTag("Player");
        if (pathPoints[0] == null)
        {
            GameObject pathPointsObject = GameObject.Find("PathPoints");
            numberOfPoints = pathPointsObject.transform.childCount;
            for (int i = 0; i < numberOfPoints; i++)
            {

                pathPoints[i] = pathPointsObject.transform.GetChild(i).gameObject;
            }
        }
        farm = GameObject.FindGameObjectWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        if (ETD.health == ETD.Maxhealth)
        {
            gotofarm();
        }
        else
        {

         Shot();
        }
    }

    void Shot()
    {

     Vector2 actualPosition2D = (Vector2)obj.transform.position;
     obj.transform.position = Vector2.MoveTowards(actualPosition2D, Player.transform.position, speed * Time.deltaTime);
        //Debug.Log("Emu move to player");
    }

    public void PtP_pathing()
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
            if (actualPosition2D == (Vector2)pathPoints[x].transform.position && x != numberOfPoints - 1)
            {

                x++;
                Debug.Log(x);

            }
        }


    }
    void gotofarm()
    {


        Vector2 actualPosition2D = (Vector2)obj.transform.position;
        obj.transform.position = Vector2.MoveTowards(actualPosition2D, farm.transform.position, speed * Time.deltaTime);
        //Debug.Log("Emu move to player");

    }
}
