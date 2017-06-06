using System.Collections;
using UnityEngine;

public class ARInstructions : InstructionElement
{

    public GameObject[] AugmentedGameObjects;

    protected override void InstructionUpdate(InstructionStep step)
    {
        //Parses int from string
        int stepNumber = 0;
        int.TryParse(step.Name, out stepNumber);

        for (int i = 0; i < AugmentedGameObjects.Length; i++)
        {
            bool isCurrentStep =( i == stepNumber);
            if(AugmentedGameObjects[i] != null)
            AugmentedGameObjects[i].SetActive(isCurrentStep);
        }
    }
}
