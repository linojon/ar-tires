using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Vuforia;

public class InstructionEvent : UnityEvent<InstructionStep> { }

public class InstructionsController : MonoBehaviour {
    public InstructionEvent OnInstructionUpdate = new InstructionEvent();
    public UserDefinedTargetBuildingBehaviour UserDefinedTargetBuilder;
    public GameObject StandardContent;


    private int currentStep;
    private bool arMode;
    private InstructionModel currentInstructionModel = new InstructionModel();

    //Removed singleton , resulted in lost event calls
 //   public static InstructionsController Instance;

    void Awake() {
        currentInstructionModel.LoadData();
    }

    void Start () {
        Debug.Log("STEP COUNT: " + currentInstructionModel.GetCount());
        currentStep = 0;
        CurrentInstructionUpdate();
    }

    public void NextStep() {
        if (currentStep < currentInstructionModel.GetCount() - 1) {
            currentStep++;
            CurrentInstructionUpdate();
        }
    }

    public void PreviousStep() {
        if (currentStep > 0) {
            currentStep--;
            CurrentInstructionUpdate();
        }
    }

    //Refreshes the data for objects that might have not been awake for original eventcall (ie: AR Content)
    public void ReloadData()
    {
        CurrentInstructionUpdate();
    }
    public void ToggleAr()
    {
        arMode = !arMode;
        if (arMode)
        {
            TurnOnArMode();
        }
        else
        {
            TurnOffArMode();
        }

    }

    void TurnOnArMode()
    {
        UserDefinedTargetBuilder.StartScanning();
        StandardContent.SetActive(false);
  
    }

    void TurnOffArMode()
    {
        UserDefinedTargetBuilder.StopScanning();
        StandardContent.SetActive(true);

    }

    private void CurrentInstructionUpdate() {

        InstructionStep step = currentInstructionModel.GetInstructionStep(currentStep);
        Debug.Log("STEP " + step.Name + ": " + step.Title);
        OnInstructionUpdate.Invoke(step);
 
    }
}
