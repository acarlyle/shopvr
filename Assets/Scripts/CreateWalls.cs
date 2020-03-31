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
        float yPosOffGround = 2.0f;
        print("vCorners0: " + boundaryRect.vCorners0.v0 + ", " + boundaryRect.vCorners0.v1 + ", " + boundaryRect.vCorners0.v2);
        print("vCorners1: " + boundaryRect.vCorners1.v0 + ", " + boundaryRect.vCorners1.v1 + ", " + boundaryRect.vCorners1.v2);
        print("vCorners2: " + boundaryRect.vCorners2.v0 + ", " + boundaryRect.vCorners2.v1 + ", " + boundaryRect.vCorners2.v2);
        print("vCorners3: " + boundaryRect.vCorners3.v0 + ", " + boundaryRect.vCorners3.v1 + ", " + boundaryRect.vCorners3.v2);
        llCorner = Instantiate(llCorner, new Vector3(boundaryRect.vCorners0.v0, yPosOffGround, boundaryRect.vCorners0.v2), Quaternion.identity);
        lrCorner = Instantiate(lrCorner, new Vector3(boundaryRect.vCorners1.v0, yPosOffGround, boundaryRect.vCorners1.v2), Quaternion.identity);
        urCorner = Instantiate(urCorner, new Vector3(boundaryRect.vCorners2.v0, yPosOffGround, boundaryRect.vCorners2.v2), Quaternion.identity);
        ulCorner = Instantiate(ulCorner, new Vector3(boundaryRect.vCorners3.v0, yPosOffGround, boundaryRect.vCorners3.v2), Quaternion.identity);

        //Create walls in between each of the corners
        CreateWall(llCorner, lrCorner);
        CreateWall(lrCorner, urCorner);
        CreateWall(urCorner, ulCorner);
        CreateWall(ulCorner, llCorner);
    }

    // Takes 2 WallCorner GameObjects and creates a Wall GameObject between them.  
    private void CreateWall(GameObject wallCornerStart, GameObject wallCornerEnd)
    {
        wall = Instantiate(wall, wallCornerStart.transform.position, Quaternion.identity);
        wallCornerStart.transform.LookAt(wallCornerEnd.transform.position);
        wallCornerEnd.transform.LookAt(wallCornerStart.transform.position);

        // Compute the distance between the WallCorner objects to center the Wall between them
        float cornerDistance = Vector3.Distance(wallCornerStart.transform.position, wallCornerEnd.transform.position);
        wall.transform.position = wallCornerStart.transform.position + cornerDistance/2 * wallCornerStart.transform.forward;

        // Adjust angle of wall to be lined up with the angle of the WallCorners
        wall.transform.rotation = wallCornerStart.transform.rotation;

        // Adjust the size of the wall to fill the gap between the two WallCorners
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.transform.localScale.y, cornerDistance);
    }

}
