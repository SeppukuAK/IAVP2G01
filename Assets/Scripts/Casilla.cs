using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Casilla : MonoBehaviour {

    Tile _tile;
    Pos _pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConstruyeCasilla(Tile tile, Pos pos)
    {
        _tile = tile;
        _pos = pos;
    }

    private void OnMouseDown()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();

        switch (_tile)
        {
            case Tile.agua:
                _tile = Tile.aguaProfunda;
                render.sprite = GameManager.instance.spriteAguaProfunda;

                break;

            case Tile.aguaProfunda:
                _tile = Tile.muro;
                render.sprite = GameManager.instance.spriteMuro;
                break;

            case Tile.muro:
                _tile = Tile.agua;
                render.sprite = GameManager.instance.spriteAgua;
                break;


        }
    }
}
