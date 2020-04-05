using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDepartingState : CustomerState
{
    public CustomerDepartingState(Customer customer) : base(customer)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("CustomerDepartingState::OnStateEnter()");
    }

    public override void OnStateExit()
    {
        
    }

    public override void UpdateState()
    {
        
    }

}