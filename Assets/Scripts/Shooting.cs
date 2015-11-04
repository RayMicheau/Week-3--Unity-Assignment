﻿using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public float speed = 10;
    public Rigidbody projectile;
    public Vector3 bulletCount;
    public Light flashlight;

    void Awake() {
        flashlight.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlickLights();
        }
    }

    void FlickLights() {
            if (!flashlight.enabled)
            {
                flashlight.enabled = true;
            }
            else if (flashlight.enabled)
            {
                flashlight.enabled = false;
            }
    }
    
    void Shoot() {
        Rigidbody instantiateProj = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
        instantiateProj.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        Debug.Log("Pew!");
        Destroy(instantiateProj.gameObject, 1.0f);
    }
}
