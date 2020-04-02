using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Base class for all customers in your shoppe.  
*/
public class Customer : MonoBehaviour
{

    public enum State
    {
        Shopping,
        Negotiating,
        Waiting
    }

    private float m_speed = 2.0f;
    private State m_state; // What this customer is currently doing
    private Vector3 m_rotateSpeed = Vector3.right * 50.0f;

    void HandleState()
    {
        switch(m_state)
        {
            case State.Shopping:
                // Move customer to wait in line
                m_state = State.Waiting;
                break;
            case State.Waiting:
                // Check position in line and move towards counter if space
                Transform counterTransform = GameObject.Find("Counter").transform;
                //transform.Rotate(m_rotateSpeed * Time.deltaTime); // customer front flips forever
                if ((transform.position - counterTransform.position).magnitude > 1.0f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, 
                                                            new Vector3(transform.position.x, transform.position.y, counterTransform.position.z), 
                                                            m_speed * Time.deltaTime);
                }
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_state = State.Shopping;
    }

    // Update is called once per frame
    void Update()
    {
        HandleState();
    }
}
