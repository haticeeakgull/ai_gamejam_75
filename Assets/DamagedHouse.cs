using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedHouse : MonoBehaviour
{
    public GameObject hasarPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            hasarPanel.SetActive(true);
            GetComponent<Collider2D>().enabled = false;   
            
        }
    }

    public void yikildi()
    {
        Time.timeScale =1f;
    }
}
