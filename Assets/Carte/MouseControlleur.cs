using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlleur : MonoBehaviour
{
   
	public float verticalSpeed = 50;

	public void Update()
	{
		if (Input.GetMouseButton(0))
		{
			float verticalOffset = verticalSpeed * -Input.GetAxis("Mouse Y") * Time.deltaTime;

			transform.Translate(0, verticalOffset, 0);
		}
	}
}

