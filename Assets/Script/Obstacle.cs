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
        ExecuteAction( col );
    }

    private void ExecuteAction( Collision2D col )
    {
        foreach (var obstacleData in obstacleDatas)
        {
            if (obstacleData == null) continue;

            // 점수 Up
            BallHitCountManager.AddBallHitCount(obstacleData.scoreIncrease);
            BallController ballController = col.gameObject.GetComponent<BallController>();
            
            // 공 속도 변화
            if (obstacleData.addBallSpeed != 0)
            {
                ballController.AddBallSpeed( obstacleData.addBallSpeed );
            }
            
            // 공 크기 변화
            if (obstacleData.addBallSize != 0) {
                ballController.AddBallSize( obstacleData.addBallSize );
            }
            
            // 공 개수 증가
            if (obstacleData.addBallCount != 0) {
                ballController.AddBallCount( obstacleData.addBallCount );
            }
            
            // 오브젝트 삭제
            if (obstacleData.isDisappear)
            {
                // TODO : Destroy가 아닌 pool을 사용할 것
                Destroy(gameObject);
            }
        }
    }
}

