using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create walls of the shop based on the chaperone bounds 
        GetComponent<CreateWalls>().Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
