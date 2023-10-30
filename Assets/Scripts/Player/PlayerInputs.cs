
namespace BlueGravityTest
{
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerInputs : MonoBehaviour
    {
        private Vector2 movementInputs = Vector2.zero;
        private bool sprintInput = false;
        private bool interact = false;

        void Update()
        {
            movementInputs.x = Input.GetAxis("Horizontal");
            movementInputs.y = Input.GetAxis("Vertical");
            sprintInput = Input.GetKey(KeyCode.LeftShift);
            interact = Input.GetKeyDown(KeyCode.F);
        }
        public Vector2 GetInputMovement() { return movementInputs; }
        public bool GetInputSprint() { return sprintInput; }
        public bool GetInputInteract() { return interact; }
    }
}