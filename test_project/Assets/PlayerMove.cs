﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

		Animator anim;
		public float smooth = 1f;
		public float speed = 6.0F;
		public float jumpSpeed = 8.0F;
		public float gravity = 20.0F;
		private Quaternion lookLeft;
		private Quaternion lookRight;
		private Vector3 moveDirection = Vector3.zero;

		void Start(){
			Cursor.visible = false;
			//anim = GetComponent();
			Time.timeScale = 1;

			lookRight = transform.rotation;
			lookLeft = lookRight * Quaternion.Euler(0, 180, 0); 
		}

		void Update() 
		{
			//controller = GetComponent<CharacterController>();
			CharacterController controller = GetComponent<CharacterController>();
			if (controller.isGrounded) {

				//anim.SetBool ("IsRunning", false);

				moveDirection = new Vector3(-(Input.GetAxis("Vertical")), 0, Input.GetAxis("Horizontal"));

				if (Input.GetButton("Jump"))
					moveDirection.y = jumpSpeed;

				if (Input.GetKey(KeyCode.A)){

					transform.rotation = lookLeft;
					moveDirection = transform.TransformDirection(-moveDirection);
					moveDirection *= speed;

					anim.SetBool ("IsRunning", true);

				}

				if (Input.GetKey(KeyCode.D)){
					transform.rotation = lookRight;
					moveDirection = transform.TransformDirection(moveDirection);
					moveDirection *= speed;
					anim.SetBool ("IsRunning", true);
				}
			
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}
	}