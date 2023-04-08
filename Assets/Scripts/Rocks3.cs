using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Rocks3 : MonoBehaviour
{
    public GameObject rockssPrefab;
    public Button rocksButton;
    private ARRaycastManager arRaycastManager;
    private bool isRocksButtonPressed = false;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        rocksButton.onClick.AddListener(OnFoxButtonPressed);
    }

    void OnFoxButtonPressed()
    {
        isRocksButtonPressed = true;
    }

    void Update()
    {
        if (!isRocksButtonPressed || EventSystem.current.IsPointerOverGameObject(0)) return;

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(Input.touches[0].position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                Instantiate(rockssPrefab, hits[0].pose.position, Quaternion.identity);
                isRocksButtonPressed = false;
            }
        }
    }
}