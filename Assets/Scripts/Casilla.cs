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

    private void OnMouseDown()
    {
        GameManager.instance.CasillaPulsada(this.gameObject);

    }
}
