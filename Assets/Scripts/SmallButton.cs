using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallButton : MonoBehaviour
{
	[SerializeField] Doors doors;
	private void Update()
	{
		if (GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Ball")))
		{
			doors.StartCoroutine(doors.Open());
			StartCoroutine(Click());
		}
	}

	IEnumerator Click(float duration = 0.25f)
	{
		Vector2 startPos = transform.position;
		Vector2 endPos = new Vector2(transform.position.x, transform.position.y - transform.lossyScale.y);
		Vector2 startScale = transform.localScale;
		Vector2 endScale = new Vector2(transform.localScale.x, 0);
		float progress = 0;
		while (progress < duration)
		{
			transform.localScale = Vector2.Lerp(startScale, endScale, progress / duration);
			transform.position = Vector2.Lerp(startPos, endPos, progress / duration);
			progress += Time.deltaTime;
			yield return null;
		}
	}
}
