using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public Vector3 defaultScale;
    public Quaternion defaultRotation;

    [Header("Rotating Attribute")]
    public float rotationSpeed;

    [Header("Scalling Attribute")]
    public float scaleSpeed = 0.1f;
    public float minScale = 0.5f;
    public float maxScale = 2f;

    private void Awake()
    {
        defaultScale = transform.localScale;
        defaultRotation = transform.localRotation;
    }

    public void SetObjectState(bool cond)
    {
        transform.localScale = defaultScale;
        transform.localRotation = defaultRotation;
        gameObject.SetActive(cond);
    }

    public void RotateObjectToLeft()
    {
        transform.Rotate(-Vector3.up * rotationSpeed);
    }

    public void RotateObjectToRight()
    {
        transform.Rotate(Vector3.up * rotationSpeed);
    }

    public void RotateObjectToUp()
    {
        transform.Rotate(-Vector3.right * rotationSpeed);
    }

    public void RotateObjectToDown()
    {
        transform.Rotate(Vector3.right * rotationSpeed);
    }

    public void ScaleObjectUp()
    {
        transform.localScale += Vector3.one * scaleSpeed;
        ClampScale();
    }

    public void ScaleObjectDown()
    {
        transform.localScale -= Vector3.one * scaleSpeed;
        ClampScale();
    }

    private void ClampScale()
    {
        Vector3 clampedScale = transform.localScale;
        clampedScale.x = Mathf.Clamp(clampedScale.x, minScale, maxScale);
        clampedScale.y = Mathf.Clamp(clampedScale.y, minScale, maxScale);
        clampedScale.z = Mathf.Clamp(clampedScale.z, minScale, maxScale);
        transform.localScale = clampedScale;
    }
}
