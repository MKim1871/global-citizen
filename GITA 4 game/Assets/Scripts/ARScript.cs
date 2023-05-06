using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARScript : MonoBehaviour
{
	public GameObject bulletPrefab;
	
	private float bulletSpeed = 30.0f;
	private float recoilSpeed = 0.1f;
	private float fireTime = 0.0f;
	private bool isScoped;
	private Vector3 startingPosition;
	

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
		fireTime += Time.deltaTime;
		
		if (Input.GetButton("Fire2") && !isScoped) {
			transform.localPosition = Vector3.Lerp(transform.localPosition, startingPosition + new Vector3(-0.3f, -0f, -0.3f), Time.deltaTime * 10f);

			if (transform.localPosition == startingPosition + new Vector3(-0.6f, -0f, -0.6f))
			{
				isScoped = true;
			}
		}
		
        if (Input.GetButton("Fire1") && fireTime >= 0.1f) {
			// Code to shoot
			Quaternion playerRotation = transform.rotation;
			Quaternion bulletRotation = Quaternion.Euler(playerRotation.eulerAngles.x, playerRotation.eulerAngles.y, playerRotation.eulerAngles.z);
			
			//Generates and shoots bullet
			GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0.3f, -0f, 0), bulletRotation);
			bullet.GetComponent<Rigidbody>().velocity = transform.up * -1 * bulletSpeed;
			
			//Code for recoil
			transform.localPosition += new Vector3(0, 0, -recoilSpeed);
			
			fireTime = 0.0f;
		}
		
		if (!isScoped)
		{
			//Restores to original position
			transform.localPosition = Vector3.Lerp(transform.localPosition, startingPosition, Time.deltaTime * 10f);

			isScoped = false;
		}
		
    }
}
