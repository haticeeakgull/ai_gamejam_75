using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public List<GameObject> roadList = new List<GameObject>();
    public bool allTrue = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        allTrue = true; // Assume all are true unless proven otherwise

        foreach (GameObject road in roadList)
        {
            roadScript roadScript = road.GetComponent<roadScript>();
            float zRotation = road.transform.eulerAngles.z +90;
            Debug.Log(zRotation); // Debugging the actual rotation in degrees

            if (roadScript.correctRotation.Length > 1)
            {
                if (Mathf.Abs(zRotation - roadScript.correctRotation[0]) < 0.1f || Mathf.Abs(zRotation - roadScript.correctRotation[1]) < 0.1f)
                {
                   roadScript.isPlaced = true;
                }
               
            }
            else
            {
                if (Mathf.Abs(zRotation - roadScript.correctRotation[0]) < 0.1f)
                {
                    roadScript.isPlaced = true;

                }

            }
        }

        if (allTrue)
        {
            Debug.Log("OLDU");
        }
    }
}
