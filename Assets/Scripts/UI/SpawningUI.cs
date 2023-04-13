using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawningUI : MonoBehaviour
{
    public const string CANCEL_SPAWN = "CANCEL_SPAWN";

    // Start is called before the first frame update
    void OnEnable()
    {
        ObserverSystem.Instance.SubscribeEvent<string>(ARObjectScript.AR_OBJECT_SELECTED, ARButtonSpawn);
    }

    // Update is called once per frame
    void OnDisable()
    {
        ObserverSystem.Instance.UnsubscribeEvent<string>(ARObjectScript.AR_OBJECT_SELECTED, ARButtonSpawn);
    }

    void ARButtonSpawn(string spawnName)
    {
        Debug.Log("Spawning " + spawnName);
    }

    public void CancelSpawn()
    {
        ObserverSystem.Instance.TriggerEvent(CANCEL_SPAWN);
    }
}
