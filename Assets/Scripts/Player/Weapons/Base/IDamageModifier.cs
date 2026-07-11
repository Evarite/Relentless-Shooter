using System;
using System.Collections.Generic;
using System.Text;

namespace Relentless.Player.Weapons.Base
{
    public interface IDamageModifier
    {
        float CalculateDamage(float baseDamage);
        void OnHit();
        void Reset();
    }
}
