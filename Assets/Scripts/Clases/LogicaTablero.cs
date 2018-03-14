using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LogicaTablero {

    LogicaTile [,] _matriz;

	public LogicaTablero()
    {
		_matriz = new LogicaTile[10, 10];
        Random rnd = new Random();

        //i son filas
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                int random = rnd.Next(0, 10);
                //Mar
                if (random <= 7)
					_matriz[y, x] = new LogicaTile(Terreno.agua,new Pos(x,y));

                //Mar profundo
                else if (random == 8)
					_matriz[y, x] = new LogicaTile(Terreno.aguaProfunda, new Pos(x, y));

                //Muro
                else
					_matriz[y, x] = new LogicaTile(Terreno.muro, new Pos(x, y));
            }

        }

    }

	public LogicaTile GetLogicaTile(int x, int y) { return _matriz[y,x]; }
	public LogicaTile GetLogicaTile(Pos pos) { return _matriz[pos.GetY(), pos.GetX()]; }
	public LogicaTile[,] GetMatriz() { return _matriz; }


}
