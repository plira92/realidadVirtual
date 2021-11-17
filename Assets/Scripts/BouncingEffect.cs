using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BouncingEffect : MonoBehaviour
{

    public Vector3 velocity = Vector3.zero;
    public float floorHeight = 0.0f;
    public float sleepThreshold = 0.05f;
    public float bounceCooef = 0.8f;
    public float gravity = -9.8f;

    // Use this for initialization
    void Start () {
        
    }
     

    public void FixedUpdate() {


         if (velocity.magnitude > sleepThreshold || transform.position.y > floorHeight) {
             velocity.y += gravity * Time.fixedDeltaTime;
         }

         transform.position = new Vector3(0f, velocity.y * Time.fixedDeltaTime, 0f);

         if (transform.position.y <= floorHeight) {
            transform.position = new Vector3(transform.position.x, floorHeight, transform.position.z);
             //transform.position.y = floorHeight;
             velocity.y = -velocity.y;
             velocity *= bounceCooef;
         }
     }
}