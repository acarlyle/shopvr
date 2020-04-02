using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerNegotiatingState : CustomerState
{
    public CustomerNegotiatingState(Customer customer) : base(customer)
    {
        Debug.Log("CustomerNegotiatingState::OnStateEnter()");
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {
        
    }

    public override void UpdateState()
    {
        
    }

}
