using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stat
{
    public static class DamagebleHelper
    {
        public static Dictionary<int, IDamageble> DamagebleList = new Dictionary<int, IDamageble>();
        public static void InitializeDamageble(this IDamageble damageble)
        {
            DamagebleList.Add(damageble.InstanceId, damageble);
        }
        public static void DestroyDamageble(this IDamageble damageble)
        {
            DamagebleList.Remove(damageble.InstanceId);
        }
    }
    public interface IDamageble
    {

        public int InstanceId { get; }
        public void Damage();


    }
}