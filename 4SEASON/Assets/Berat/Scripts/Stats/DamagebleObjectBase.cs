using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stat
{
    public enum Collidable{ 
        Enemy,
        Ally
    }
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] private Collider _collider;
        public int InstanceId { get; private set; }
        [SerializeField]
        private float Health = 100;
        [SerializeField]
        private float damage = 5;
        public Collidable collidable;
        private float firstHealth;
        protected virtual void Awake()
        {
            InstanceId = _collider.GetInstanceID();
            this.InitializeDamageble();
            firstHealth = Health;
        }
        protected virtual void Destroy() {
            this.DestroyDamageble();
        }
        public virtual void Damage()
        {
            if (collidable == Collidable.Enemy) {
                Health -= damage;
                Debug.Log("Damage amount : " + damage + " Current Health : " + Health);
                if (Health <= 0)
                {
                    //particle oynat 
                    //this.gameObject.SetActive(false);
                    //böceði öldür.
                    Destroy(gameObject);
                }
            }
            else {
                Health += damage;
                if (Health >= firstHealth)
                    Health = firstHealth;
                Debug.Log("Heal amount : " + damage + " Current Health : " + Health);
                //fidaný iyileþtir
            }
        }
    }
}