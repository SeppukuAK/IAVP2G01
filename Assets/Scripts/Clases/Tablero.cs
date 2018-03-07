using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour {

    GameManager.Tile [,] _tablero;

    const float _distancia = 0.64f;

    void Start()
    {
        _tablero = new GameManager.Tile[10, 10];

        //i son filas
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int random = UnityEngine.Random.Range(0, 10);

                //Mar
                if (random <= 7)
                    _tablero[i, j] = GameManager.Tile.agua;

                //Mar profundo
                else if (random == 8)
                    _tablero[i, j] = GameManager.Tile.aguaProfunda;

                //Muro
                else
                    _tablero[i, j] = GameManager.Tile.muro;
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
        renderAgua.sprite = GameManager.instance.spriteAgua;
        agua.AddComponent<Casilla>();
        agua.AddComponent<BoxCollider2D>();

        //Agua profunda
        GameObject aguaProfunda = new GameObject("AguaProfunda");
        SpriteRenderer renderAguaProfunda = aguaProfunda.AddComponent<SpriteRenderer>();
        renderAguaProfunda.sprite = GameManager.instance.spriteAguaProfunda;
        aguaProfunda.AddComponent<Casilla>();
        aguaProfunda.AddComponent<BoxCollider2D>();

        //Muro
        GameObject muro = new GameObject("Muro");
        SpriteRenderer renderMuro = muro.AddComponent<SpriteRenderer>();
        renderMuro.sprite = GameManager.instance.spriteMuro;
        muro.AddComponent<Casilla>();
        muro.AddComponent<BoxCollider2D>();


        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameManager.Pos posAux;
                posAux.x = j;
                posAux.y = i;

                switch (_tablero[i, j])
                {
                    case GameManager.Tile.agua:
                        GameObject aguaAux = Instantiate(agua, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        aguaAux.GetComponent<Casilla>().ConstruyeCasilla(GameManager.Tile.agua, posAux);
                        break;

                    case GameManager.Tile.aguaProfunda:
                        GameObject aguaProfundaAux = Instantiate(aguaProfunda, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        aguaProfundaAux.GetComponent<Casilla>().ConstruyeCasilla(GameManager.Tile.aguaProfunda, posAux);

                        break;

                    case GameManager.Tile.muro:
                        GameObject muroAux = Instantiate(muro, new Vector3(j * _distancia, -i * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        muroAux.GetComponent<Casilla>().ConstruyeCasilla(GameManager.Tile.muro, posAux);

                        break;


                }

            }

        }

    }
}
