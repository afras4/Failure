using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    void Start()
    {
        GameObject camera = GameObject.Find ("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"textosjam (1).mp4");
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraFarPlane;
        
    }
}
