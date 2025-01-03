using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public Transform target;
    [SerializeField] public int speed;
    [SerializeField] AnimationCurve curve;

    private void Awake()
    {
        Destroy(gameObject, 30);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //float newX = Mathf.MoveTowards(transform.position.x, target.position.x, speed * Time.deltaTime);
        //float newY = curve.Evaluate(1);
        //float newZ = Mathf.MoveTowards(transform.position.z, target.position.z, speed * Time.deltaTime);

        //transform.position = new Vector3(newX, newY, newZ);
        transform.LookAt(target.position);
    }
}
