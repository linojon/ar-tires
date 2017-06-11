using System.Collections;
using UnityEngine;

public class ARInstructions : InstructionElement
{
    private GameObject lastAugment;
 

    protected override void InstructionUpdate(InstructionStep step)
    {
    
    
 
        DisableLastObject();
        SetChildActiveByTitle(step.Title);
      


    }

   private void DisableLastObject()
    {
        if (lastAugment != null)
        {
            lastAugment.SetActive(false);
            lastAugment = null;
        }
    }

    private void SetChildActiveByTitle(string title)
    {
        Transform[] childObjects = GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < childObjects.Length; i++)
        {
            if (childObjects[i].name == title)
            {
                lastAugment = childObjects[i].gameObject;
                lastAugment.SetActive(true);
            }
        }

    }
}
