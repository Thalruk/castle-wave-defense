using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(cam.transform);
    }
}
