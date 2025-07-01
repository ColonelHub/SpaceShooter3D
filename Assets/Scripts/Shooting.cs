using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePos;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown(0) && canShot)
        {
            Shoot();
        }
    }


    void Shoot()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        StartCoroutine(ShootDelay());
    }
    IEnumerator ShootDelay()
    {
        canShot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShot = true; 
    }
}
