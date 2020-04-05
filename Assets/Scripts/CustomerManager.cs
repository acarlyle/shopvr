using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{

    private const int m_maxCustomers = 1;

    private Customer m_negotiatingCustomer; 
    private int m_numCustomers;

    public GameObject customer;

    public void SetNegotiatingCustomer(Customer customer)
    {
        m_negotiatingCustomer = customer;
        Debug.Log("CustomerManager::SetNegotiatingCustomer(Customer)");
    }

    // Start is called before the first frame update
    void Start()
    {
        m_numCustomers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Add new customer to shop if we have room for them
        if (m_numCustomers < m_maxCustomers)
            // Position to spawn customers is entrance of shop
            customer = Instantiate(customer, new Vector3(0.021f, 0.81f, 9.739f), Quaternion.identity);
            if (customer)
                m_numCustomers++;
    }
}
