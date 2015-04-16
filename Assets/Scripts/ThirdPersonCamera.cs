using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{
	public float distanceAway;			// distance from the back of the craft
	public float distanceUp;			// distance above the craft
	public float smooth;				// how smooth the camera movement is

	public float cameraDegree;			// custom
	public float cameraX;				// custom
	public float cameraY;				// custom
	public float cameraZ;				// custom
	public float cameraZoom;			// custom

	private GameObject hovercraft;		// to store the hovercraft
	private Vector3 targetPosition;		// the position the camera is trying to be in
	
	Transform follow;
	
	void Start(){
		follow = GameObject.FindWithTag ("Player").transform;
		// custom
		if (distanceAway < 0) {
			cameraDegree = 0.0f;
		} else {
			cameraDegree = 180.0f;
		}
	}
	
	void LateUpdate ()
	{
		// setting the target position to be the correct offset from the hovercraft
		targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;

		// custom
		if (Input.GetAxis("Mouse X") > 0.0f) {
			cameraDegree -= 0.1f;
			if (cameraDegree == 0.0f) {
				cameraDegree = 360.0f;
			}
		} else if (Input.GetAxis("Mouse X") < 0.0f) {
			cameraDegree += 0.1f;
			if (cameraDegree == 360.0f) {
				cameraDegree = 0.0f;
			}
		}
		if (Input.GetAxis("Mouse Y") > 0.0f) {
			cameraY -= 0.1f;

		} else if (Input.GetAxis("Mouse Y") < 0.0f) {
			cameraY += 0.1f;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0.0f) {
			if (cameraZoom > -1 * distanceAway) {
				cameraZoom -= 0.1f;
			}
		} else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f) {
			if (cameraZoom <= 0) {
				cameraZoom += 0.1f;
			}
		}
		cameraX = (Mathf.Abs(distanceAway) + cameraZoom) * Mathf.Cos(cameraDegree);
		cameraZ = (Mathf.Abs(distanceAway) + cameraZoom) * Mathf.Sin(cameraDegree);
		targetPosition += Vector3.right * cameraX + Vector3.up * cameraY + follow.forward * (cameraZ + distanceAway);

		// making a smooth transition between it's current position and the position it wants to be in
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		
		// make sure the camera is looking the right way!
		transform.LookAt(follow);
	}
}
