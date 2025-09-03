using UnityEngine;

[CreateAssetMenu(fileName = "New MapData", menuName = "GameData/MapData")]
public class MapData : ScriptableObject
{
    public int key;
    public string name;
    public int scoreIncrease;
    public string hello;
}
