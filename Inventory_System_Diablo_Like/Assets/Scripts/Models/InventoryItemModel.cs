using UnityEngine;

namespace Assets.Scripts.Models
{
    [CreateAssetMenu(menuName = "Inventory/Item", fileName = "Item Model")]
    public class InventoryItemModel : ScriptableObject
    {
        #region Editor

        [SerializeField]
        private Sprite _preview;

        [SerializeField]
        private string _name;

        [SerializeField]
        private int _parameter;

        [SerializeField]
        private int _cost;

        [SerializeField]
        private ItemType _type;

        #endregion

        #region Properties

        public Sprite Preview => _preview;
        public string Name => _name;
        public int Parameter => _parameter;
        public int Cost => _cost;
        public ItemType Type => _type;

        #endregion
    }
}
