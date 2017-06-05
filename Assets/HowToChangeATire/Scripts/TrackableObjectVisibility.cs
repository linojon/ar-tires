using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(TrackableBehaviour))]
public class TrackableObjectVisibility : MonoBehaviour, ITrackableEventHandler {

    public GameObject Target;
    public bool ShowOnFound = true;

    private TrackableBehaviour trackableBehaviour;

    void Start() {
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        trackableBehaviour.RegisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            OnTargetFound();
        } else {
            OnTargetLost();
        }
    }

    void OnTargetFound() {
        if (Target) {
            Target.SetActive(ShowOnFound);
        }
    }

    void OnTargetLost() {
        if (Target) {
            Target.SetActive(!ShowOnFound);
        }
    }
}
