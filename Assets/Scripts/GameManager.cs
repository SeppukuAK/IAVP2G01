using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    //--------TIPOS---------
    public enum Tile { agua,aguaProfunda,muro};

    //Origen
    public struct Pos
    {
        public int x;
        public int y;
    }

    //--------TIPOS---------

    //--------ATRIBUTOS--------

    public Sprite spriteAgua;
    public Sprite spriteAguaProfunda;
    public Sprite spriteMuro;

    //--------ATRIBUTOS--------

    // Use this for initialization
    void Start ()
    {
        instance = this;
        gameObject.AddComponent<Tablero>();
	}  

	// Update is called once per frame
	void Update () {
		
	}
}
