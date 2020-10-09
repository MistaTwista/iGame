using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVScript : MonoBehaviour, IActionable
{
    public GameObject player;
    VideoPlayer videoPlayer;
    private bool isPlaying = false;
    void Start()
    {
        player.SetActive(isPlaying);
        videoPlayer = player.GetComponent<VideoPlayer>();
    }

    public void Action()
    {
        Debug.Log("TV ACTION");
        isPlaying = !isPlaying;
        player.SetActive(isPlaying);
    }
}
