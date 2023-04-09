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
        Vector2 touchPosition;
        if (TryGetTouchPosition(out touchPosition))
        {
            if (arRaycastManager.Raycast(touchPosition, hitResults))
            {
                var hitPose = hitResults[0].pose;
                Spawn(0, hitPose.position);
            }
        }
    }

    public void SpawnObject2()
    {
        Vector2 touchPosition;
        if (TryGetTouchPosition(out touchPosition))
        {
            if (arRaycastManager.Raycast(touchPosition, hitResults))
            {
                var hitPose = hitResults[0].pose;
                Spawn(1, hitPose.position);
            }
        }
    }

    public void SpawnObject3()
    {
        Vector2 touchPosition;
        if (TryGetTouchPosition(out touchPosition))
        {
            if (arRaycastManager.Raycast(touchPosition, hitResults))
            {
                var hitPose = hitResults[0].pose;
                Spawn(2, hitPose.position);
            }
        }
    }

    public void SpawnObject4()
    {
        Vector2 touchPosition;
        if (TryGetTouchPosition(out touchPosition))
        {
            if (arRaycastManager.Raycast(touchPosition, hitResults))
            {
                var hitPose = hitResults[0].pose;
                Spawn(3, hitPose.position);
            }
        }
    }

    public void SpawnObject5()
    {
        Vector2 touchPosition;
        if (TryGetTouchPosition(out touchPosition))
        {
            if (arRaycastManager.Raycast(touchPosition, hitResults))
            {
                var hitPose = hitResults[0].pose;
                Spawn(4, hitPose.position);
            }
        }
    }

    public void SpawnObject6()
    {
        Vector2 touchPosition;
        if (TryGetTouchPosition(out touchPosition))
        {
            if (arRaycastManager.Raycast(touchPosition, hitResults))
            {
                var hitPose = hitResults[0].pose;
                Spawn(5, hitPose.position);
            }
        }
    }
}
