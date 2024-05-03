using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("SpawnSystem").GetComponent<SpawnSystem>().StartDispawnProcedure(gameObject);
    }
}