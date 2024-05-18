using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadScript : MonoBehaviour
{
    float[] rotation = { 0,90, 180, 270 };
    
    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;

    int possibleRots = 1;

    GameManager manager;

    private void Awake()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Start()
    {
        possibleRots = correctRotation.Length;
        int rand = Random.Range(0,rotation.Length);
        transform.eulerAngles = new Vector3(0, 0, rotation[rand]);

        if(possibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                manager.CorrectMove();
            }
            else
            {
                if (transform.eulerAngles.z == correctRotation[0] )
                {
                    isPlaced = true;
                    manager.CorrectMove();
                }

            }

        }
        
       
    }
    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (possibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1] && isPlaced == false)
            {
                isPlaced = true;
                manager.CorrectMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                manager.WrongMove();
            }

        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0]  && isPlaced == false)
            {
                isPlaced = true;
                manager.CorrectMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                manager.WrongMove();
            }

        }

            
    }
}
