using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "Scriptable Objects/GameManager")]
public class GameManagerData : ScriptableObject
{
    public int score;
    public int lives;
    public int totalCollected;//  244 collected is needed

}
