using UnityEngine;

public class Castle : MonoBehaviour
{
    public static Castle Instance;

    [SerializeField] int towerAmount;
    [SerializeField] GameObject towerPrefab;
    [SerializeField] int castleRadius;

    [SerializeField] GameObject wallPrefab;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        DontDestroyOnLoad(this);
    }

    public void BuildCastle()
    {
        SetUpTowers();
        SetUpWalls();
    }

    private void SetUpTowers()
    {
        float nextAngle = 2 * Mathf.PI / towerAmount;
        float angle = 0;

        for (int i = 0; i < towerAmount; i++)
        {
            float x = Mathf.Cos(angle) * castleRadius;
            float z = Mathf.Sin(angle) * castleRadius;

            GameObject tower = Instantiate(towerPrefab, new Vector3(x, 0, z), Quaternion.LookRotation((new Vector3(x, 0, z) - transform.position).normalized), transform);
            tower.name += $" {i + 1}";
            angle += nextAngle;
        }
    }

    private void SetUpWalls()
    {
        for (int i = 0; i < towerAmount; i++)
        {
            {
                print($"{transform.GetChild(i).name}-{transform.GetChild((i + 1) % towerAmount).name}");

                float wallX = (transform.GetChild(i).transform.position.x + transform.GetChild((i + 1) % towerAmount).transform.position.x) / 2;
                float wallZ = (transform.GetChild(i).transform.position.z + transform.GetChild((i + 1) % transform.childCount).transform.position.z) / 2;

                float distance = Vector3.Distance(transform.GetChild(i).transform.position, transform.GetChild((i + 1) % towerAmount).transform.position);

                GameObject wall = Instantiate(wallPrefab, new Vector3(wallX, 0, wallZ), Quaternion.LookRotation((new Vector3(wallX, 0, wallZ) - transform.position).normalized));
                wall.name += $" {i + 1}-{(i + 2) % (towerAmount + 1)}";
                wall.transform.localScale += new Vector3(distance, 0, 0);
            }
        }
    }
}