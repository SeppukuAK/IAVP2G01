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

		GameManager.instance.CasillaPulsada (this.gameObject);


    }


    //GETTERS
    public GameManager.Tile GetTile() { return _tile; }

    public void SetTile(GameManager.Tile tile) { _tile = tile; }
}
