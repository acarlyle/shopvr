using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    //private const int m_numNavPoints = 2;

    public Transform[] m_points;

    private NavMeshAgent m_nav;
    private int m_destPoint;

    void GoToNextPoint()
    {
        if (m_points.Length == 0)
        {
            return;
        }

        m_nav.destination = m_points[m_destPoint].position;
        m_destPoint = (m_destPoint + 1) % m_points.Length;
    }

    public void SetNavObjects(params GameObject[] navObjs)
    {
        if (m_points.Length > 0)
        {
            m_points = null;
        }

        int navPointCtr = 0;

        // TODO need to somehow hold onto the actual NavPoint GameObject
        // in case its position updates
        m_points = new Transform[navObjs.Length];
        foreach(GameObject navObj in navObjs)
        {
            m_points[navPointCtr] = navObj.transform;
            navPointCtr++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_nav = GetComponent<NavMeshAgent>();

        //m_points = new Transform[m_numNavPoints];

        // Designate Navigation Points for the Customer to move between
        /*Transform pointEntranceTransform = GameObject.Find("NavPointShopEntrance").transform;
        Transform pointCustomerLineEndTransform = GameObject.Find("NavPointCustomerLineEnd").transform;
        m_points[0] = pointEntranceTransform;
        m_points[1] = pointCustomerLineEndTransform;*/

        // Register handler for updating the position of the end of the customer line for the NavMesh
        EventManager.StartListening("CustomerLineMoved", OnCustomerLineMoved);
    }

    public void OnCustomerLineMoved(EventParam eventParam)
    {

    }

    void Update()
    {
        if(m_nav.enabled)
        {
            if (!m_nav.pathPending && m_nav.remainingDistance < 0.5f)
            {
                GoToNextPoint();        
            }
        }
    }

}
