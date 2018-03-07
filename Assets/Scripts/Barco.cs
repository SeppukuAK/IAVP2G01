using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Barco : MonoBehaviour {

	GameManager.Pos _pos;
	GameManager.ColorBarco _colorBarco;
	Sprite _spriteBarco, _spriteBarcoSeleccionado;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void ConstruyeBarco(GameManager.Pos pos, Sprite spriteBarco, Sprite spriteBarcoSeleccionado, GameManager.ColorBarco colorbarco)
	{

		_pos = pos;
		_spriteBarco = spriteBarco;
		_spriteBarcoSeleccionado = spriteBarcoSeleccionado;
		_colorBarco = colorbarco;

		SpriteRenderer renderer = gameObject.AddComponent<SpriteRenderer>();
		renderer.sprite = _spriteBarco;
		renderer.sortingOrder = 1;
		gameObject.AddComponent<BoxCollider2D>();

	}

	private void OnMouseDown()
	{
		//Caso en el que no hay nada seleccionado
		if (GameManager.instance.getSeleccionado () == GameManager.Seleccion.vacio) {
			
			SpriteRenderer render = GetComponent<SpriteRenderer> ();

			render.sprite = _spriteBarcoSeleccionado;

			GameManager.instance.SetSeleccionado (_colorBarco);
		}

	}
				

}
