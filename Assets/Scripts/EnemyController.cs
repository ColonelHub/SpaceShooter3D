using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * moveSpeed*Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            moveSpeed *= -1;
            moveSpeed=moveSpeed*=-1
        }
    }
}
