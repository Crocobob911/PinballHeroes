using System.Collections.Generic;
using Script;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private List<ObstacleData> obstacleDatas = new List<ObstacleData>();

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag($"Ball")) return;
        ExecuteAction();
    }

    private void ExecuteAction()
    {
        foreach (var obstacleData in obstacleDatas)
        {
            if (obstacleData == null) continue;

            // 점수 Up
            BallHitCountManager.AddBallHitCount(obstacleData.scoreIncrease);
            Debug.Log(obstacleData.ballSpeedChange +" "+ obstacleData.ballSizeChange +" "+ obstacleData.ballCountChange);
            
            // 공 속도 변화
            // Debug.Log(obstacleData.ballSpeedChange);
            
            // 공 크기 변화
            // Debug.Log(obstacleData.ballSizeChange);
            
            // 공 개수 증가
            // Debug.Log(obstacleData.ballCountChange);
            
            // 오브젝트 삭제
            if (obstacleData.isDisappear)
            {
                // TODO : Destroy가 아닌 pool을 사용할 것
                Destroy(gameObject);
            }
        }
    }
}

