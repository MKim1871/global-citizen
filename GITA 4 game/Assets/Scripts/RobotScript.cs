using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject robotPrefab;
	public GameObject pistolBulletPrefab;
	
	private int health = 100;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 distanceFromPlayer = playerPrefab.transform.position - transform.localPosition;
		distanceFromPlayer.y = 0f;
		float angleComparedToPlayer = Vector3.Angle(transform.forward, distanceFromPlayer);

		if (angleComparedToPlayer < 120f * 0.5f && distanceFromPlayer.magnitude > 1.3f && distanceFromPlayer.magnitude < 10f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(distanceFromPlayer), 10f * Time.deltaTime);
			
	        transform.Translate(Vector3.forward * 5f * Time.deltaTime);
		}	

    }
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == pistolBulletPrefab)
        {
			Debug.Log("hit");
			health -= 10;
			
			if (health < 1)
			{
				Destroy(robotPrefab);
			}
        }
	}
}
