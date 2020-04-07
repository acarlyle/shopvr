using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLeavingState : CustomerState
{
    public CustomerLeavingState(Customer customer) : base(customer)
    {
        
    }

    public override void OnStateEnter()
    {
        Debug.Log("CustomerLeavingState::OnStateEnter()");
    }

    public override void OnStateExit()
    {
        
    }

    public override void UpdateState()
    {
        // Check position in line and move towards shop entrance if space
        Transform entranceTransform = GameObject.Find("ShopEntrance").transform;
        if ((m_customer.transform.position - entranceTransform.position).magnitude > 1.0f)
        {
            m_customer.MoveTowardsPosition(m_customer.transform.position.x, m_customer.transform.position.y, entranceTransform.position.z);
        }
        else
        {
            // Remove customer from existance
            m_customer.ExitShop();
        }
    }

}
