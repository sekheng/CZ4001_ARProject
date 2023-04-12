using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public ARRaycastManager arRaycastManager;

    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    private void Spawn(int index, Vector3 position)
    {
        Debug.Log(objectsToSpawn[index]);
        Instantiate(objectsToSpawn[index], position, Quaternion.identity);
    }

    private IEnumerator DelayedSpawn(int index)
    {
        yield return new WaitForSeconds(1f);
        Vector2 touchPosition;
        if (TryGetTouchPosition(out touchPosition))
        {
            if (arRaycastManager.Raycast(touchPosition, hitResults))
            {
                var hitPose = hitResults[0].pose;
                Spawn(index, hitPose.position);
            }
        }
    }

    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    public void SpawnObject1()
    {
        StartCoroutine(DelayedSpawn(0));
    }

    public void SpawnObject2()
    {
        StartCoroutine(DelayedSpawn(1));
    }

    public void SpawnObject3()
    {
        StartCoroutine(DelayedSpawn(2));
    }

    public void SpawnObject4()
    {
        StartCoroutine(DelayedSpawn(3));
    }

    public void SpawnObject5()
    {
        StartCoroutine(DelayedSpawn(4));
    }

    public void SpawnObject6()
    {
        StartCoroutine(DelayedSpawn(5));
    }
}