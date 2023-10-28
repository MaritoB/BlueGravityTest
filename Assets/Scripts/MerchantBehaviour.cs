
using BlueGravityTest;
using UnityEngine;

public interface ITrader
{
    void StartTrade(InventoryManager aPlayerInventory);
}
public class MerchantBehaviour : MonoBehaviour, ITrader, IInteractable
{
    [SerializeField]GameObject mInteractionImage;
    [SerializeField] InventoryManager merchantInventory, playerInventory;
    [SerializeField] Item[] itemsToSell;
    public void HideInteractions()
    {
        mInteractionImage.SetActive(false);
        merchantInventory.ToggleInventoryOff();
        if(playerInventory != null)
        {
            playerInventory.ToggleInventoryOff();
        }
    }

    private void Start()
    {
        foreach (var item in itemsToSell)
        {
            if (item != null)
            {
                if(merchantInventory != null)
                {
                    merchantInventory.Add(item);
                }
            }
        }
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
        merchantInventory.ListItemsToBuy();
        merchantInventory.ToggleInventoryOnToBuy();
        playerInventory.ToggleInventoryOnToSell();
        playerInventory.SetCustomer(merchantInventory);
        merchantInventory.SetCustomer(playerInventory);
    }
}
