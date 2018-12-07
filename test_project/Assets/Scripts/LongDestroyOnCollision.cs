﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDestroyOnCollision : MonoBehaviour {

	public Sprite CollectEffect;
	
	private void OnTriggerEnter(Collider other)

	{
		print("Check");
		
		if (other.tag == "PickUp")
		
			Destroy(gameObject);
		print("Destroy");
	
		if (gameObject.tag == "PickUp" && CollectEffect != null)
		{

			gameObject.GetComponent<SpriteRenderer>().sprite = CollectEffect;
			var newZ = gameObject.transform.position;
			newZ.z = -3.0f;
			gameObject.transform.position = newZ;
			StartCoroutine("RemoveSprite");
		}
	}
	IEnumerator RemoveSprite () {
		yield return new WaitForSeconds(2.0f);
		Destroy(gameObject);
	}
}
