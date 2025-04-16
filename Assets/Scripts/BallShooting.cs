using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
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
	bool canShoot = true;
	CinemachineCamera vcam;
	float camVelocity;
	Transform camFollow;
	public bool isDead = false;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		vcam = FindFirstObjectByType<CinemachineCamera>();
		vcam.Follow = transform;
		gameManager = FindFirstObjectByType<GameManager>();
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
		if (Input.touchCount == 0)
		{
			canShoot = true;
		}


		if (Input.touchCount == 1 && canShoot)
		{
			touch = Input.GetTouch(0);
			touchPos = Camera.main.ScreenToWorldPoint(touch.position);

			switch (touch.phase)
			{
				case TouchPhase.Began:
					startPos = touchPos;
					break;
				case TouchPhase.Ended:
					lineRenderer.enabled = false;
					dir = startPos - touchPos;
					if (dir.magnitude > 0.3 && isIdle()) Shoot(dir);
					break;
			}


			if (isIdle())
			{
				Vector2 ballPos2 = new Vector2(transform.position.x, transform.position.y);
				lineRenderer.enabled = true;
				lineRenderer.SetPosition(1, ballPos2 + startPos - touchPos);
				lineRenderer.SetPosition(0, ballPos2);
			}
		}
		if (Input.touchCount == 2)
		{
			canShoot = false;
			touch = Input.GetTouch(1);
			if (touch.phase == TouchPhase.Began)
			{
				startPos = touch.position;
			}

			Level level = FindFirstObjectByType<Level>();
			Vector2 basePos = level.transform.position;
			Vector2 camPos = basePos + (startPos - touch.position) / 30;
			Debug.Log(basePos);
			camFollow.position = camPos;

			vcam.Follow = camFollow;
			vcam.Lens.OrthographicSize = Mathf.SmoothDamp(vcam.Lens.OrthographicSize, camSize * 2, ref camVelocity, 0.2f);
		}
		else
		{
			vcam.Follow = transform;
			vcam.Lens.OrthographicSize = Mathf.SmoothDamp(vcam.Lens.OrthographicSize, camSize, ref camVelocity, 0.2f);
		}

	}
	bool isIdle()
	{
		if (rb.linearVelocity.x < stopSpeed
		&& rb.linearVelocity.x > -stopSpeed
		&& rb.linearVelocity.y < stopSpeed
		&& rb.linearVelocity.y > -stopSpeed
		&& vcam.Lens.OrthographicSize < camSize + 1
		&& vcam.Lens.OrthographicSize > camSize - 1) return true;
		else return false;
	}

	void Shoot(Vector2 dir)
	{
		rb.AddForce(dir * force, ForceMode2D.Impulse);
		gameManager.shoots++;
		wasShoot = true;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Dead"))
		{
			gameManager.Die();
			isDead = true;
		}
	}
}
