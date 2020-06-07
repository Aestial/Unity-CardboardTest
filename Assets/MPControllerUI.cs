using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MPControllerUI : MonoBehaviour {

    private MediaPlayerCtrl controller;
    private int currentVideoDuration;
    private int videoIndex;
    private int counter = 0;

    public Slider timeSlider;
    public int scrubRefreshFrames = 3;
    public string[] titleStrings;

	// Use this for initialization
	void Start () {
        controller = GetComponent<MediaPlayerCtrl>();
        currentVideoDuration = controller.GetDuration();
        videoIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
        var updateScroll = counter % scrubRefreshFrames == 0;
        if (updateScroll)
            //timeSlider.value = controller.GetSeekPosition() / currentVideoDuration;
        counter++;
    }

    public void ChangeVideo (int dir) {
        videoIndex += dir;
        if (videoIndex < 0)
            videoIndex = titleStrings.Length - 1;
        else if (videoIndex > titleStrings.Length - 1)
            videoIndex = 0;
        Debug.Log(titleStrings[videoIndex]);
        controller.Load(titleStrings[videoIndex]+".mp4");
        controller.Play();
    }
    
    public void PlayPause (bool pause) {
        if (pause) controller.Pause();
        else controller.Play();
    }

    public void ChangePlaybackPosition (float pos) {
        controller.SeekTo( Mathf.FloorToInt(pos * currentVideoDuration) );
    }
}
