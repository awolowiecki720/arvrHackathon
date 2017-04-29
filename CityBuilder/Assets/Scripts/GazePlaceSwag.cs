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
    private Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AirTapSwag.AirTap)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, 1 << gameObject.layer) && hit.collider.gameObject == gameObject)
            {
                pickedUp = true;
            }
        }

        if (pickedUp)
        {
            Vector3 camPos = Camera.main.transform.position;
            Vector3 pos = Vector3.zero;

            pos = camPos + Camera.main.transform.forward * mDist;

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, pos, lerpSpeed);
        }
       
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (!pickedUp)
        {
            InputManager.Instance.PushModalInputHandler(this.gameObject);
            if (rigidBody)
            {
                rigidBody.useGravity = false;
            }
            
        }
        else
        {
            InputManager.Instance.PopModalInputHandler();
            if (rigidBody)
            {
                rigidBody.useGravity = true;
            }
            
        }

        TogglePickUpState();
    }

    private void TogglePickUpState()
    {
        pickedUp = !pickedUp;
        mDist = Vector3.Distance(Camera.main.transform.position, this.transform.position);
    }
}
