using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    Tablero _tablero;
    TipoBarco _seleccionado;

    const float _distancia = 0.64f;

    //--------ATRIBUTOS--------

    public GameObject tilePrefab;
    public GameObject barcoPrefab;

    public Sprite spriteAgua;
    public Sprite spriteAguaProfunda;
    public Sprite spriteMuro;

    public Sprite spriteBarcoAzul;
    public Sprite spriteBarcoAzulSeleccionado;

    public Sprite spriteBarcoRojo;
    public Sprite spriteBarcoRojoSeleccionado;

    public Sprite spriteBarcoVerde;
    public Sprite spriteBarcoVerdeSeleccionado;

    //--------ATRIBUTOS--------



    // Use this for initialization
    void Start()
    {
        instance = this;

        _tablero = new Tablero();
        colocaTablero();

        _seleccionado = TipoBarco.ninguno;
        ConstruyeUnidades();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //Pasa la representación lógica del tablero (matriz) a la representación física (gameobjects)
    void colocaTablero()
    {
        GameObject GOTablero = new GameObject("Tablero");

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                //Creamos gameObject
                GameObject GOTileAux = Instantiate(tilePrefab, new Vector3(x * _distancia, -y * _distancia, 0), Quaternion.identity, GOTablero.transform);

                Tile tileAux = _tablero.GetTile(x, y);

                //SpriteRenderer
                switch (tileAux.GetTerreno())
                {
                    case Terreno.agua:
                        GOTileAux.GetComponent<SpriteRenderer>().sprite = spriteAgua;
                        break;

                    case Terreno.aguaProfunda:
                        GOTileAux.GetComponent<SpriteRenderer>().sprite = spriteAguaProfunda;
                        break;

                    case Terreno.muro:
                        GOTileAux.GetComponent<SpriteRenderer>().sprite = spriteMuro;
                        break;
                }

                //Casilla
                GOTileAux.GetComponent<Casilla>().ConstruyeCasilla(tileAux);
            }

        }

    }

    void ConstruyeUnidades()
    {
        //Azul
        Pos posAzul = new Pos(0, 0);
        GameObject barcoAzul = Instantiate(barcoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        barcoAzul.name = "BarcoAzul";


        LogicaBarco logicaBarcoAzul = new LogicaBarco(TipoBarco.azul, posAzul);

        barcoAzul.GetComponent<Barco>().ConstruyeBarco(logicaBarcoAzul,spriteBarcoAzul,spriteBarcoAzulSeleccionado);
    }



    public TipoBarco GetSeleccionado() { return _seleccionado; }

    public void SetSeleccionado(TipoBarco colBarco)
    {
        _seleccionado = colBarco;
    }
}
