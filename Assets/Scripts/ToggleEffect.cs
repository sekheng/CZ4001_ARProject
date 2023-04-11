using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEffect : MonoBehaviour
{
    public GameObject prefab;

    public void Toggle()
    {
        if (prefab.activeSelf)
        {
            prefab.SetActive(false);
        }
        else
        {
            prefab.SetActive(true);
        }
    }
}
