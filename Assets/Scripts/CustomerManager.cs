using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Manages how many customers we have in the shoppe and which customers will enter next.  
*/
public class CustomerManager : MonoBehaviour
{

    private const int m_maxCustomers = 1;

    private int m_numCustomers;

    public GameObject customerPrefab;

    void OnCustomerLeftShop()
    {
        m_numCustomers--;
        Debug.Log("CustomerManager::OnCustomerLeftShop() - A customer has exited the shop (hopefully much worse off).  # customers now: " + m_numCustomers);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_numCustomers = 0;
        EventManager.StartListening("CustomerLeftShop", OnCustomerLeftShop);
    }

    // Update is called once per frame
    void Update()
    {
        // Add new customer to shop at the ShopEntrance object if we have room for them
        Transform entranceTransform = GameObject.Find("ShopEntrance").transform;
        if (m_numCustomers < m_maxCustomers)
        {
            //Debug.Log("num Customers,max customers: " + m_numCustomers + "," + m_maxCustomers);
            // 0.2f -> hardcoded height offset; todo vary offset based on physical customer height
            var customerInst = Instantiate(customerPrefab, new Vector3(entranceTransform.position.x, entranceTransform.position.y + 0.8f, entranceTransform.position.z), Quaternion.identity);
            if (customerInst)
            {
                m_numCustomers++;
                Debug.Log("CustomerManager::Update() - A customer has been spawned in the shop.  # customers now: " + m_numCustomers);
            }
        }
    }
}
