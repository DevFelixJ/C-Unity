using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    public GameObject videoPlayer;
    public int timeToStop;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider apple)
    {
        if (apple.gameObject.tag == "Apple")
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
        }
        
    }
}
