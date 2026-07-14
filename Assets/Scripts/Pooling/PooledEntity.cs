using UnityEngine;

namespace Relentless.Pooling
{
    public class PooledEntity : MonoBehaviour
    {
        public PoolManager Pool { private get; set; }

        public void Return()
        {
            Pool.Return(this);
        }
    }
}
