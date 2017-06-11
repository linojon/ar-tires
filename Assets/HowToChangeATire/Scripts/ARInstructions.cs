using System.Collections;
using UnityEngine;

public class ARInstructions : InstructionElement
{
    private GameObject lastAugment;
 

    protected override void InstructionUpdate(InstructionStep step)
    {

        DisableLastObject();
        FindChildByTitle(step.Title);
    }

   private void DisableLastObject()
    {
        if (lastAugment != null)
        {
            lastAugment.SetActive(false);
            lastAugment = null;
        }
    }

    private void FindChildByTitle(string title)
    {
        Transform childTransform = transform.FindChild(title);
        if (lastAugment)
        {
            lastAugment = childTransform.gameObject;
        }

    }
}
