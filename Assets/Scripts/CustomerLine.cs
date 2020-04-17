using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class CustomerLine
{

    // LinkedList of each Customer's position in the line
    private LinkedList<Transform> m_data;

    public CustomerLine()
    {
        m_data = new LinkedList<Transform>();  
    }
}
