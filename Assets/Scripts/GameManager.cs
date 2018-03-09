using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    Tablero _tablero;

    const float _distancia = 0.64f;

    //--------ATRIBUTOS--------

    public GameObject aguaPrefab;
    public GameObject aguaProfundaPrefab;
    public GameObject muroPrefab;


    [HideInInspector]
    public Sprite spriteAgua;

    [HideInInspector]
    public Sprite spriteAguaProfunda;

    [HideInInspector]
    public Sprite spriteMuro;

    //--------ATRIBUTOS--------



    // Use this for initialization
    void Start ()
    {
        instance = this;

        InicializaSprites();

        _tablero = new Tablero();
        colocaTablero();
	}  

	// Update is called once per frame
	void Update () {
		
	}

    void InicializaSprites()
    {
        spriteAgua = aguaPrefab.GetComponent<SpriteRenderer>().sprite;
        spriteAguaProfunda = aguaProfundaPrefab.GetComponent<SpriteRenderer>().sprite;
        spriteMuro = muroPrefab.GetComponent<SpriteRenderer>().sprite;

    }


    //Pasa la representación lógica del tablero (matriz) a la representación física (gameobjects)
    void colocaTablero()
    {
        GameObject GOTablero = new GameObject("Tablero");

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Pos posAux = new Pos(x,y);
                Tile tileAux = _tablero.GetTile(x, y);

                switch (tileAux.GetTerreno())
                {
                    case Terreno.agua:
                        GameObject aguaAux = Instantiate(aguaPrefab, new Vector3(x * _distancia, -y * _distancia, 0), Quaternion.identity, GOTablero.transform);

                        aguaAux.AddComponent<Casilla>().ConstruyeCasilla(tileAux);
                        break;

                    case Terreno.aguaProfunda:
                        GameObject aguaProfundaAux = Instantiate(aguaProfundaPrefab, new Vector3(x * _distancia, -y * _distancia, 0), Quaternion.identity, GOTablero.transform);
                        aguaProfundaAux.GetComponent<Casilla>().ConstruyeCasilla(tileAux);

                        break;

                    case Terreno.muro:
                        GameObject muroAux = Instantiate(muroPrefab, new Vector3(x * _distancia, -y * _distancia, 0), Quaternion.identity, GOTablero.transform);
                        muroAux.GetComponent<Casilla>().ConstruyeCasilla(tileAux);

                        break;
                }

            }

        }

    }
}
