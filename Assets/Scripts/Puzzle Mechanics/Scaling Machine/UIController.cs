using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button scaleUpButton;
    public Button scaleDownButton;
    public Platform platform;

    void Start()
    {
        scaleUpButton.onClick.AddListener(OnScaleUpButtonClick);
        scaleDownButton.onClick.AddListener(OnScaleDownButtonClick);
    }

    void OnScaleUpButtonClick()
    {
        
        Scalable scalableObject = platform.GetCurrentScalableObject();
        if (scalableObject != null)
        {
            Debug.Log("scale up");
            scalableObject.ScaleUp();
        }
    }

    void OnScaleDownButtonClick()
    {
        Scalable scalableObject = platform.GetCurrentScalableObject();
        if (scalableObject != null)
        {
            scalableObject.ScaleDown();
        }
    }
}
