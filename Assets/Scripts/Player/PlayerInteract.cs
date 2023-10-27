namespace BlueGravityTest
{

    using UnityEngine;
    

    public class PlayerInteract : MonoBehaviour
    {

        [SerializeField] PlayerInputs mInputs;
        IInteractable interactable;
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (interactable != null && mInputs != null && mInputs.GetInputInteract())
            {
                interactable.Interact();
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            interactable = collision.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.ShowInteractions();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (interactable != null)
            {
                interactable.HideInteractions();
                interactable = null;
            }
        }
    }

}
