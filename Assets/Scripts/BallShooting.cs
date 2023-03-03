using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BallShooting : MonoBehaviour
{
	LineRenderer lineRenderer;
	GameManager gameManager;
	Touch touch;
	Vector2 touchPos;
	Vector2 startPos;
	Rigidbody2D rb;
	Vector2 dir;
	[SerializeField] float force;
	[SerializeField] float stopSpeed;
	[Header("Camera")]
	[SerializeField] float camSize;
	ParticleSystem particle;
	bool wasShoot = true;
	CinemachineVirtualCamera vcam;
	float camVelocity;
	Transform camFollow;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		vcam = FindObjectOfType<CinemachineVirtualCamera>();
		vcam.Follow = transform;
		gameManager = FindObjectOfType<GameManager>();
		lineRenderer = GetComponent<LineRenderer>();
		particle = GetComponent<ParticleSystem>();
		camFollow = new GameObject(name: "camFollow").GetComponent<Transform>();

	}

	void Update()
	{

		if (wasShoot && isIdle())
		{
			particle.Play();
			wasShoot = false;
		}


		if (Input.touchCount == 1)
		{
			touch = Input.GetTouch(0);
			touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			switch (touch.phase)
			{
				case TouchPhase.Began:
					startPos = touchPos;
					//startPos = transform.TransformVector(startPos);
					break;
				case TouchPhase.Ended:
					lineRenderer.enabled = false;
					dir = startPos - touchPos;
					if (dir.magnitude > 0.3 && isIdle()) Shoot(dir);
					break;
			}


			if (isIdle())
			{
				lineRenderer.enabled = true;
				lineRenderer.SetPosition(1, touchPos);
				lineRenderer.SetPosition(0, startPos);
			}
		}
		if (Input.touchCount == 2)
		{
			touch = Input.GetTouch(1);
			if (touch.phase == TouchPhase.Began)
			{
				startPos = touch.position;
			}

			Level level = FindObjectOfType<Level>();
			Vector2 basePos = level.transform.position;
			Vector2 camPos = basePos + (startPos - touch.position) / 10;
			Debug.Log(basePos);
			camFollow.position = camPos;

			vcam.Follow = camFollow;
			vcam.m_Lens.OrthographicSize = Mathf.SmoothDamp(vcam.m_Lens.OrthographicSize, camSize * 2, ref camVelocity, 0.2f);
		}
		else
		{
			vcam.Follow = transform;
			vcam.m_Lens.OrthographicSize = Mathf.SmoothDamp(vcam.m_Lens.OrthographicSize, camSize, ref camVelocity, 0.2f);
		}

	}
	bool isIdle()
	{
		if (rb.velocity.x < stopSpeed
		&& rb.velocity.x > -stopSpeed
		&& rb.velocity.y < stopSpeed
		&& rb.velocity.y > -stopSpeed
		&& vcam.m_Lens.OrthographicSize < camSize + 1
		&& vcam.m_Lens.OrthographicSize > camSize - 1) return true;
		else return false;
	}

	void Shoot(Vector2 dir)
	{
		rb.AddForce(dir * force, ForceMode2D.Impulse);
		gameManager.shoots++;
		wasShoot = true;
	}
}
