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

        //Hello
        [SerializeField] private BoolVariable canWalk;
        [SerializeField] private BoolVariable _isWalking;
        [SerializeField] private bool _isWalkingBool;
        
        public Animator Animator;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            canWalk.boolValue = true;
            _isWalking.boolValue = false;
            _isWalkingBool = false;
        }

        private void FixedUpdate()
        {
            if (canWalk.boolValue)
            {
                PlayerMove();
                PlayerFaceDirection();
            }
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
        
        
        void Update()
        {
            if(inputDirection.x == 0 && inputDirection.y == 0)
            {
                _isWalking.boolValue = false;
                _isWalkingBool = false;
            }
            else
            {
                _isWalking.boolValue = true;
                _isWalkingBool = true;
            }

            //Animator components
           if (inputDirection.y <= 0)
       {
      Animator.SetBool("isWalking", false);
      }

         if (inputDirection.x >=0)
       {
       Animator.SetBool("isWalking", false);
       }


       if (inputDirection.x >=1)
       {
       Animator.SetBool("isWalking", true);
       }

       if (inputDirection.x <= -0.5)
       {
       Animator.SetBool("isWalking", true);
       }



       if (inputDirection.y >= 1)
       {
       Animator.SetBool("isWalking", true);
       }

       if (inputDirection.y <= -0.5)
      { 
       Animator.SetBool("isWalking" , true);
      }
      }
    }
}
