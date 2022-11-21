using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    public GameObject videoPlayer;
    public int timeToStop;
    public GameObject backGround;
    public GameObject player;
    public GameObject plane;
    public GameObject drag;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
        backGround.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider apple)
    {
        if (apple.gameObject.tag == "Apple")
        {
            videoPlayer.SetActive(true);
            backGround.SetActive(true);
            player.SetActive(false);
            plane.SetActive(false);
            drag.SetActive(false);
            Destroy(videoPlayer, timeToStop);
            StartCoroutine(Restore());
            
        }
        IEnumerator Restore()
        {
            yield return new WaitForSeconds(15);
            player.SetActive(true);
            plane.SetActive(true);
            drag.SetActive(true);
            backGround.SetActive(false);

        }


    }
    
}
