using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outside
{
    public class MoveCamera : MonoBehaviour
    {
        public Transform cameraPosition;
        void Update()
        {
            transform.position = cameraPosition.position;
        }
    }

}