using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public enum Tile { agua,aguaProfunda,muro};

    //Origen
    public struct Pos
    {
        int x;
        int y;
    }

    Tile[,] _tablero;

    const float _distancia = 0.64f;

    public GameObject _agua;
    public GameObject _aguaProfunda;
    public GameObject _muro;

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

        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                switch (_tablero[i, j])
                {
                    case Tile.agua:
                        Instantiate(_agua, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        break;

                    case Tile.aguaProfunda:
                        Instantiate(_aguaProfunda, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        break;

                    case Tile.muro:
                        Instantiate(_muro, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        break;


                }

            }

        }

    }

    public void CasillaPulsada(GameObject go)
    {
        go.transform.position

    }

	// Update is called once per frame
	void Update () {
		
	}
}
