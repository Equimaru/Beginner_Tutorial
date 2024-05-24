using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public static PauseSystem Instance => _instance;
    private static PauseSystem _instance;

    private List<IPausable> _pausables = new();

    private void Awake()
    {
        _instance = this;
    }

    public void AddPausable(IPausable pausable)
    {
        _pausables.Add(pausable);
    }

    public void RemovePausable(IPausable pausable)
    {
        
    }

    public void Pause()
    {
        foreach (var pausable in _pausables)
        {
            pausable.Pause();
        }
    }
    
    public void Resume()
    {
        foreach (var pausable in _pausables)
        {
            pausable.Resume();
        }
    }
}
