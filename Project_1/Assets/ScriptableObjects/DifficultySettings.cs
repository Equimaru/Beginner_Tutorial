using UnityEngine;

[CreateAssetMenu(menuName = "DifficultySettings")]
public class DifficultySettings : ScriptableObject
{
    [SerializeField] private string difficulty;
    public string Difficulty => difficulty;
    [SerializeField] private int scoreToWin;
    public int ScoreToWin => scoreToWin;
    [SerializeField] private int scoreLossOnMiss;
    public int ScoreLossOnMiss => scoreLossOnMiss;
    [SerializeField] private int scoreLossOnDispawn;
    public int ScoreLossOnDispawm => scoreLossOnDispawn;
    [SerializeField] private float spawnCooldown;
    public float SpawnCooldown => spawnCooldown;
    [SerializeField] private float dispawnTime;
    public float DispawnTime => dispawnTime;
    
}
