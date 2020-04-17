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

    public void ExitShop()
    {
        Destroy(gameObject);

        EventManager.TriggerEvent("CustomerLeftShop");
    }

    /*public void MoveTowardsPosition(float x, float y, float z)
    {
        // Rotate Customer to where he's heading
        //transform.Rotate(m_rotateSpeed * Time.deltaTime); // customer front flips forever
        transform.position = Vector3.MoveTowards(transform.position, 
                                                 new Vector3(x, y, z), 
                                                 m_speed * Time.deltaTime);
    }*/

    void OnButtonDealPressed()
    {
        Debug.Log("Customer::OnButtonDealPressed()");
        if (m_state is CustomerNegotiatingState)
        {
            SetState(new CustomerLeavingState(this));
        }
    }

    void OnButtonNoDealPressed()
    {
        Debug.Log("Customer::OnButtonNoDealPressed()");
        if (m_state is CustomerNegotiatingState)
        {
            SetState(new CustomerLeavingState(this));
        }
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

        // Create listeners to handle the player accepting/declining negotiations
        EventManager.StartListening("ButtonDealPressed", OnButtonDealPressed);
        EventManager.StartListening("ButtonNoDealPressed", OnButtonNoDealPressed);

        // TODO when entering the shoppe, the default state should be shopping
        SetState(new CustomerPreparingForCheckoutState(this));
    }

    // Update is called once per frame
    void Update()
    {
        m_state.UpdateState();
    }
}
