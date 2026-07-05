using UnityEngine;

namespace Relentless.Inventory.Items
{
    [System.Serializable]
    public class DropSettings
    {
        [field: Header("Global Physics")]
        [field: Tooltip("How fast the object lose its speed due to friction. The higher the friction, the faster" +
            "the stop")]
        [field: SerializeField] public float Friction { get; set; } = 5f;
        [field: Tooltip("The speed the item must have for the slide to be counted as complete")]
        [field: SerializeField] public float StopThreshold { get; set; } = 0.05f;

        [field: Header("Slide Distance")]
        [field: Tooltip("Min distance, that an item will slide on the ground")]
        [field: SerializeField] public float MinDistance { get; set; } = 2f;
        [field: Tooltip("Max distance, that an item will slide on the ground")]
        [field: SerializeField] public float MaxDistance { get; set; } = 5f;

        [field: Header("Spawn Angle")]
        [field: Tooltip("Min angle, that an item can be instantiated with")]
        [field: SerializeField] public float MinSpawnAngle { get; set; } = 0f;
        [field: Tooltip("Max angle, that an item can be instantiated with")]
        [field: SerializeField] public float MaxSpawnAngle { get; set; } = 360f;

        [field: Header("Rotation Speed")]
        [field: Tooltip("Min speed of an object's rotation")]
        [field: SerializeField] public float MinRotSpeed { get; set; } = -360f;
        [field: Tooltip("Max speed of an object's rotation")]
        [field: SerializeField] public float MaxRotSpeed { get; set; } = 360f;

        [field: Header("Spawn Distance")]
        [field: Tooltip("How far away from the player the object will be spawned")]
        [field: SerializeField] public float SpawnDistance { get; set; } = 2f;
    }
}