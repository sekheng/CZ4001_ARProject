using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Cactus : MonoBehaviour
{
    public GameObject cactusPrefab;
    public Button cactusButton;
    private ARRaycastManager arRaycastManager;
    private bool isFoxButtonPressed = false;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        cactusButton.onClick.AddListener(OnFoxButtonPressed);
    }

    void OnFoxButtonPressed()
    {
        isFoxButtonPressed = true;
    }

    void Update()
    {
        if (!isFoxButtonPressed || EventSystem.current.IsPointerOverGameObject(0)) return;

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(Input.touches[0].position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                Instantiate(cactusPrefab, hits[0].pose.position, Quaternion.identity);
                isFoxButtonPressed = false;
            }
        }
    }
}