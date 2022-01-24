using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody body;
        [SerializeField] private float _movementSpeed; // SO ?
        public Vector2 inputDirection;
        Vector3 previousDirection = Vector3.forward;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            PlayerMove();
            PlayerFaceDirection();
        }

        private void PlayerMove()
        {
            Vector3 rotatedVector = new Vector3(inputDirection.x, 0, inputDirection.y);
            Vector3 velocity = rotatedVector * _movementSpeed;
            body.AddForce(velocity, ForceMode.Force);
        }
        
        private void PlayerFaceDirection()
        {
            if (inputDirection != Vector2.zero)
            {
                Vector3 rotatedDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
                previousDirection = rotatedDirection;
                body.rotation = quaternion.LookRotation(rotatedDirection, Vector3.up);
            }
            else
            {
                body.rotation = quaternion.LookRotation(previousDirection, Vector3.up);
            }
        }
    }
}
