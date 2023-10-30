
namespace BlueGravityTest
{
    using UnityEngine;
    public enum ItemType
    {
        HOOD,
        TORSO,
        PELVIS,
        SHOULDER_R,
        SHOULDER_L,
        ELBOW_R,
        ELBOW_L,
        WRIST_R,
        WRIST_L,
        LEG_R,
        LEG_L,
        BOOT_R,
        BOOT_L
    }

    [CreateAssetMenu(menuName = "Inventory Item Data")]
    public class ItemData : ScriptableObject
    {
        public string id;
        public ItemType itemType;
        public string displayName;
        public Sprite icon;
        public int goldPrice;

    }
}