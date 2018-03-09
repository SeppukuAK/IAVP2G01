using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    Tablero _tablero;

    const float _distancia = 0.64f;

    //--------ATRIBUTOS--------

    public Sprite spriteAgua;
    public Sprite spriteAguaProfunda;
    public Sprite spriteMuro;

    //--------ATRIBUTOS--------

    // Use this for initialization
    void Start ()
    {
        instance = this;
        _tablero = new Tablero();
        colocaTablero();
	}  

	// Update is called once per frame
	void Update () {
		
	}


    //Pasa la representación lógica del tablero (matriz) a la representación física (gameobjects)
    void colocaTablero()
    {
        GameObject tableroContenedor = GameObject.FindWithTag("Tablero");

        //Creamos los prefabs de cada tile

        //Agua
        GameObject agua = new GameObject("Agua");
        SpriteRenderer renderAgua = agua.AddComponent<SpriteRenderer>();
        renderAgua.sprite = spriteAgua;
        agua.AddComponent<Casilla>();
        agua.AddComponent<BoxCollider2D>();

        //Agua profunda
        GameObject aguaProfunda = new GameObject("AguaProfunda");
        SpriteRenderer renderAguaProfunda = aguaProfunda.AddComponent<SpriteRenderer>();
        renderAguaProfunda.sprite = spriteAguaProfunda;
        aguaProfunda.AddComponent<Casilla>();
        aguaProfunda.AddComponent<BoxCollider2D>();

        //Muro
        GameObject muro = new GameObject("Muro");
        SpriteRenderer renderMuro = muro.AddComponent<SpriteRenderer>();
        renderMuro.sprite = spriteMuro;
        muro.AddComponent<Casilla>();
        muro.AddComponent<BoxCollider2D>();


        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Pos posAux = new Pos(x,y);

                switch (_tablero.GetTile(x,y).GetTerreno())
                {
                    case Terreno.agua:
                        GameObject aguaAux = GameManager.Instantiate(agua, new Vector3(x * _distancia, -y * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        aguaAux.GetComponent<Casilla>().ConstruyeCasilla(Terreno.agua, posAux);
                        break;

                    case Terreno.aguaProfunda:
                        GameObject aguaProfundaAux = GameManager.Instantiate(aguaProfunda, new Vector3(x * _distancia, -y * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        aguaProfundaAux.GetComponent<Casilla>().ConstruyeCasilla(Terreno.aguaProfunda, posAux);

                        break;

                    case Terreno.muro:
                        GameObject muroAux = GameManager.Instantiate(muro, new Vector3(x * _distancia, -y * _distancia, 0), Quaternion.identity, tableroContenedor.transform);
                        muroAux.GetComponent<Casilla>().ConstruyeCasilla(Terreno.muro, posAux);

                        break;


                }

            }

        }

    }
}
