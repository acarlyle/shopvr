using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The customer has finished their shopping and is now heading to the back of the checkout line. */
public class CustomerPreparingForCheckoutState : CustomerState
{
    public CustomerPreparingForCheckoutState(Customer customer) : base(customer)
    {
        
    }

    public override void OnStateEnter()
    {
        Debug.Log("CustomerPreparingForCheckoutState::OnStateEnter()");

        GameObject pointEntranceTransform = GameObject.Find("NavPointShopEntrance");
        GameObject pointCustomerLineEndTransform = GameObject.Find("NavPointCustomerLineEnd");

        SetStateNavPoints(pointEntranceTransform, pointCustomerLineEndTransform);

    }

    public override void OnStateExit()
    {
        
    }

    public override void UpdateState()
    {
        // Check position in line and move towards counter if space
        Transform counterTransform = GameObject.Find("NavPointCustomerLineEnd").transform;
        if ((m_customer.transform.position - counterTransform.position).magnitude > 0.5f)
        {
            //m_customer.MoveTowardsPosition(m_customer.transform.position.x, m_customer.transform.position.y, counterTransform.position.z);
        }
        else
        {
            m_customer.SetState(new CustomerWaitingInLineState(m_customer));
        }
    }

}
