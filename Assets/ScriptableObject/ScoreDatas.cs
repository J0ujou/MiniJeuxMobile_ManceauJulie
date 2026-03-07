using UnityEngine;

[CreateAssetMenu(fileName = "ScoreDatas", menuName = "Scriptable Objects/ScoreDatas")]
public class ScoreDatas : ScriptableObject
{
    public int ScoreValue = 0;
    public int Level =  1;
    public float BarrierSpeed = 5f;
}
