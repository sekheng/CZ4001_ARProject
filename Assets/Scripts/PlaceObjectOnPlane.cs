using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField]
    GameObject placedPrefab;

    public GameObject spawnedObject;
    public ARRaycastManager arRaycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    ARAnchor CreateAnchor(in ARRaycastHit hit)
    {
        // create a regular anchor at the hit pose
        ARAnchor anchor;
        spawnedObject = Instantiate(placedPrefab, hit.pose.position, hit.pose.rotation);
        anchor = spawnedObject.GetComponent<ARAnchor>();
        if (anchor == null)
        {
            anchor = spawnedObject.AddComponent<ARAnchor>();
        }

        return anchor;
    }

    public void OnPlaceObject()
    {
        StartCoroutine(SpawnObjectWithDelay());
    }

    IEnumerator SpawnObjectWithDelay()
    {
        yield return new WaitForSeconds(0.7f);

        Vector2 touchPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            //get the hit point(pose) on the plane
            Pose hitPose = hits[0].pose;
            //if this is the first time placing an object,
            if (spawnedObject == null)
            {
                //instantiate the prefab at the hit position and rotation
                //spawnedObject = Instantiate(placedPrefab, hitPose.position, Quaternion.Inverse(hitPose.rotation));
                CreateAnchor(hits[0]);
            }
            //else
            else
            {
                //change the position of the previously instantiated object
                spawnedObject.transform.SetPositionAndRotation(hitPose.position, Quaternion.Inverse(hitPose.rotation));
            }
        }
    }
}