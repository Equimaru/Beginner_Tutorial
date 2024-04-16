using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("To destroy object press F (3 seconds delay) or MouseClick (instant)");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject, 3f);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
