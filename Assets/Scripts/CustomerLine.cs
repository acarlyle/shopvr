using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class CustomerLine
{

    // LinkedList of each Customer in the line
    private LinkedList<Customer> m_data;

    public CustomerLine()
    {
        m_data = new LinkedList<Customer>();  
    }
}
