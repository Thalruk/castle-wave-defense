using UnityEngine;

public class CastleHeart : MonoBehaviour
{
    public static CastleHeart Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
}
