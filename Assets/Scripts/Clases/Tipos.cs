using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//--------TIPOS---------
public enum Terreno { agua, aguaProfunda, muro, vacio };

//Origen
public class Pos
{
    public Pos(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public int GetX() { return _x; }
    public int GetY() { return _y; }

    public void SetX(int x) { _x = x; }
    public void SetY(int y) { _y = y; }


    int _x;
    int _y;
}

//--------TIPOS---------
