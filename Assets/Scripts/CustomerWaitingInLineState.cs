using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWaitingInLineState : CustomerState
{
    public CustomerWaitingInLineState(Customer customer) : base(customer)
    {
        
    }

    public override void OnStateEnter()
    {
        Debug.Log("CustomerWaitingInLineState::OnStateEnter() -- disabling NavMeshAgent");
        // Customer is now no longer pathfinding while standing in line -- disable the pathfinding agent
        m_customer.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        // This customer is the newest customer waiting in line, so we need to move the end of the customer line position back 
        EventManager.TriggerEvent("NewCustomerInLine");

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
            //m_customer.MoveTowardsPosition(m_customer.transform.position.x, m_customer.transform.position.y, counterTransform.position.z);
        }
        else
        {
            m_customer.SetState(new CustomerNegotiatingState(m_customer));
        }
    }

}