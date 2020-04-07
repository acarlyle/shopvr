using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerNegotiatingState : CustomerState
{
    public CustomerNegotiatingState(Customer customer) : base(customer)
    {
        
    }

    public override void OnStateEnter()
    {
        Debug.Log("CustomerNegotiatingState::OnStateEnter()");
    }

    public override void OnStateExit()
    {
        
    }

    public override void UpdateState()
    {
        m_customer.SetState(new CustomerLeavingState(m_customer));
    }

}
