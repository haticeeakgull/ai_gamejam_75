using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject RoadHolder;
    public GameObject[] Roads;

    [SerializeField]
    int totalRoads = 0;
    [SerializeField]
    int correctedRoads = 0;

    private void Start()
    {
        totalRoads = RoadHolder.transform.childCount;

        Roads = new GameObject[totalRoads];

        for (int i = 0; i < Roads.Length; i++)
        {
            Roads[i] = RoadHolder.transform.GetChild(i).gameObject;
        }
    }
    public void CorrectMove()
    {
        correctedRoads++;
        Debug.Log("correct move");

        if(correctedRoads == totalRoads)
        {
            Debug.Log("you win");
        }

    }
    public void WrongMove()
    {
        correctedRoads--;
    }
}
