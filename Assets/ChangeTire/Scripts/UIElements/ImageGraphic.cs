using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ImageGraphic : InstructionElement {
    protected override void InstructionUpdate(InstructionStep step) {
        if (!string.IsNullOrEmpty(step.ImageName)) {
            GetComponent<RawImage>().texture = Resources.Load(step.ImageName) as Texture;
        } else {
            GetComponent<RawImage>().texture = null;
            gameObject.SetActive(false);
        }
    }
}
