using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public Vector3 target;
    [SerializeField] public int speed;

    private void Awake()
    {
        Destroy(gameObject, 30);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
            print("en tri");
        }

        if (other.CompareTag("Ground"))
        {
            speed = 0;
            GetComponent<BoxCollider>().enabled = false;
            print("ground tri");
        }

    }
}
