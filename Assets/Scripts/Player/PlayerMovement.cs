using Unity.Mathematics;
using UnityEngine;
using MoreMountains.Feedbacks;

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
        [SerializeField] private MMFeedbacks _footstepSound;

        //public Animator Animator1, Animator2, Animator3;
        public Animator Animator1, Animator2, Animator3;
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
                //NewMove();
            }
        }

        private void PlayerMove()
        {
            Vector3 rotatedVector = new Vector3(inputDirection.x, 0, inputDirection.y);
            Vector3 velocity = rotatedVector * _movementSpeed;
            body.AddForce(velocity, ForceMode.Force);
        }

        private void NewMove()
        {
            // if inputdirection = 1, input goes from 0-1 * time.fixeddeltatime / float
            // if inputdirection = 0, input stops ? 

            float targetFloat = 5f;
            Vector2 input = default;
            Vector3 inputTarget = new Vector3(input.x,0,input.y) * targetFloat;
            
            
            if (inputDirection.x >= 1f)
            {
                Vector2.MoveTowards(input, inputTarget, Time.fixedDeltaTime);
            }
            
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
        
        public void PlaySound()
        {
            if (canWalk.boolValue == true)
            {
                _footstepSound.PlayFeedbacks();
            }
            else
            {
                return;
            }

        }

        public void StopSound()
        {
            if (canWalk.boolValue == true)
            {
                _footstepSound.PauseFeedbacks();
            }
            else
            {
                return;
            }
            
        }
        void Update()
        {
            if(inputDirection.x == 0 && inputDirection.y == 0)
            {
                StopSound();
                _isWalking.boolValue = false;
                _isWalkingBool = false;
            }
            else
            {
                PlaySound();
                _isWalking.boolValue = true;
                _isWalkingBool = true;
            }

            if (Animator1.gameObject.activeSelf)
                Animator1.SetBool("isWalking", _isWalkingBool);
            if (Animator2.gameObject.activeSelf)
                Animator2.SetBool("isWalking", _isWalkingBool);
            if (Animator3.gameObject.activeSelf)
                Animator3.SetBool("isWalking", _isWalkingBool);

            //Animator components
            // if (inputDirection.y <= 0)
            //{
            //  Animator.SetBool("isWalking", false);
            //}

            // if (inputDirection.x >=0)
            // {
            //Animator.SetBool("isWalking", false);
            //       }


            //     if (inputDirection.x >=1)
            //   {
            // Animator.SetBool("isWalking", true);
            // }

            //if (inputDirection.x <= -0.5)
            //{
            //Animator.SetBool("isWalking", true);
            //}



            //if (inputDirection.y >= 1)
            // {
            // Animator.SetBool("isWalking", true);
            // }

            // if (inputDirection.y <= -0.5)
            //{ 
            // Animator.SetBool("isWalking" , true);
            //}
        }
    }
}
