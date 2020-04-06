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
        // Let the CustomerManager know this customer is now negotiating  
        //GetComponent<CustomerManager>().SetNegotiatingCustomer(m_customer);
        //m_customer.CustomerManager().SetNegotiatingCustomer(this);
        //CustomerManager.SetNegotiatingCustomer(m_customer);
    }

    public override void OnStateExit()
    {
        
    }

    public override void UpdateState()
    {
        
    }

}
