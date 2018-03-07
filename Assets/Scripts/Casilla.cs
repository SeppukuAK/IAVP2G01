using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Casilla : MonoBehaviour {

    GameManager.Tile _tile;
    GameManager.Pos _pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConstruyeCasilla(GameManager.Tile tile, GameManager.Pos pos)
    {
        _tile = tile;
        _pos = pos;
    }

    private void OnMouseDown()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();

        switch (_tile)
        {
            case GameManager.Tile.agua:
                _tile = GameManager.Tile.aguaProfunda;
                render.sprite = GameManager.instance.spriteAguaProfunda;

                break;

            case GameManager.Tile.aguaProfunda:
                _tile = GameManager.Tile.muro;
                render.sprite = GameManager.instance.spriteMuro;
                break;

            case GameManager.Tile.muro:
                _tile = GameManager.Tile.agua;
                render.sprite = GameManager.instance.spriteAgua;
                break;


        }
    }
}
