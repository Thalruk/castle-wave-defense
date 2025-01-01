using UnityEngine;

public class Castle : MonoBehaviour
{

    [SerializeField] CastleData data;
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
