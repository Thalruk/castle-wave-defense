using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Enemy : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] int maxHealth;
    [SerializeField] int currenthealth;
    [SerializeField] Slider healthSlider;

    private void Awake()
    {
        healthSlider.maxValue = maxHealth;
        currenthealth = maxHealth;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        healthSlider.value = currenthealth;
    }
}
