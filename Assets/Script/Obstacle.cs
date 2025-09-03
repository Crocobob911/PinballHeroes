using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private List<ObstacleAction> actions = new List<ObstacleAction>();

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag($"Ball")) return;
        ExecuteActions();
        
        // TODO : Destroy가 아닌 pool을 사용할 것
        Destroy(gameObject);
    }

    private void ExecuteActions()
    {
        foreach (var action in actions)
        {
            if (action != null)
            {
                action.Execute(gameObject);
            }
        }
    }
}

