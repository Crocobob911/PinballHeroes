using System;
using UnityEngine;

namespace Script {
    public class BallController : MonoBehaviour {
        [SerializeField]
        private Rigidbody2D rb;
        
        [SerializeField]
        private float speedOnCollision;

        private void Start() {
            rb = GetComponent<Rigidbody2D>();
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.CompareTag($"Obstacle")) {
                ApplyCollisionSpeedOnCollision();
            }
        }

        private void ApplyCollisionSpeedOnCollision() {
            Debug.Log("[ApplyCollisionSpeedOnCollision] 진입");
            
            Vector3 currentVelocity = rb.linearVelocity;
            Vector3 direction = currentVelocity.normalized;
            Vector3 newVelocity = direction * speedOnCollision;
            
            rb.linearVelocity = newVelocity;
        }
        
        public void SetCollisionSpeed( float speed ) {
            speedOnCollision = speed;
        }
    }
}