﻿//Codigo de animacion de Thomas Tews. Jugador.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThomasMovementController : MonoBehaviour {


	private InputHandler inputHandler;
	public Animator anim;

	public static ThomasMovementController Instance {get; private set;}
	

	//1° Declarar un Singleton Acá -- Y ponerle el animator publico y estatico. 

	private	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		inputHandler = new InputHandler();
		anim = this.GetComponent<Animator>();
	}

	private void Update()
	{
		if (inputHandler.HandleInput() != null)
		{
			Command cmd = inputHandler.HandleInput(); // Me devuelve que commando se va a ejecutar
			cmd.Execute(this.gameObject,anim); //Ejecuta el comando especifico,aca podria ir cualquier cosa, siempre y cuando matchee con algun comando. 
		}	
	}


	void OnTriggerStay(Collider other)
	{
		if(Input.GetKey(KeyCode.E))
		{
			Debug.Log(other.gameObject);
			if (other.gameObject.CompareTag("PickUp"))
			{
				Debug.Log("Entre Aca");	
				ThomasMovementController.Instance.anim.SetTrigger("isTakingObj");
				other.gameObject.SetActive(false);
			}
		}
	}

}

