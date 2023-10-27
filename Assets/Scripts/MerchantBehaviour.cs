
using BlueGravityTest;
using UnityEngine;

public class MerchantBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField]GameObject mInteractionImage;
    [SerializeField]InventoryManager merchantInventory;
    [SerializeField] Item[] itemsToSell;
    public void HideInteractions()
    {
        mInteractionImage.SetActive(false);
        merchantInventory.ToggleInventoryOff();
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
        Debug.Log("Trade");
        merchantInventory.ToggleInventoryOn();
    }

    public void ShowInteractions()
    {
        mInteractionImage.SetActive(true);
    }
}
