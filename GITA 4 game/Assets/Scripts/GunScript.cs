using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
	public GameObject bulletPrefab;
	private float bulletSpeed = 50.0f;
	

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
			// Code to shoot the gun goes here
			Quaternion playerRotation = transform.rotation;
			Quaternion bulletRotation = Quaternion.Euler(0f, playerRotation.eulerAngles.y, 90f);
			
			GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.2f, 0), bulletRotation);
			bullet.GetComponent<Rigidbody>().velocity = transform.right * bulletSpeed;
		}

    }
}
