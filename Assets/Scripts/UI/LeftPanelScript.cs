using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// meant for tweening and handling the left panel script
/// </summary>
public class LeftPanelScript : MonoBehaviour
{
    [Header("Debugging Purpose")]
    [SerializeField, Tooltip("The float value to tween to")]
    float m_TweenSize;
    [SerializeField, Tooltip("Original position")]
    Vector3 OriginaPos;

    private void Awake()
    {
        RectTransform rectT = transform as RectTransform;
        m_TweenSize = rectT.rect.width;
        OriginaPos = rectT.localPosition;
    }

    public void SetPanelActive(bool active)
    {
        // then start tweening this panel left
        LeanTween.moveLocalX(gameObject, active ? OriginaPos.x + m_TweenSize : OriginaPos.x, 0.3f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            if (active)
            {
                Vector3 newPos = new Vector3(OriginaPos.x + m_TweenSize, OriginaPos.y, OriginaPos.z);
                transform.SetLocalPositionAndRotation(newPos, Quaternion.identity);
            }
            else
            {
                transform.SetLocalPositionAndRotation(OriginaPos, Quaternion.identity);
            }
        });

        //// Disable cactus spawning when the panel is active
        //if (active)
        //{
        //    FindObjectOfType<Cactus1>().OnFoxButtonPressed();
        //}
    }


    public void HidePanel()
    {
        LeanTween.moveLocalX(gameObject, OriginaPos.x, 0.3f).setEase(LeanTweenType.easeOutBack);
    }

}
