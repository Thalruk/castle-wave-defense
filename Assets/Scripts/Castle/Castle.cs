using UnityEngine;

public class Castle : MonoBehaviour
{
    public static Castle Instance;

    [Header("Castle settings")]
    [SerializeField] int castleRadius;
    [SerializeField] GameObject castleHeart;
    [Space]

    [Header("Towers settings")]
    [SerializeField] Transform towerHolder;
    [SerializeField] int towerAmount;
    [SerializeField] GameObject towerPrefab;
    [Space]

    [Header("Walls settings")]
    [SerializeField] Transform wallHolder;
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
        SetUpFortHeart();
    }

    private void SetUpTowers()
    {
        float nextAngle = 2 * Mathf.PI / towerAmount;
        float angle;

        if (towerAmount == 4)
        {
            angle = Mathf.PI / 4;
        }
        else if (towerAmount == 6)
        {
            angle = 0;
        }
        else if (towerAmount == 8)
        {
            angle = Mathf.PI / 8;
        }
        else if (towerAmount == 10)
        {
            angle = 0;
        }
        else
        {
            angle = 2 * Mathf.PI / 4;
        }

        for (int i = 0; i < towerAmount; i++)
        {
            float x = Mathf.Cos(angle) * castleRadius;
            float z = Mathf.Sin(angle) * castleRadius;

            GameObject tower = Instantiate(towerPrefab, new Vector3(x, 0, z), Quaternion.LookRotation((new Vector3(x, 0, z) - transform.position).normalized), towerHolder);
            tower.name += $" {i + 1}";
            angle += nextAngle;
        }
    }

    private void SetUpWalls()
    {
        for (int i = 0; i < towerAmount; i++)
        {
            {
                float wallX = (towerHolder.GetChild(i).transform.position.x + towerHolder.GetChild((i + 1) % towerAmount).transform.position.x) / 2;
                float wallZ = (towerHolder.GetChild(i).transform.position.z + towerHolder.GetChild((i + 1) % towerAmount).transform.position.z) / 2;

                float distance = Vector3.Distance(towerHolder.GetChild(i).transform.position, towerHolder.GetChild((i + 1) % towerAmount).transform.position);

                GameObject wall = Instantiate(wallPrefab, new Vector3(wallX, 0, wallZ), Quaternion.LookRotation((new Vector3(wallX, 0, wallZ) - transform.position).normalized), wallHolder);
                wall.name += $" {i + 1}-{(i + 2) % (towerAmount + 1)}";
                wall.transform.localScale += new Vector3(distance - 1, 0, 0);
            }
        }
    }

    private void SetUpFortHeart()
    {
        Instantiate(castleHeart, transform.position, Quaternion.identity, transform);
    }


    public void DeleteEnemyInTowers(Enemy enemy)
    {
        foreach (Transform tower in towerHolder)
        {
            tower.GetComponent<Tower>().DeleteEnemy(enemy);
        }
    }
}