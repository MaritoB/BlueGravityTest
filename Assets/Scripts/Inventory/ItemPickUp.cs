
namespace BlueGravityTest
{

    using UnityEngine;

    public class ItemPickUp : MonoBehaviour
    {
        [SerializeField] Item mItem;
        SpriteRenderer sprite;
        private void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sprite = mItem.icon;
        }
        void PickUp(InventoryManager inventory)
        {
            inventory.Add(mItem);
            gameObject.SetActive(false);
        }
        private void OnMouseDown()
        {
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("TryPick");
            InventoryManager inventory = collision.GetComponentInChildren<InventoryManager>();
            if (inventory != null) 
            {
                if (mItem != null)
                {
                    PickUp(inventory);
                }
            }

        }
    }
}
