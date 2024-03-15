using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewDemoScene2
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float speed = 3;


        // Update is called once per frame
        void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(horizontal, vertical, 0) * Time.deltaTime * speed);
        }
    }

}

