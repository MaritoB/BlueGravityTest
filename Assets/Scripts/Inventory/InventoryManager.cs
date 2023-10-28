
namespace BlueGravityTest
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using UnityEngine.Events;

    public class InventoryManager : MonoBehaviour
    {
        List<ItemController> Items;
        Dictionary<Item, ItemController> InventoryItemsDictionary;
        [SerializeField] Transform ItemContent;
        [SerializeField] PlayerOutfitManager outfitManager;
        [SerializeField] GameObject InventoryItem;
        [SerializeField] GameObject InventoryCanvas;
        [SerializeField] GameObject InventoryCamera;
        [SerializeField] TextMeshProUGUI GoldAmountText;
        [SerializeField] int goldAmount;
        InventoryManager customerInventory;

        private void Awake()
        {
            Items = new List<ItemController>();
            InventoryItemsDictionary = new Dictionary<Item, ItemController>();
        }
        public void SetCustomer(InventoryManager aCustomer)
        {
            customerInventory = aCustomer;
        }
        public void EquipItem(Item aItem)
        {
            outfitManager.EquipItem(aItem);
        }
        public void UpdateGold()
        {
            GoldAmountText.text = goldAmount.ToString();
        }
        public void ToggleInventoryOnToBuy()
        {
            ListItemsToBuy();
            InventoryCanvas.SetActive(true);
            InventoryCamera.SetActive(true);
        }
        public void ToggleInventoryOnToEquip()
        {
            ListItemsToEquip();
            InventoryCanvas.SetActive(true);
            InventoryCamera.SetActive(true);
        }
        public void ToggleInventoryOnToSell()
        {
            UpdateGold();
            ListItemsToSell();
            InventoryCanvas.SetActive(true);
            InventoryCamera.SetActive(true);
        }
        public void ToggleInventoryOff()
        {
            InventoryCanvas.SetActive(false);
            InventoryCamera.SetActive(false);
        }
        public void SelectItemController(Item aItem)
        {
            outfitManager.EquipItem(aItem);

        }
        public void SellItem(Item aItem)
        {
            if (aItem == null)
            {
                return;
            }
            goldAmount += aItem.goldPrice;
            UpdateGold();
            Remove(aItem);
            customerInventory.Add(aItem);
            customerInventory.ListItemsToBuy();
            ListItemsToSell(); 
        }
        public void TryToBuy(Item aItem)
        {
            if (aItem == null)
            {
                return;
            }
            if (aItem.goldPrice <= customerInventory.goldAmount)
            {
                customerInventory.goldAmount -= aItem.goldPrice;
                customerInventory.UpdateGold() ;
                Remove(aItem);
                customerInventory.Add(aItem);
                ListItemsToBuy();
                customerInventory.ListItemsToSell();
                
            }
            else
            {
                Debug.Log("Need More Gold to Buy");
            }
        }
        public void Add(Item item)
        {
            if (InventoryItemsDictionary.TryGetValue(item, out ItemController value))
            {
                value.addToStack();
            }
            else
            {
                ItemController newItem = new ItemController(item);
                Items.Add(newItem);
                InventoryItemsDictionary.Add(item, newItem);
            }
        }
        public void Remove(Item item)
        {
            if (InventoryItemsDictionary.TryGetValue(item, out ItemController value))
            {
                value.RemoveFromStack();
                if (value.GetStackSize() == 0)
                {
                    Items.Remove(value);
                    InventoryItemsDictionary.Remove(item);
                }
            }
        }
        public void ListItemsToEquip()
        {
            foreach (Transform item in ItemContent)
            {
                Destroy(item.gameObject);
            }
            foreach (var item in InventoryItemsDictionary)
            {
                //mejorable con object pool de InventoryItem
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var unitPrice = obj.transform.Find("UnitPrice").GetComponent<TextMeshProUGUI>();
                var itemQuantity = obj.transform.Find("ItemQuantity").GetComponent<TextMeshProUGUI>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                obj.GetComponent<Button>().onClick.AddListener(delegate { outfitManager.EquipItem(item.Key);  });
                itemQuantity.text = item.Value.GetStackSize().ToString();
                unitPrice.text = item.Key.goldPrice.ToString();
                itemIcon.sprite = item.Key.icon;
            }
        }
        public void ListItemsToSell()
        {
            foreach (Transform item in ItemContent)
            {
                Destroy(item.gameObject);
            }
            foreach (var item in InventoryItemsDictionary)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var unitPrice = obj.transform.Find("UnitPrice").GetComponent<TextMeshProUGUI>();
                var itemQuantity = obj.transform.Find("ItemQuantity").GetComponent<TextMeshProUGUI>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                obj.GetComponent<Button>().onClick.AddListener(delegate { SellItem(item.Key); });
                itemQuantity.text = item.Value.GetStackSize().ToString();
                unitPrice.text = item.Key.goldPrice.ToString();
                itemIcon.sprite = item.Key.icon;
            }
        }
        public void ListItemsToBuy()
        {
            foreach (Transform item in ItemContent)
            {
                Destroy(item.gameObject);
            }
            foreach (var item in InventoryItemsDictionary)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var unitPrice = obj.transform.Find("UnitPrice").GetComponent<TextMeshProUGUI>();
                var itemQuantity = obj.transform.Find("ItemQuantity").GetComponent<TextMeshProUGUI>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                obj.GetComponent<Button>().onClick.AddListener(delegate { TryToBuy(item.Key); });
                itemQuantity.text = item.Value.GetStackSize().ToString();
                unitPrice.text = item.Key.goldPrice.ToString();
                itemIcon.sprite = item.Key.icon;
            }
        }
    }
}
