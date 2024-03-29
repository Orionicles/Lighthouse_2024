using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinigameSeagull : MinigameActor
{
	private AudioSource audioSource;
	private Image image;

	public Sprite aliveSprite;
	public Sprite deadSprite;
	public AudioClip hitSound;
	public AudioClip deadSound;
	public int health;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		image = GetComponent<Image>();
	}

	public override void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("collision");
		if (other.name == "Rock" && health > 0)
		{
			health -= 1;

			audioSource.clip = hitSound;
			audioSource.Play();

			Debug.Log("collision triggered by: " + other.name);

			if (health <= 0)
			{
				audioSource.clip = deadSound;
				audioSource.Play();
				image.sprite = deadSprite;
				
			}
		}
	}
}
