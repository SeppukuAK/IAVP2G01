using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Casilla : MonoBehaviour {

    Tile _tile;

	// Use this for initialization
	void Start () {
	}
	
    public void ConstruyeCasilla(Tile tile)
    {
        _tile = tile;
    }

    private void OnMouseDown()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();

        switch (_tile.GetTerreno())
        {
            case Terreno.agua:
                _tile.SetTerreno(Terreno.aguaProfunda);
                render.sprite = GameManager.instance.spriteAguaProfunda;

                break;

            case Terreno.aguaProfunda:
                _tile.SetTerreno(Terreno.muro);
                render.sprite = GameManager.instance.spriteMuro;
                break;

            case Terreno.muro:
                _tile.SetTerreno(Terreno.agua);
                render.sprite = GameManager.instance.spriteAgua;
                break;

        }
    }
}
