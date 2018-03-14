using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Priority_Queue;



public class Nodo
{
    private Nodo _padre;

    private Pos _pos;

    private int _f; //Coste desde el inicio a este nodo
    private int _g; //Coste desde este nodo al nodo objetivo
    
    //Indice de este nodo en el array de mundo
    private int _valor; //Coste desde este nodo al nodo objetivo

    public Nodo(Nodo padre, Pos pos)
    {
        _padre = padre;
        _pos = pos;
        _valor = pos.GetX() + pos.GetY() * GameManager.Ancho;
        _f = _g = 0;
    }

    public Nodo getPadre()
    {
        return _padre;
    }

}

public class AEstrella
{

    public AEstrella(LogicaTile[,] world, Pos inicio, Pos fin)
    {
        _world = world;
        _posIni = inicio;
        _posFin = fin;

        CalculatePath();
    }

    //Distancia de un punto a otro. Solo direcciones cardinales
    int ManhattanDistance(Pos inicio,Pos fin)
    {
        return (Math.Abs(inicio.GetX() - fin.GetX()) + Math.Abs(inicio.GetY() - fin.GetY()));
    }

    Queue <Pos> Neighbours(int x, int y)
    {
        int N = y - 1;
        int S = y + 1;
        int E = x + 1;
        int W = x - 1;

        Queue<Pos> adyacentes = new Queue<Pos>();

        if (N >= 0 && CanWalkHere(x, N))
            adyacentes.Enqueue(new Pos(x, N));
        if (N >= 0 && CanWalkHere(E, y))
            adyacentes.Enqueue(new Pos(E, y));
        if (N >= 0 && CanWalkHere(x, S))
            adyacentes.Enqueue(new Pos(x, S));
        if (N >= 0 && CanWalkHere(W, y))
            adyacentes.Enqueue(new Pos(W, y));

        return adyacentes;
    }

    bool CanWalkHere(int x, int y)
    {
        return ((int)_world[y, x].GetTerreno() <= maxWalkableTileNum);
    }

    //Hace al A*
    void CalculatePath()
    {
        Nodo nodoIni = new Nodo(null, _posIni);
        Nodo nodoFin = new Nodo(null, _posFin);



    }

    //Empty si no hay camino posible
    public Queue<Direccion> GetCamino()
    {
        return _camino;
    }

    LogicaTile[,] _world;
    Pos _posIni;
    Pos _posFin;

    Queue<Direccion> _camino;

    //Todo superior a este número esta bloqueado
    const int maxWalkableTileNum = 1;

}


