using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Doors : MonoBehaviour
{
	[SerializeField] Transform leftDoor;
	[SerializeField] Transform rightDoor;
	public IEnumerator Open(float duration = 0.5f)
	{
		Vector2 leftDoorPosStart = leftDoor.position;
		Vector2 rightDoorPosStart = rightDoor.position;
		Vector2 leftDoorPosEnd = new Vector2(leftDoor.position.x - leftDoor.lossyScale.x / 2, leftDoor.position.y);
		Vector2 rightDoorPosEnd = new Vector2(rightDoor.position.x + rightDoor.lossyScale.x / 2, rightDoor.position.y);

		Vector2 leftDoorScaleStart = leftDoor.localScale;
		Vector2 rightDoorScaleStart = rightDoor.localScale;
		Vector2 leftDoorScaleEnd = new Vector2(0, leftDoor.localScale.y);
		Vector2 rightDoorScaleEnd = new Vector2(0, rightDoor.localScale.y);

		float progress = 0;
		while (progress < duration)
		{
			leftDoor.position = Vector2.Lerp(leftDoorPosStart, leftDoorPosEnd, progress / duration);
			rightDoor.position = Vector2.Lerp(rightDoorPosStart, rightDoorPosEnd, progress / duration);

			leftDoor.localScale = Vector2.Lerp(leftDoorScaleStart, leftDoorScaleEnd, progress / duration);
			rightDoor.localScale = Vector2.Lerp(rightDoorScaleStart, rightDoorScaleEnd, progress / duration);
			progress += Time.deltaTime;
			yield return null;
		}
		leftDoor.position = leftDoorPosEnd;
		leftDoor.localScale = leftDoorScaleEnd;
		rightDoor.position = rightDoorPosEnd;
		rightDoor.localScale = rightDoorScaleEnd;
	}
}
