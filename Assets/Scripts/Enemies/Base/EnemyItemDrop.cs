using Relentless.Enemies.Base.Data;
using Relentless.Items;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    public static class EnemyItemDrop
    {
        public static void SpawnItem(EnemyData enemyData)
        {
            for (int i = 0; i < enemyData.DropIterations; i++)
            {
                var droppedItem = enemyData.PossibleDrops.GetRandomItem();
                if (droppedItem != null)
                    SpawnUniqueItem(droppedItem);
            }
        }

        public static void SpawnUniqueItem(DroppedItemData droppedItem)
        {
            int count = Random.Range(droppedItem.MinDropCount, droppedItem.MaxDropCount);
            ItemDropManager.SpawnDroppedItem(droppedItem.Item.Prefab, count);
        }
    }
}