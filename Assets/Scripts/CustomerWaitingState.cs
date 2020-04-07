using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitingState : CustomerState
{
    public CustomerWaitingState(Customer customer) : base(customer)
    {
        
    }

    public override void OnStateEnter()
    {
        Debug.Log("CustomerWaitingState::OnStateEnter()");
    }

    public override void OnStateExit()
    {
        
    }

    public override void UpdateState()
    {
        // Check position in line and move towards counter if space
        Transform counterTransform = GameObject.Find("Counter").transform;
        if ((m_customer.transform.position - counterTransform.position).magnitude > 1.0f)
        {
            m_customer.MoveTowardsPosition(m_customer.transform.position.x, m_customer.transform.position.y, counterTransform.position.z);
        }
        else
        {
            m_customer.SetState(new CustomerNegotiatingState(m_customer));
        }
    }

}