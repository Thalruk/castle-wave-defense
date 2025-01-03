using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Enemy : MonoBehaviour
{
    CharacterController controller;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
}
