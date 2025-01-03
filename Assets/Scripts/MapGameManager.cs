using UnityEngine;

public class MapGameManager : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    private void Awake()
    {
        Castle.Instance.BuildCastle();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(enemy, hit.point, Quaternion.identity);
            }
        }
    }
}
