using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstructionElement : MonoBehaviour {

    void Awake()
    {
        FindObjectOfType<InstructionsController>().OnInstructionUpdate.AddListener(InstructionUpdate);
    }

    protected abstract void InstructionUpdate(InstructionStep step);
}
