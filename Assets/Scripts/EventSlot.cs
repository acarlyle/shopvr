using UnityEngine;
using Valve.VR.InteractionSystem;

public class EventSlot : MonoBehaviour
{
    public void OnButtonDealPress()
    {
        Debug.Log("We pushed our deal button!");
    }

    public void OnButtonNoDealPress()
    {
        Debug.Log("We pushed our no deal button!");
    }
}