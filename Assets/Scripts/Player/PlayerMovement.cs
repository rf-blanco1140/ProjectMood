using Unity.Mathematics;
using UnityEngine;
using MoreMountains.Feedbacks;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody body;
        public Vector2 inputDirection;
        Vector3 previousDirection = Vector3.forward;

        private Vector3 movement;
        private Rigidbody rb;
        private float moveSpeed;

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

            rb = gameObject.GetComponent<Rigidbody>();
            moveSpeed = 2f;
        }

        void Update()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.z = Input.GetAxis("Vertical");

            if (inputDirection.x == 0 && inputDirection.y == 0)
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
        
            if (canWalk.boolValue)
            {
                PlayerMove();
                PlayerFaceDirection();
            }
        }

        private void PlayerMove()
        {
            //Try to fix Rigibody movement

            //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
            //rb.velocity = movement * moveSpeed;
            //Vector3 dPos = movement*moveSpeed*Time.deltaTime;
            //transform.position = new Vector3(transform.position.x+dPos.x,transform.position.y, transform.position.z+dPos.z);

            Vector3 mov;

            float horizontal = 0;
            if (Input.GetKey(KeyCode.A))
                horizontal = -1;
            else if (Input.GetKey(KeyCode.D))
                horizontal = 1;

            float vertical = 0;
            if (Input.GetKey(KeyCode.S))
                vertical = -1f;
            else if (Input.GetKey(KeyCode.W))
                vertical = 1f;

            if (horizontal != 0 && vertical != 0)
            {
                mov = Vector3.right * horizontal + Vector3.forward * vertical;
                transform.position += mov * moveSpeed / 1.5f  * Time.deltaTime;
            }

            else
            {
                mov = Vector3.right * horizontal + Vector3.forward * vertical;
                transform.position += mov * moveSpeed * Time.deltaTime;
            }
        }
        
        private void PlayerFaceDirection()
        {
            if (Input.GetKey(KeyCode.A))
                body.transform.eulerAngles = Vector3.up * -90;
            else if (Input.GetKey(KeyCode.D))
                body.transform.eulerAngles = Vector3.up * 90;

            if (Input.GetKey(KeyCode.S))
                body.transform.eulerAngles = Vector3.up * 180;
            else if (Input.GetKey(KeyCode.W))
                body.transform.eulerAngles = Vector3.zero;
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

    }
}
