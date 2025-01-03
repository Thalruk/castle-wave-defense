using UnityEngine;

public class MapGameManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] Transform enemySpawn;
    [SerializeField] bool timeSlowed = false;
    [SerializeField] float slowedTimeScale = 0.5f;

    private void Awake()
    {
        Castle.Instance.BuildCastle();
        InvokeRepeating(nameof(SpawnEnemy), 0, 3);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeSlowed = !timeSlowed;
        }

        if (timeSlowed)
        {
            Time.timeScale = slowedTimeScale;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, enemySpawn.position + (Vector3)Random.insideUnitCircle, Quaternion.identity);
    }
}
