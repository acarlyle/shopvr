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
    private CustomerLine m_customerLine;

    public GameObject customerPrefab;

    void OnCustomerLeftShop(EventParam eventParam)
    {
        m_numCustomers--;
        Debug.Log("CustomerManager::OnCustomerLeftShop() - A customer has exited the shop (hopefully much worse off).  # customers now: " + m_numCustomers);
    }

    void OnNewCustomerInLine(EventParam eventParam)
    {

        Debug.Log("OnNewCustomerInLine()");

        /*Transform endOfLineTransform = GameObject.Find("NavPointCustomerLineEnd").transform;
        Collider[] colliders; */

        // Find the customer at the end of the line
        //if((colliders = Physics.OverlapSphere(endOfLineTransform.position, 1f /* Radius */)).Length > 1) // Presuming the object you are testing also has a collider 0 otherwise
        /*{
            foreach(var collider in colliders)
            {
                var go = collider.gameObject; // This is the game object you collided with
                Debug.Log(go);
                if(go == gameObject) continue; // Skip the object itself
                
            }
        }*/

        // Add the new customer in line to the back of the m_customerLine
        Customer customer = (Customer) eventParam.emitterObj;

        // Move the back of the line away from the counter  
        GameObject navPointEndOfLine = GameObject.Find("NavPointCustomerLineEnd");
        navPointEndOfLine.transform.position = new Vector3(navPointEndOfLine.transform.position.x, 
                                                           navPointEndOfLine.transform.position.y, 
                                                           navPointEndOfLine.transform.position.z + 1.0f);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        m_numCustomers = 0;
        m_customerLine = new CustomerLine();
        
        EventManager.StartListening("CustomerLeftShop", OnCustomerLeftShop);
        EventManager.StartListening("NewCustomerInLine", OnNewCustomerInLine);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Add new customer to shop at the ShopEntrance object if we have room for them
        Transform entranceTransform = GameObject.Find("NavPointShopEntrance").transform;
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
