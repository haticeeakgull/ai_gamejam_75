using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public GameObject puzzleObject;

    private void Start()
    {
        puzzleObject.SetActive(false); 
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("etkileþim1");

        if (other.CompareTag("Player"))
        {
            StartPuzzle();
            Debug.Log("etkileþim");
        }
    }

    void StartPuzzle()
    {
        
        puzzleObject.SetActive(true); // Puzzle'ý görünür hale getir
    }
}
