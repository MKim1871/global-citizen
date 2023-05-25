using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
	public GameObject robotPrefab;
	
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] robots = new GameObject[10];
		float botX;
		float botZ;
		
		for (int i = 0; i < 10; i++)
		{
			botX = Random.Range(-30, 30);
			botZ = Random.Range(0, 50);
			
			GameObject robot = Instantiate(robotPrefab, new Vector3(botX, 0f, botZ), Quaternion.identity);

			// Add robot to array
			robots[i] = robot;
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
