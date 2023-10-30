
namespace BlueGravityTest
{
    using UnityEngine;
    public class PlayerInputs : MonoBehaviour
    {
        private Vector2 movementInputs = Vector2.zero;
        private bool sprintInput = false;
        void Update()
        {
            movementInputs.x = Input.GetAxis("Horizontal");
            movementInputs.y = Input.GetAxis("Vertical");
            sprintInput = Input.GetKey(KeyCode.LeftShift);
        }
        public Vector2 GetInputMovement() { return movementInputs; }
        public bool GetInputSprint() { return sprintInput; }
    }
}