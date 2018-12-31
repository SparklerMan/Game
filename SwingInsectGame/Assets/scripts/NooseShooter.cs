using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NooseShooter : MonoBehaviour {

	public GameObject nooseShooter;

	private SpringJoint2D rope;
	public int maxFrameCount;
	private int FrameCount;

	public LineRenderer lineRenderer;

	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			Fire ();
		}
	}

	void LateUpdate () {

		if (rope != null) {
			lineRenderer.enabled = true;
			lineRenderer.positionCount = 2;
			lineRenderer.SetPosition (0, nooseShooter.transform.position);
			lineRenderer.SetPosition (1, rope.connectedAnchor);
		}
		else
		{
			lineRenderer.enabled = false;
		}	
	}

	void FixedUpdate()
	{
		if (rope != null) 
		{
			FrameCount++;

			if (FrameCount > maxFrameCount) {
				GameObject.DestroyImmediate (rope);
				FrameCount = 0;
			}
		}
	}

	void Fire ()
	{
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 position = nooseShooter.transform.position;
		Vector3 direction = mousePosition - position;

		RaycastHit2D hit = Physics2D.Raycast (position,direction, Mathf.Infinity);

		if (hit.collider != null)
		{

			SpringJoint2D newRope = nooseShooter.AddComponent<SpringJoint2D> ();
			newRope.enableCollision = false;
			newRope.frequency = .2f;
			newRope.connectedAnchor = hit.point;
			newRope.enabled = true;

			GameObject.DestroyImmediate (rope);
			rope = newRope;
			FrameCount = 0;
		}
	}
}
