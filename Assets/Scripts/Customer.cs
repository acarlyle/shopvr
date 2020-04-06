using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Base class for all customers in your shoppe.  
*/
public class Customer : MonoBehaviour
{

    protected float m_speed;
    protected CustomerState m_state; // What this customer is currently doing
    protected Vector3 m_rotateSpeed;

    public float GetSpeed()
    {
        return m_speed;
    }

    void OnButtonDealPressed()
    {
        Debug.Log("Customer::OnButtonDealPressed()");
    }

    void OnButtonNoDealPressed()
    {
        Debug.Log("Customer::OnButtonNoDealPressed()");
    }

    public void SetState(CustomerState state)
    {
        if (m_state != null)
            m_state.OnStateExit();

        m_state = state;

        if (m_state != null)
            m_state.OnStateEnter();

    }

    // Start is called before the first frame update
    void Start()
    {
        m_rotateSpeed = Vector3.right * 50.0f;
        m_speed = 2.0f;

        EventManager.StartListening("ButtonDealPressed", OnButtonDealPressed);
        EventManager.StartListening("ButtonNoDealPressed", OnButtonNoDealPressed);

        // TODO when entering the shoppe, the default state should be shopping
        SetState(new CustomerWaitingState(this));
    }

    // Update is called once per frame
    void Update()
    {
        m_state.UpdateState();
    }
}
