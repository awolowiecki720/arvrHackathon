using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class GazePlaceSwag : MonoBehaviour, IInputClickHandler
{
    bool pickedUp = false;
    float lerpSpeed = 0.1f;
    float mDist = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AirTapSwag.AirTap)
        {
            pickedUp = true;
        }

        if (pickedUp)
        {
            Vector3 camPos = Camera.main.transform.position;
            Vector3 pos = Vector3.zero;

            pos = camPos + Camera.main.transform.forward * mDist;
        }
       
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!pickedUp)
            InputManager.Instance.PushModalInputHandler(this.gameObject);
        else
            InputManager.Instance.PopModalInputHandler();

        TogglePickUpState();
    }

    private void TogglePickUpState()
    {
        pickedUp = !pickedUp;
        mDist = Vector3.Distance(Camera.main.transform.position, this.transform.position);
    }
}
