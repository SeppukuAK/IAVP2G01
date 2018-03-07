using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public enum Tile { agua,aguaProfunda,muro};

    //Origen
    public struct Pos
    {
        public int x;
        public int y;
    }

    Tile[,] _tablero;

    const float _distancia = 0.64f;

    public Sprite _spriteAgua;
    public Sprite _spriteAguaProfunda;
    public Sprite _spriteMuro;

    // Use this for initialization
    void Start () {
        instance = this;

        _tablero = new Tile[10, 10];

        //i son filas
        for(int i = 0; i < 10;i++)
        {
            for(int j = 0; j < 10; j++)
            {
                int random = UnityEngine.Random.Range(0, 10);

                //Mar
                if (random <= 7)
                    _tablero[i, j] = Tile.agua;
               
                //Mar profundo
                else if (random == 8)
                    _tablero[i, j] = Tile.aguaProfunda;

                //Muro
                else
                    _tablero[i, j] = Tile.muro;
            }

        }

        colocaTablero();

	}
	
    //Pasa la representación lógica del tablero (matriz) a la representación física (gameobjects)
    void colocaTablero()
    {
        GameObject tableroContenedor = GameObject.FindWithTag("Tablero");

        //Creamos los prefabs de cada tile

        //Agua
        GameObject agua = new GameObject("Agua");
        SpriteRenderer renderAgua = agua.AddComponent<SpriteRenderer>();
        renderAgua.sprite = _spriteAgua;
        agua.AddComponent<Casilla>();
        agua.AddComponent<BoxCollider2D>();

        //Agua profunda
        GameObject aguaProfunda = new GameObject("AguaProfunda");
        SpriteRenderer renderAguaProfunda = aguaProfunda.AddComponent<SpriteRenderer>();
        renderAguaProfunda.sprite = _spriteAguaProfunda;
        aguaProfunda.AddComponent<Casilla>();
        aguaProfunda.AddComponent<BoxCollider2D>();

        //Muro
        GameObject muro = new GameObject("Muro");
        SpriteRenderer renderMuro = muro.AddComponent<SpriteRenderer>();
        renderMuro.sprite = _spriteMuro;
        muro.AddComponent<Casilla>();
        muro.AddComponent<BoxCollider2D>();


        for (int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                Pos posAux;
                posAux.x = j;
                posAux.y = i;

                switch (_tablero[i, j])
                {
                    case Tile.agua:
                        GameObject aguaAux = Instantiate(agua, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        aguaAux.GetComponent<Casilla>().ConstruyeCasilla(Tile.agua, posAux);
                        break;

                    case Tile.aguaProfunda:
                        GameObject aguaProfundaAux = Instantiate(aguaProfunda, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        aguaProfundaAux.GetComponent<Casilla>().ConstruyeCasilla(Tile.aguaProfunda, posAux);

                        break;

                    case Tile.muro:
                        GameObject muroAux =  Instantiate(muro, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        muroAux.GetComponent<Casilla>().ConstruyeCasilla(Tile.muro, posAux);

                        break;


                }

            }

        }

    }

    public void CasillaPulsada(GameObject go)
    {
        Casilla casilla = go.GetComponent<Casilla>();
        SpriteRenderer render = go.GetComponent<SpriteRenderer>();


        switch (casilla.GetTile())
        {
            case Tile.agua:
                casilla.SetTile(Tile.aguaProfunda);
                render.sprite = _spriteAguaProfunda;

                break;

            case Tile.aguaProfunda:
                casilla.SetTile(Tile.muro);
                render.sprite = _spriteMuro;
                break;

            case Tile.muro:
                casilla.SetTile(Tile.agua);
                render.sprite = _spriteAgua;
                break;


        }


    }

	// Update is called once per frame
	void Update () {
		
	}
}
