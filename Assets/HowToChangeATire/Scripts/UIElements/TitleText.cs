using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TitleText : InstructionElement {
    protected override void InstructionUpdate(InstructionStep step) {
        Debug.Log("title: " + step.Title);
        GetComponent<Text>().text = step.Title;
    }
}
