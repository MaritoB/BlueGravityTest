namespace BlueGravityTest
{
    using UnityEngine;

    public class PlayerOutfitManager : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer HoodRenderer, TorsoRenderer, PelvisRenderer, ShoulderRRenderer, ShoulderLRenderer,
                                        ElbowRRenderer, ElbowLRenderer, WristRRenderer, WristLRenderer,
                                        LegRRenderer, LegLRenderer, BootRRenderer, BootLRenderer;
        public void EquipItem(Item aItem)
        {
            if (aItem == null)
            {
                return;
            }
            switch (aItem.itemType)
            {
                case ItemType.HOOD:
                    HoodRenderer.sprite = aItem.icon;
                    break;
                case ItemType.TORSO:
                    TorsoRenderer.sprite = aItem.icon;
                    break;
                case ItemType.PELVIS:
                    PelvisRenderer.sprite = aItem.icon;
                    break;
                case ItemType.SHOULDER_R:
                    ShoulderRRenderer.sprite = aItem.icon;
                    break;
                case ItemType.SHOULDER_L:
                    ShoulderLRenderer.sprite = aItem.icon;
                    break;
                case ItemType.ELBOW_R:
                    ElbowRRenderer.sprite = aItem.icon;
                    break;
                case ItemType.ELBOW_L:
                    ElbowLRenderer.sprite = aItem.icon;
                    break;
                case ItemType.WRIST_R:
                    WristRRenderer.sprite = aItem.icon;
                    break;
                case ItemType.WRIST_L:
                    WristLRenderer.sprite = aItem.icon;
                    break;
                case ItemType.LEG_R:
                    LegRRenderer.sprite = aItem.icon;
                    break;
                case ItemType.LEG_L:
                    LegLRenderer.sprite = aItem.icon;
                    break;
                case ItemType.BOOT_R:
                    BootRRenderer.sprite = aItem.icon;
                    break;
                case ItemType.BOOT_L:
                    BootLRenderer.sprite = aItem.icon;
                    break;
            }
        }
    }

}