
namespace BlueGravityTest
{
    using UnityEngine;
    using System.Collections;
    public interface ITrader
    {
        void StartTrade(InventoryManager aPlayerInventory);
    }
    public class MerchantBehaviour : MonoBehaviour, ITrader, IInteractable
    {
        [SerializeField] GameObject mInteractionImage;
        [SerializeField] InventoryManager merchantInventory, playerInventory;
        [SerializeField] ItemData[] itemsToSell;
        public void HideInteractions()
        {
            mInteractionImage.SetActive(false);
            merchantInventory.ToggleInventoryOff();
            if (playerInventory != null)
            {
                playerInventory.ToggleInventoryOff();
            }
        }
        IEnumerator AddItemToShop()
        {
            yield return new WaitForSeconds(2f);
            foreach (var item in itemsToSell)
            {
                if (item != null)
                {
                    if (merchantInventory != null)
                    {
                        merchantInventory.Add(item);
                    }
                }
            }
            merchantInventory.ListItemControllers();
            merchantInventory.SetOnClickBuy();
        }
        private void Start()
        {
            StartCoroutine(AddItemToShop());
        }
        public void Interact()
        {
            merchantInventory.ToggleInventoryOnToBuy();
        }
        public void ShowInteractions()
        {
            mInteractionImage.SetActive(true);
        }
        public void StartTrade(InventoryManager aPlayerInventory)
        {
            playerInventory = aPlayerInventory;
            merchantInventory.ToggleInventoryOnToBuy();
            playerInventory.ToggleInventoryOnToSell();
            playerInventory.SetCustomer(merchantInventory);
            merchantInventory.SetCustomer(playerInventory);
        }
    }
}
