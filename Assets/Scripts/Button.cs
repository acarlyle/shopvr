﻿using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{

    public float pressLength;
    public bool pressed;

    Vector3 startPos;
    Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        //Debug.Log("BUTTON NAME: " + gameObject.name);
    }

    void Update()
    {
        // If our distance is greater than what we specified as a press
        // set it to our max distance and register a press if we haven't already
        float distance = Mathf.Abs(transform.position.y - startPos.y);
        if (distance >= pressLength)
        {
            // Prevent the button from going past the pressLength
            transform.position = new Vector3(transform.position.x, startPos.y - pressLength, transform.position.z);
            if (!pressed)
            {
                pressed = true;
                EventParam eventParam = new EventParam();
                switch(gameObject.name)
                {
                    case "ButtonDeal":
                        //eventParam.emitterObj = gameObject;
                        EventManager.TriggerEvent("ButtonDealPressed", eventParam);
                        break;
                    case "ButtonNoDeal":
                        //eventParam.emitterObj = gameObject;
                        EventManager.TriggerEvent("ButtonNoDealPressed", eventParam);
                        break;
                }
            }
        } else
        {
            // If we aren't all the way down, reset our press
            pressed = false;
        }
        // Prevent button from springing back up past its original position
        if (transform.position.y > startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
    }
}
