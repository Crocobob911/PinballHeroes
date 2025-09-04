using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Script
{
    public class BallObjectPool : MonoBehaviour
    {
        public static BallObjectPool Instance { get; private set; }
        
        [SerializeField]
        private GameObject ballPrefab;

        [SerializeField]
        private int poolSize;
        private IObjectPool<GameObject> ballPool;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            // 오브젝트 풀 초기화
            ballPool = new ObjectPool<GameObject>(
                createFunc: () =>
                {
                    GameObject ball = Instantiate(ballPrefab);
                    return ball;
                }
                , actionOnGet: (ball) =>
                {
                    ball.SetActive(true);
                }
                , actionOnRelease: (ball) =>
                {
                    ball.SetActive(false);
                }
                , actionOnDestroy: (ball) =>
                {
                    Destroy(ball);
                }
                , maxSize: poolSize
            );
        }

        public GameObject GetBall()
        {
            return ballPool.Get();
        }

        public void ReturnBall(GameObject ball)
        {
            ballPool.Release(ball);
        }
    }
}