using UnityEngine;

[CreateAssetMenu(fileName = "New ObstacleData", menuName = "GameData/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public int key;
    public string name;
    public int scoreIncrease;
    public bool isDisappear;
    public bool isOneTimeUse;
    public int addBallSpeed;
    public int addBallSize;
    public int addBallCount;
    public int changeObstacle;
}
