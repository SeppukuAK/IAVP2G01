using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;



public class Barco : MonoBehaviour {

    LogicaBarco _logicaBarco;

    Sprite _spriteBarco;
    Sprite _spriteBarcoSeleccionado;


	GameObject _flecha;

	Stopwatch _reloj;
	AEstrella A;

    // Use this for initialization
    void Start()
    {
		_flecha.SetActive (false);
		_reloj = new Stopwatch ();
    }

	public void ConstruyeBarco(LogicaBarco logicaBarco, Sprite spriteBarco, Sprite spriteBarcoSeleccionado,GameObject flecha)
    {
        _logicaBarco = logicaBarco;
        _spriteBarco = spriteBarco;
        _spriteBarcoSeleccionado = spriteBarcoSeleccionado;
		_flecha = flecha;

       GetComponent<SpriteRenderer>().sprite = _spriteBarco;
    }

    private void OnMouseDown()
    {
		if (GameManager.instance.GetSeleccionado() == ColorUnidad.ninguno && _logicaBarco.GetFlecha() == _logicaBarco.GetPos())
        {
            SpriteRenderer render = GetComponent<SpriteRenderer>();
            render.sprite = _spriteBarcoSeleccionado;

			GameManager.instance.SetSeleccionado(_logicaBarco.GetTipoBarco(),this.gameObject);
        }

    }

	public void SetSpriteDeseleccionado()
	{
		GetComponent<SpriteRenderer>().sprite = _spriteBarco;
	}

    public LogicaBarco GetLogicaBarco()
    {
        return _logicaBarco;
    }


	public void EmpiezaMovimiento(Pos pos)
	{
		_logicaBarco.SetFlecha(new Pos(pos.GetX(),pos.GetY()));

		_flecha.transform.position = new Vector3(pos.GetX() * GameManager.Distancia, -pos.GetY() * GameManager.Distancia, 0);

		_flecha.SetActive (true);

		GameManager.instance.SetSeleccionado(ColorUnidad.ninguno, null);

		SetSpriteDeseleccionado ();

		_reloj.Reset ();

		_reloj.Start ();



		AEstrella A = new AEstrella (GameManager.instance.GetLogicaTablero().GetMatriz(), _logicaBarco.GetPos(), pos);


		_reloj.Stop ();
		GameManager.instance.escribeTiempo (_reloj.ElapsedMilliseconds.ToString());

		MueveBarco (A.GetCamino ());


	}



    public void MueveBarco(Stack<Pos> camino)
    {
		if (camino != null)
			StartCoroutine ("AvanzaUnPaso", camino);
		else
			QuitaFlecha ();
    }

	IEnumerator AvanzaUnPaso(Stack<Pos> camino)
	{
		while (camino.Count > 0 && GameManager.instance.GetLogicaTablero().GetLogicaTile(camino.First()).GetTerreno() != Terreno.muro)
		{
			Pos newPos = camino.Pop ();

			_logicaBarco.SetPos (newPos);

			this.gameObject.transform.position = new Vector3 (newPos.GetX () * GameManager.Distancia, -newPos.GetY () * GameManager.Distancia, 0);

			if (GameManager.instance.GetLogicaTablero ().GetLogicaTile (newPos).GetTerreno () == Terreno.agua)
				yield return new WaitForSeconds (0.2f);
			else
				yield return new WaitForSeconds (0.4f);
			
		}
			
		QuitaFlecha ();

	}

	void QuitaFlecha()
	{
		_logicaBarco.SetFlecha (_logicaBarco.GetPos());
		_flecha.SetActive (false);
		_flecha.transform.position = new Vector3(_logicaBarco.GetPos().GetX() * GameManager.Distancia, -_logicaBarco.GetPos().GetY() * GameManager.Distancia, 0);
	}
}
