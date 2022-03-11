﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	//private Vector3 motion;
	public Transform target;
	float speed = 1;
	Vector3[] path;
	int targetIndex;
	float timer = 0;
	float waitTime = 1f;
	bool isDeclared = false;

	void Start()
	{
		Debug.Log(target.position);
		//target = GameObject.Find("pc").transform;
		//Vector3 sourceToDestination = target.position - transform.position;
		//motion = sourceToDestination.normalized * speed;
		PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
	}

	//void Update()
	//{
	/*
		timer += Time.deltaTime;
		if (timer > waitTime && !isDeclared)
		{
			target = GameObject.Find("pc").transform;
			Debug.Log(target.position);
			PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
			isDeclared = true;
		}*/
		//target = GameObject.Find("pc").transform;
		//transform.position += motion * Time.deltaTime;
	//}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
	{
		if (pathSuccessful)
		{
			path = newPath;
			targetIndex = 0;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath()
	{
		Vector3 currentWaypoint = path[0];
		while (true)
		{
			if (transform.position == currentWaypoint)
			{
				targetIndex++;
				if (targetIndex >= path.Length)
				{
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
			yield return null;

		}
	}

	public void OnDrawGizmos()
	{
		if (path != null)
		{
			for (int i = targetIndex; i < path.Length; i++)
			{
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex)
				{
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else
				{
					Gizmos.DrawLine(path[i - 1], path[i]);
				}
			}
		}
	}
}
