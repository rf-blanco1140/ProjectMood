using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody body;
        [SerializeField] private float _movementSpeed; // SO ?
        public Vector2 inputDirection;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            Vector3 velocity = new Vector3(-inputDirection.y, 0, inputDirection.x) * _movementSpeed;
            
            body.AddForce(velocity, ForceMode.Force);
        }
    }
}
