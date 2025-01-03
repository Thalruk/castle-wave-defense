using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int attackRadius;

    [Tooltip("Attacks per second")]
    [SerializeField] float attackSpeed;

    [SerializeField] GameObject arrowProjectile;


    [Space]
    [Tooltip("Enemies in range")]
    [SerializeField] List<Enemy> enemyList;

    private void Awake()
    {
        enemyList = new List<Enemy>();
    }

    private void Update()
    {
        if (enemyList.Count > 0)
        {

        }
    }

    private void Shoot(Enemy enemy)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyList.Add(other.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyList.Remove(other.GetComponent<Enemy>());
        }
    }
}
