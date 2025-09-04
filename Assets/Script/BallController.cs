using System;
using UnityEngine;

namespace Script {
    public class BallController : MonoBehaviour {
        [SerializeField]
        private Rigidbody2D rb;
        
        private void Start() {
            rb = GetComponent<Rigidbody2D>();
        }
        
        public void AddBallSpeed(float speed) {
            float currentSpeed = rb.linearVelocity.magnitude;
            Vector3 direction = rb.linearVelocity.normalized;
            
            float newSpeed = currentSpeed + speed;
            Vector3 newVelocity = direction * newSpeed;
            
            rb.linearVelocity = newVelocity;
        }

        public void AddBallSize(float size) {
            Vector3 currentSize = transform.localScale;
            Vector3 newSize = currentSize * size;
            transform.localScale = newSize;
        }

        public void AddBallCount(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject newBall = BallObjectPool.Instance.GetBall();
                if (newBall != null)
                {
                    newBall.transform.position = transform.position;
                    newBall.transform.rotation = transform.rotation;
                    newBall.transform.localScale = transform.localScale;
                    newBall.GetComponent<Rigidbody2D>().linearVelocity = rb.linearVelocity + new Vector2(0f, 0.4f);
                }
            }
        }
    }
}