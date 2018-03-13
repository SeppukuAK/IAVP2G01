using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Priority_Queue;

public class Nodo
{
    private LogicaTile[,] _tab; //Configuración
    private Nodo _padre;
    private Direccion _operador; //Operador que se aplicó al nodo padre para generar este nodo hijo
    private int _coste; //Coste de la ruta: Desde la raíz hasta aquí

    public Nodo(LogicaTile[,] tab, Nodo padre, Direccion operador, int coste)
    {
        _tab = new LogicaTile[10, 10];
        IgualarTablero(ref _tab, tab);
        _padre = padre;
        _operador = operador;
        _coste = coste;

    }

    //Getters para obtener el tablero, el coste, el padre del nodo y el operador

    public LogicaTile[,] getTablero()
    {
        return _tab;
    }

    public int getCoste()
    {
        return _coste;
    }

    public Nodo getPadre()
    {
        return _padre;
    }

    public Direccion getOperador()
    {
        return _operador;
    }
    static void IgualarTablero(ref LogicaTile[,] tab, LogicaTile[,] tab2)
    {
        //Coordenada y
        for (int i = 0; i < 3; i++)
        {
            //Coordenada x
            for (int j = 0; j < 3; j++)
            {
                tab[i, j] = tab2[i, j];
            }
        }
    }

}


public class AEstrella
{
    public AEstrella()
    {

    }

}

