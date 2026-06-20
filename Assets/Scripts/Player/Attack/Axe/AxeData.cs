using UnityEngine;
using Relentless.Player.Attack.Base;

namespace Relentless.Player.Attack.Axe
{
    public class AxeData : WeaponData
    {
        [SerializeField] private float _maxSwingAngle = 45f;
        
        public float MaxSwingAngle { get => _maxSwingAngle; }
    }
}
