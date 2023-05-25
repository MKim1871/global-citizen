using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject robotPrefab;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 distanceFromPlayer = playerPrefab.transform.position - transform.localPosition;
		float angleComparedToPlayer = Vector3.Angle(transform.forward, distanceFromPlayer);
		
		if (angleComparedToPlayer < 90f * 0.5f && distanceFromPlayer.magnitude < 10f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(distanceFromPlayer), 10f * Time.deltaTime);
			
	        transform.Translate(Vector3.forward * Time.deltaTime);
		}	
		
    }
}
