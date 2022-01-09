using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour
{

	UnityEngine.AI.NavMeshAgent agent;
	public GameObject waypoints;
	// List or Array of points- starts at number 0
	Transform[] points;
	public int destPoint = 0;
	public bool random;

	// Use this for initialization
	void Start()
	{
		points = waypoints.GetComponentsInChildren<Transform>();
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//Can turn off autobraking to not stop between waypoints
		agent.autoBraking = false;
		GotoNextPoint();
	}

	void GotoNextPoint()
	{
		
		if (points.Length == 0)
		{
			return;
		}
		if (random)
		{
			int rand = Random.Range(0, points.Length);
			agent.SetDestination(points[rand].position);
		}
        else
        {
			agent.SetDestination(points[destPoint].position);
			//if goes higher than the total number of waypoints -> go back to start of array
			destPoint = (destPoint + 1) % points.Length;
		}

		
	}

	// Update is called once per frame
	void Update()
	{
		if (agent.remainingDistance < 0.5f)
		{
			if((Random.Range(0f,1f)*100)>60)
            {
				StartCoroutine("WaitAndMove");
            }
            else
            {
				GotoNextPoint();
			}
			
		}
	}

	IEnumerator WaitAndMove()
    {
		yield return new WaitForSeconds(5);
		GotoNextPoint();
    }


}
