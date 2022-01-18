using Player;
using UnityEngine;

namespace InputSystem
{
    public class InputSystem : MonoBehaviour
    {
        private PlayerInputs playerInputs;
        private PlayerMovement playerMovement;
        private void Awake()
        {
            playerInputs = new PlayerInputs();
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnEnable()
        {
            playerInputs.Player.Enable();

            playerInputs.Player.Movement.performed += 
                ctx => playerMovement.inputDirection = 
                    ctx.ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            playerInputs.Player.Disable();
        }
    }
}
