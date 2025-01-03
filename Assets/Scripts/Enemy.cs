using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] int maxHealth;
    [SerializeField] int currenthealth;
    [SerializeField] Slider healthSlider;

    private void Awake()
    {
        healthSlider.maxValue = maxHealth;
        currenthealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(CastleHeart.Instance.transform.position);
    }

    private void Update()
    {
        healthSlider.value = currenthealth;
    }

    public void TakeDamage(int damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, maxHealth);
        if (currenthealth == 0)
        {
            Destroy(gameObject);
            Castle.Instance.DeleteEnemyInTowers(this);
        }
    }
}
