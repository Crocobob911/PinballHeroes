using UnityEditor;
using UnityEngine;


[ExecuteInEditMode]
public class ObstaclePlacingManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    
    public GameObject[] GetObstacles()
    {
        return obstacles;
    }

    public GameObject GetObstacle(int idx) {
        return obstacles[idx];
    }
    
    
    public GameObject GetRandomObstacle()
    {
        return obstacles[Random.Range(0, obstacles.Length)];
    }
}