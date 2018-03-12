using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour {

	LogicaTile _logicaTile;

	// Use this for initialization
	void Start () {
	}
	
	public void ConstruyeCasilla(LogicaTile logicaTile)
    {
		_logicaTile = logicaTile;
    }

    private void OnMouseDown()
    {
		if (GameManager.instance.GetSeleccionado () == TipoBarco.ninguno) {
			SpriteRenderer render = GetComponent<SpriteRenderer> ();

			switch (_logicaTile.GetTerreno ()) {
			case Terreno.agua:
				_logicaTile.SetTerreno (Terreno.aguaProfunda);
				render.sprite = GameManager.instance.spriteAguaProfunda;

				break;

			case Terreno.aguaProfunda:
				_logicaTile.SetTerreno (Terreno.muro);
				render.sprite = GameManager.instance.spriteMuro;
				break;

			case Terreno.muro:
				_logicaTile.SetTerreno (Terreno.agua);
				render.sprite = GameManager.instance.spriteAgua;
				break;

			}
		} 
		else if (_logicaTile.GetTerreno () == Terreno.muro) {
			
			GameManager.instance.DeseleccionaBarco ();
			GameManager.instance.SetSeleccionado (TipoBarco.ninguno, null);
		} 

		//Mover
		else 
		{

		}
			
    }
}
