using UnityEngine;

public class CalculateDifficulty : MonoBehaviour
{
    [SerializeField] private AnimationCurve _spawnFrequencyCurve;
    [SerializeField] private float _difficultyTimeMax;

    public static float CurrentDifficultyValue => currentDifficultyValue;
    private static float currentDifficultyValue = 0;

    private void Start()
    {
        currentDifficultyValue = _spawnFrequencyCurve.Evaluate(Time.timeSinceLevelLoad);
    }

    public void UpdateDifficulty()
    {
        currentDifficultyValue = _spawnFrequencyCurve.Evaluate(Time.timeSinceLevelLoad / _difficultyTimeMax);
    }
}