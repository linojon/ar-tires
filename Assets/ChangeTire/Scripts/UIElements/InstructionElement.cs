using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstructionElement : MonoBehaviour {

    void Start() {
        InstructionsController.Instance.OnInstructionUpdate.AddListener(InstructionUpdate);
    }

    protected abstract void InstructionUpdate(InstructionStep step);
}
