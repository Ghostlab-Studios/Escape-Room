using UnityEngine;

public class Platform : MonoBehaviour
{
    private Scalable currentScalableObject;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("scale up");
        Scalable scalable = other.GetComponent<Scalable>();
        if (scalable != null)
        {
            currentScalableObject = scalable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Scalable scalable = other.GetComponent<Scalable>();
        if (scalable != null && scalable == currentScalableObject)
        {
            currentScalableObject = null;
        }
    }

    public Scalable GetCurrentScalableObject()
    {
        return currentScalableObject;
    }
}
