using UnityEngine;

[CreateAssetMenu(fileName = "New ObstacleData", menuName = "GameData/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public int key;
    public string name;
    public int scoreIncrease;
    public bool isDisappear;
    public bool isOneTimeUse;
    public int ballSpeedChange;
    public int ballSizeChange;
    public int ballCountChange;
    public int changeObstacle;
}
