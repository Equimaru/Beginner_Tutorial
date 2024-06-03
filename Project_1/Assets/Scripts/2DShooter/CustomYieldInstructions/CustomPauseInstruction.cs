using UnityEngine;

public class CustomPauseInstruction : CustomYieldInstruction
{
    public override bool keepWaiting
    {
        get
        {
            if (PauseSystem.Instance.IsPaused)
            {
                _pauseTimer += Time.unscaledDeltaTime;
                return true;
            }
            return Time.unscaledTime - _startTime < _pauseTimer;
        }
    }
    
    private readonly IPausable _iPausable;
    private float _pauseTimer;
    private readonly float _startTime;

    public CustomPauseInstruction(IPausable iPausable, float pauseTimer)
    {
        _pauseTimer = pauseTimer;
        _startTime = Time.unscaledTime;
        _iPausable = iPausable;
    }
}
