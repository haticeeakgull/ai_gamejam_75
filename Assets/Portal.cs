using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject Player;
    public Transform timeLine;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        Camera.GetComponent<CameraFollow>().enabled = false;
        Player.GetComponent<Collider2D>().enabled = false;
        Player.transform.SetParent(timeLine);
        Player.transform.localScale = Vector3.one;
        
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("normalGameScene");
    }
}
