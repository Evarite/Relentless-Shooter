using UnityEngine;
using Relentless.Player.Weapons.Base;

namespace Relentless.Player.Weapons.Axe
{
    [CreateAssetMenu(fileName = "New Axe", menuName = "Relentless/Weapons/Axe Data")]
    public class AxeData : WeaponData
    {
        [Header("Axe")]
        [Tooltip("The angle of axe's swing")]
        [SerializeField] private float _maxSwingAngle = 45f;
        
        public float MaxSwingAngle { get => _maxSwingAngle; }
    }
}
