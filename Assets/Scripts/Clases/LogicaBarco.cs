using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LogicaBarco
{
	ColorUnidad _tipoBarco;
    Pos _pos;
    Pos _flecha;

    public LogicaBarco()
    {
        _pos = new Pos(0, 0);
        _flecha = new Pos(0, 0);
        _tipoBarco = ColorUnidad.ninguno;
    }

	public LogicaBarco(ColorUnidad tipoBarco, Pos pos)
    {
        _tipoBarco = tipoBarco;
        _pos = pos;
        _flecha = new Pos(pos.GetX(),pos.GetY());
    }

	public ColorUnidad GetTipoBarco() { return _tipoBarco; }
	public void SetTipoBarco(ColorUnidad tipoBarco) { _tipoBarco = tipoBarco; }


    public Pos GetPos() { return _pos; }
	public void SetPos(Pos pos) { _pos = pos; }


    public Pos GetFlecha() { return _flecha; }
    public void SetFlecha(Pos flecha) { _flecha = flecha; }

}

