using UnityEngine;

public class EventFunctions : MonoBehaviour
{
    public int countForUpdate,
        maxCountForUpdate = 20;
    private void Awake()
    {
        Debug.Log("The Gods have awakened");
        countForUpdate = 0;
    }

    private void OnEnable()
    {
        print(countForUpdate);
        Debug.Log("This script has been enabled");
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Started");
    }

    private void FixedUpdate()
    {
        Debug.Log($"FixedUpdate happened ({countForUpdate})");
    }
    // Update is called once per frame
    private void Update()
    {
        Debug.Log($"Update happened ({countForUpdate})");
    }

    private void LateUpdate()
    {
        Debug.Log($"LateUpdate happened ({countForUpdate})");
        if (countForUpdate == maxCountForUpdate)
        {
            this.enabled = false;
        }
        else
        {
            ++countForUpdate;
        }
    }

    private void OnDisable()
    {
        Debug.Log("This script has been disabled");
    }
}
