using UnityEngine;

public class MapGameManager : MonoBehaviour
{
    private void Awake()
    {
        Castle.Instance.BuildCastle();
    }
}
