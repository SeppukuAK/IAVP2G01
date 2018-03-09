using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LogicaBarco
{
    TipoBarco _tipoBarco;
    Pos _pos;

    public LogicaBarco()
    {
        _pos = new Pos(0, 0);
        _tipoBarco = TipoBarco.ninguno;
    }

    public LogicaBarco(TipoBarco tipoBarco, Pos pos)
    {
        _tipoBarco = tipoBarco;
        _pos = pos;
    }

    public TipoBarco GetTipoBarco() { return _tipoBarco; }
    public void SetTipoBarco(TipoBarco tipoBarco) { _tipoBarco = tipoBarco; }

    public Pos GetPos() { return _pos; }
}

