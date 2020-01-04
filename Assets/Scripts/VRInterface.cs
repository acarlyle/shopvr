using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR; // Definitions for OpenVR references

public class VRInterface : MonoBehaviour
{
    /* OpenVR Rectangle whose points represent the boundaries of the VR play area. */
    public static HmdQuad_t chaperoneRect;

    //public float travelingSpeed {get; private set;} // public getter but private setter

    public bool SetChaperoneRect()
    {
        var chaperone = OpenVR.Chaperone;
        bool success = (chaperone != null) && chaperone.GetPlayAreaRect(ref chaperoneRect);
        return success;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!SetChaperoneRect())
        {
            print("Failed to get VR Play Area.  Should probably quit ?");
        }
        else
        {
            print("SetChaperoneRect success!");
            //print("vCorners0: " + chaperoneRect.vCorners0.v0 + ", " + chaperoneRect.vCorners0.v1 + ", " + chaperoneRect.vCorners0.v2);
            //print("vCorners1: " + chaperoneRect.vCorners1.v0 + ", " + chaperoneRect.vCorners1.v1 + ", " + chaperoneRect.vCorners1.v2);
            //print("vCorners2: " + chaperoneRect.vCorners2.v0 + ", " + chaperoneRect.vCorners2.v1 + ", " + chaperoneRect.vCorners2.v2);
            //print("vCorners3: " + chaperoneRect.vCorners3.v0 + ", " + chaperoneRect.vCorners3.v1 + ", " + chaperoneRect.vCorners3.v2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
