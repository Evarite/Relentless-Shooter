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
                int count = Random.Range(enemyData.MinDropCount, enemyData.MaxDropCount);
                ItemDropManager.SpawnDroppedItem(droppedItem.Prefab, count);
                Debug.Log($"Spawned: {droppedItem.Name}, {count}");
            }
        }
    }
}