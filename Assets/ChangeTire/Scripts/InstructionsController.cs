using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InstructionEvent : UnityEvent<InstructionStep> { }

public class InstructionsController : MonoBehaviour {
    public InstructionEvent OnInstructionUpdate = new InstructionEvent();

    //public Text stepText;
    //public Text titleText;
    //public Text bodyText;

    public GameObject StandardContent;

    public GameObject ImageGraphic;
    public GameObject VideoGraphic;

    private int currentStep;
    private InstructionModel currentInstructionModel = new InstructionModel();

    public static InstructionsController Instance;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            this.enabled = false;
            return;
        }

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

    private void CurrentInstructionUpdate() {
        // ui hack
        //ImageGraphic.SetActive(true);
        //VideoGraphic.SetActive(true); 
        

        InstructionStep step = currentInstructionModel.GetInstructionStep(currentStep);
        Debug.Log("STEP " + step.Name + ": " + step.Title);

        OnInstructionUpdate.Invoke(step);
    }
}
