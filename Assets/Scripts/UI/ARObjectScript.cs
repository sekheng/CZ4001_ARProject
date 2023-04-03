using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To send the event name based on the on click function
/// </summary>
public class ARObjectScript : MonoBehaviour
{
    public const string AR_OBJECT_SELECTED = "AR_OBJECT_SELECTED";
    /// <summary>
    /// It sends the event name to the observer system
    /// then other subscribers will receive it
    /// </summary>
    /// <param name="objName"></param>
    public void SendSelectedObjectEvent(string objName)
    {
        ObserverSystem.Instance.TriggerEvent(AR_OBJECT_SELECTED, objName);
    }
}
