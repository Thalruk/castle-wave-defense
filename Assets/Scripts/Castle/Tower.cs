using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int attackRadius;
    [SerializeField] float attacksPerSecond;
    [SerializeField] GameObject arrowProjectile;
    [SerializeField] int arrowSpeed;
    [SerializeField] int arrowDamage;

    [Space]
    [Tooltip("Enemies in range")]
    [SerializeField] List<Enemy> enemyList;

    float attackSpeed;
    float timeBetweenShots;


    private void Awake()
    {
        enemyList = new List<Enemy>();
        attackSpeed = 1 / attacksPerSecond;
    }

    private void Update()
    {
        timeBetweenShots += Time.deltaTime;
        if (enemyList.Count > 0 && timeBetweenShots >= attackSpeed)
        {
            Shoot(enemyList[Random.Range(0, enemyList.Count)]);
            timeBetweenShots -= attackSpeed;
        }
    }

    private void Shoot(Enemy enemy)
    {
        Projectile projectile = Instantiate(arrowProjectile, transform.position + Vector3.up * 5, Quaternion.identity).GetComponent<Projectile>();
        projectile.target = enemy.transform.GetChild(0).GetChild(0);
        projectile.damage = arrowDamage;
        projectile.speed = arrowSpeed;
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
