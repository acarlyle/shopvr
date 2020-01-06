using UnityEngine;
using Valve.VR.InteractionSystem;

public class Events : MonoBehaviour
{
    public void OnCustomButtonPress()
    {
        Debug.Log("We pushed our custom button!");
    }
}