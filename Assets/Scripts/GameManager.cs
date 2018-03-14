using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public const int Ancho = 10;
    public const int Alto = 10;
    public const int WorldSize = 100;

    LogicaTablero _logicaTablero;
    ColorUnidad _seleccionado;

    public const float Distancia = 0.64f;

    //--------ATRIBUTOS--------

    public GameObject tilePrefab;
    public GameObject barcoPrefab;
	public GameObject flechaPrefab;

    public Sprite spriteAgua;
    public Sprite spriteAguaProfunda;
    public Sprite spriteMuro;

    public Sprite spriteBarcoAzul;
    public Sprite spriteBarcoAzulSeleccionado;

    public Sprite spriteBarcoRojo;
    public Sprite spriteBarcoRojoSeleccionado;

    public Sprite spriteBarcoVerde;
    public Sprite spriteBarcoVerdeSeleccionado;

	public Sprite spriteFlechaRoja;
	public Sprite spriteFlechaAzul;
	public Sprite spriteFlechaVerde;

    //--------ATRIBUTOS--------

	GameObject _barcoSeleccionado;



    // Use this for initialization
    void Start()
    {
        instance = this;
		_barcoSeleccionado = null;

		_logicaTablero = new LogicaTablero();
        colocaTablero();

        _seleccionado = ColorUnidad.ninguno;
        ConstruyeUnidades();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //---------------CONSTRUCCIÓN TILES------------------------

    //Pasa la representación lógica del tablero (matriz) a la representación física (gameobjects)
    void colocaTablero()
    {
        GameObject GOTablero = new GameObject("Tablero");

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                //Creamos gameObject
                GameObject GOTileAux = Instantiate(tilePrefab, new Vector3(x * Distancia, -y * Distancia, 0), Quaternion.identity, GOTablero.transform);

				LogicaTile tileAux = _logicaTablero.GetLogicaTile(x, y);

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
				GOTileAux.GetComponent<Tile>().ConstruyeCasilla(tileAux);
            }

        }

    }

    //---------------CONSTRUCCIÓN TILES------------------------


    //---------------CONSTRUCCIÓN UNIDADES------------------------

    void ConstruyeUnidades()
    {
        Pos [] posBarcos = new Pos[3];

        for (int i = 0; i < 3; i++)
			posBarcos[i] = new Pos(-1,-1);
        
		CreaBarco("BarcoRojo", ColorUnidad.rojo, spriteBarcoRojo, spriteBarcoRojoSeleccionado,spriteFlechaRoja,ref posBarcos);
		CreaBarco("BarcoAzul", ColorUnidad.azul, spriteBarcoAzul, spriteBarcoAzulSeleccionado, spriteFlechaAzul,ref posBarcos);
		CreaBarco("BarcoVerde", ColorUnidad.verde, spriteBarcoVerde, spriteBarcoVerdeSeleccionado,spriteFlechaVerde,ref posBarcos);
    }

	void CreaBarco(string nombre, ColorUnidad tipoBarco, Sprite spriteBarco, Sprite spriteBarcoSeleccionado, Sprite spriteFlecha, ref Pos []posBarcos)
    {
		Pos posAux = new Pos(Random.Range(0, 10), Random.Range(0, 10));

        bool hayBarco = HayBarco(posAux,posBarcos);

		while (_logicaTablero.GetLogicaTile(posAux).GetTerreno() == Terreno.muro || hayBarco)
        {
			posAux = new Pos(Random.Range(0, 10), Random.Range(0, 10));
            hayBarco = HayBarco(posAux, posBarcos);

        }

		posBarcos [(int)tipoBarco] = posAux;
        GameObject barco = Instantiate(barcoPrefab, new Vector3(posAux.GetX() * Distancia, -posAux.GetY()*Distancia, 0), Quaternion.identity);
        barco.name = nombre;

        LogicaBarco logicaBarco = new LogicaBarco(tipoBarco, posAux);

		//Construcción de flecha
		GameObject flecha = Instantiate(flechaPrefab, new Vector3(posAux.GetX() * Distancia, -posAux.GetY()*Distancia, 0), Quaternion.identity);
		flecha.GetComponent<SpriteRenderer>().sprite = spriteFlecha;

        barco.GetComponent<Barco>().ConstruyeBarco(logicaBarco, spriteBarco, spriteBarcoSeleccionado,flecha);
    }
    //Comprueba si hay barco en una posición
    bool HayBarco(Pos pos, Pos[] posBarcos)
    {
        bool hayBarco = false;

        int i = 0;
        while (!hayBarco && i < 3)
        {
            //Comprobamos si la posicion del barco a colocar coincide con la de un barco ya colocado
            if (posBarcos[i] == pos)
                hayBarco = true;
            i++;
        }
        return hayBarco;
    }

    //---------------CONSTRUCCIÓN UNIDADES------------------------


    public ColorUnidad GetSeleccionado() { return _seleccionado; }

	public void SetSeleccionado(ColorUnidad colBarco, GameObject barco)
    {
        _seleccionado = colBarco;
		_barcoSeleccionado = barco;

    }
		
    public void MoverBarco(Pos pos)
    {
		_barcoSeleccionado.GetComponent<Barco> ().EmpiezaMovimiento(pos);
    }
		
	public LogicaTablero GetLogicaTablero()
	{
		return _logicaTablero;
	}

	public void DeseleccionaBarco()
	{
		_barcoSeleccionado.GetComponent<Barco> ().SetSpriteDeseleccionado ();
		SetSeleccionado(ColorUnidad.ninguno, null);
	}

}
