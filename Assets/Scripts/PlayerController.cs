using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
	public float speed;
	public float sensitivity;
	public float acceleration;
    private Rigidbody rb;
	private int count;
    private float velocity;
	public float maxSpeed;
	public string cena;
	public int maxRotation;
	public int minRotation;
	private float moveVertical;
	//private float horizontal;

//	private Vector3 mov;

	// Use this for initialization
	void Start () {
        rb = GetComponent <Rigidbody>();	
		count = 0;
        velocity = 50.0f;
		rb.velocity = transform.forward * velocity;
    }

	void FixedUpdate()
	{
		//mov = new Vector3 (Input.acceleration.x * sensitivity, Input.acceleration.z * sensitivity, rb.velocity.z);
		
		if (rb.velocity.z < maxSpeed) {
			rb.AddForce (Vector3.forward * speed);
		}
			
		Vector3 moviment = new Vector3(Input.GetAxis("Horizontal") * sensitivity, sensitivity * moveVertical, rb.velocity.z);// movimentacao personagem PC
		//rb.velocity = moviment;
		rb.velocity = moviment;

	
	}

    void Update()
	{
		//rb.velocity = (mov * speed);
		//horizontal = Input.GetAxis ("Horizontal"); //Movimentação da particula
		moveVertical = Input.GetAxis ("Vertical");
	}
		
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			velocity = 20f;
	
			Vector3 force = rb.velocity.normalized * velocity;
			rb.AddForce(force, ForceMode.VelocityChange);    
			other.gameObject.SetActive (false);
			count = count + 1;
		
			GetComponent<Rigidbody>().AddForce(transform.forward * 100);﻿
		}
		if (other.gameObject.CompareTag ("devagar"))
		{
			velocity = -2000f;

//			Vector3 force = rb.velocity.normalized * velocity;

			Debug.Log ("entrou");
		}
	
		

		if (other.gameObject.CompareTag ("devagar")) {
			
			Debug.Log ("SAIU");
//			Vector3 force = rb.velocity.normalized * speed;


		}
			
		if(other.tag=="FIM"){
			  SceneManager.LoadScene("Jogo2");
			 
			}
        if (other.tag == "FIM2")
        {
            SceneManager.LoadScene("Jogo3");

        }
		if (other.tag == "FIM3")
		{
			SceneManager.LoadScene("Win");

		}
    }

	void OnCollisionEnter(Collision col)
	{
        //    Vector3 collisionForce = col.impulse / Time.fixedDeltaTime;
        // And now you can use it for your calculations!
        if (col.gameObject.tag == "Obstaculos") 
		{ 
			Energia.health -= 50f;
			if (Energia.health == 0f) 
			{
				SceneManager.LoadScene("GameOver"); 
			}

		}

        if (col.gameObject.tag == "acelera")
		{

			Debug.Log("correr");
			rb.velocity = col.gameObject.transform.forward * velocity; // Com velocity é na hora da colisão
			// rb.AddForce(col.gameObject.transform.forward * velocity); // Com AddForece fica uma aceleração uniformimente variada
			//  rb.AddForce(velocity, 0,0, ForceMode.Impulse);

		}
		if (col.gameObject.tag == "desacelera")
		{
			velocity = 500f;
			//rb.velocity = - col.gameObject.transform.forward * velocity; // Com velocity é na hora da colisão
			rb.AddForce(col.gameObject.transform.forward * -velocity); // Com AddForece fica uma aceleração uniformimente variada
		}

		if (col.gameObject.tag == "parede")
		{
			//rb.velocity = Vector3.zero;
			//speed = 0;
			//rb.velocity = -transform.forward * velocity; // Com velocity é na hora da colisão
			//rb.AddForce(-transform.forward * speed); // Com AddForece fica uma aceleração uniformimente variada
		}
	}

	}

	

