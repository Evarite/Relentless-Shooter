using Relentless.Enemies.Base.Data;
using Relentless.Items;
using UnityEngine;

namespace Relentless.Enemies.Base
{
    public static class EnemyItemDrop
    {
        public static void SpawnItem(EnemyData enemyData)
        {
            var droppedItem = enemyData.PossibleDrops.GetRandomItem();
            if (droppedItem != null)
            {
                int count = Random.Range(droppedItem.MinDropCount, droppedItem.MaxDropCount);
                ItemDropManager.SpawnDroppedItem(droppedItem.Item.Prefab, count);
            }
        }
    }
}