using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float panSpeed = 20f;
    [SerializeField] float panBorderThickness = 20;
    [SerializeField] float scrollSpeed = 20;

    [Space]
    [Header("Limit Settings")]
    [SerializeField] int mapSize;
    [SerializeField] int minY, maxY;

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.y -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * 100 * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -mapSize, mapSize);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -mapSize, mapSize);

        transform.position = pos;
    }
}
