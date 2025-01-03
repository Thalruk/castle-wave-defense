using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int attackRadius;



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
