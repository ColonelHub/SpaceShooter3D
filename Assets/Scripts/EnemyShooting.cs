using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float minTimebetweenShots;
    public float maxTimebetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shoot()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }

    IEnumerator ShootRoutine()
    {
        while(true){

            yield return new WaitForSeconds(Random.Range(minTimebetweenShots, maxTimebetweenShots));
            Shoot();
        
        }
    }
}
