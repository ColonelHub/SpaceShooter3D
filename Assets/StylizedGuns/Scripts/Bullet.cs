using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Outside
{
    public class Bullet : MonoBehaviour
    {
        public GameObject explotion;
        GameObject lastExplotion;
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                return;
            }
            lastExplotion = Instantiate(explotion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(lastExplotion, 1f);
        }



    }

}
