using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR; // Definitions for OpenVR references

public class CreateWalls : MonoBehaviour
{

    public GameObject llCorner;
    public GameObject lrCorner;
    public GameObject ulCorner;
    public GameObject urCorner;
    public GameObject wall;

    public void Create()
    {
        print("CreateWalls::Create()");
        HmdQuad_t boundaryRect = VRInterface.chaperoneRect;
        print("vCorners0: " + boundaryRect.vCorners0.v0 + ", " + boundaryRect.vCorners0.v1 + ", " + boundaryRect.vCorners0.v2);
        print("vCorners1: " + boundaryRect.vCorners1.v0 + ", " + boundaryRect.vCorners1.v1 + ", " + boundaryRect.vCorners1.v2);
        print("vCorners2: " + boundaryRect.vCorners2.v0 + ", " + boundaryRect.vCorners2.v1 + ", " + boundaryRect.vCorners2.v2);
        print("vCorners3: " + boundaryRect.vCorners3.v0 + ", " + boundaryRect.vCorners3.v1 + ", " + boundaryRect.vCorners3.v2);
        Instantiate(llCorner, new Vector3(boundaryRect.vCorners0.v0, boundaryRect.vCorners0.v1, boundaryRect.vCorners0.v2), Quaternion.identity);
        Instantiate(lrCorner, new Vector3(boundaryRect.vCorners1.v0, boundaryRect.vCorners1.v1, boundaryRect.vCorners1.v2), Quaternion.identity);
        Instantiate(ulCorner, new Vector3(boundaryRect.vCorners2.v0, boundaryRect.vCorners2.v1, boundaryRect.vCorners2.v2), Quaternion.identity);
        Instantiate(urCorner, new Vector3(boundaryRect.vCorners3.v0, boundaryRect.vCorners3.v1, boundaryRect.vCorners3.v2), Quaternion.identity);
    }

}
