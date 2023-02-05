using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Stat;
using UnityEngine.ParticleSystemJobs;

namespace PlayerShooting
{
    public class ShootingManager : MonoBehaviour
    {
        [SerializeField] private Transform shootingPosition;
        [SerializeField] private float fireRate = 10f;
        private float nextTimeToFire;
        [SerializeField] private LineRenderer laserLine;
        [SerializeField] private float gunRange = 50f;
        [SerializeField] private float laserDuration = 3f;
       



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                PlayParticle();
            }
        }

        void PlayParticle() {
            var particle = ObjectPooler.Instance.GetPooledObject("WaterParticle");
            particle.transform.position = shootingPosition.position;
            particle.transform.rotation = shootingPosition.rotation;
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Play();
        }
        void Shoot()
        {
            laserLine.SetPosition(0, shootingPosition.position);
            RaycastHit hit;
            bool rayHit = Physics.Raycast(shootingPosition.position, shootingPosition.forward, out hit, gunRange);
            Debug.DrawLine(shootingPosition.position, shootingPosition.position + shootingPosition.forward * 10, Color.blue, 100);
            Debug.DrawRay(shootingPosition.position, shootingPosition.forward, Color.red, 8);
            if (rayHit)
            {
                laserLine.SetPosition(1, hit.point);
                Debug.Log(hit.collider.name);
                int colliderInstanceId = hit.collider.GetInstanceID();
                if (DamagebleHelper.DamagebleList.ContainsKey(colliderInstanceId))
                {
                    DamagebleHelper.DamagebleList[colliderInstanceId].Damage();
                }
            }
            else {
                laserLine.SetPosition(1, shootingPosition.position+(shootingPosition.forward * gunRange));
            }
            StartCoroutine(ShootLaser());

        }
        IEnumerator ShootLaser() {
            laserLine.enabled = true;
            yield return new WaitForSeconds(laserDuration);
            laserLine.enabled = false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(shootingPosition.position, .15f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(shootingPosition.position, shootingPosition.position + shootingPosition.forward * 10);
        }
    }
}