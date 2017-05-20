using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(RawImage))]
public class VideoGraphic : InstructionElement {
    public VideoPlayer videoPlayer;

    protected override void InstructionUpdate(InstructionStep step) {
        if (!string.IsNullOrEmpty(step.VideoName)) {
            videoPlayer.clip = Resources.Load(step.VideoName) as VideoClip;
            videoPlayer.Play();

        } else {
            videoPlayer.Stop();
            gameObject.SetActive(false);
        }
    }
}