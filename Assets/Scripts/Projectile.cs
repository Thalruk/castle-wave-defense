using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float speed;

    private void Awake()
    {

    }
}
