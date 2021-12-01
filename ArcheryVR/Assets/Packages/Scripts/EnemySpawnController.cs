using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour
{
	[SerializeField]
	private GameObject enemy;//enemy
	[SerializeField]
	private float interval = 5f;//Generation interval is not set to 5 seconds
	private float timeCount = 0;//Timing

	// Use this for initialization
	void Start()
	{
		timeCount = 2f;
	}

	// Update is called once per frame
	void Update()
	{
		// If the countdown ends, a enemy is generated and countdown reset

		if (timeCount > 0)
		{
			timeCount -= Time.deltaTime;
		}
		else
		{
			Instantiate(enemy, this.transform.position, this.transform.rotation);
			timeCount = interval;
		}
	}
}
