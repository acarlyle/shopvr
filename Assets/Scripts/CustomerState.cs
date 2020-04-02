using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomerState
{
    protected Customer m_customer;

    // Called each game tick for this CustomerState
    public abstract void UpdateState();

    public virtual void OnStateEnter() {}
    public virtual void OnStateExit() {}

    public CustomerState(Customer customer)
    {
        m_customer = customer;
    }
}
