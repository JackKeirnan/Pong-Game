using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject shootSFX;

    public Transform target; 
    public Transform weaponMuzzle; 
    public GameObject bullet; 
    public float fireRate = 3000f; 
    public float shootingPower; 
 
 
    private float shootingTime; 
 
    private void Update()
    {
        Fire(); 
    }
 
    private void Fire()
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1000; 
            GameObject projectile = Instantiate(bullet, weaponMuzzle.transform.position, Quaternion.identity); 
            Vector3 direction = new Vector3(1, 0, 0);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * shootingPower * Time.deltaTime;
            Instantiate(shootSFX, transform.position, transform.rotation);

        }
    }
 
}
