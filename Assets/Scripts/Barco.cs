using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Barco : MonoBehaviour {

    LogicaBarco _logicaBarco;

    Sprite _spriteBarco;
    Sprite _spriteBarcoSeleccionado;

	GameObject _flecha;

    // Use this for initialization
    void Start()
    {
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
        if (GameManager.instance.GetSeleccionado() == ColorUnidad.ninguno)
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

		GameManager.instance.SetSeleccionado(ColorUnidad.ninguno, null);

		SetSpriteDeseleccionado ();

		AEstrella A = new AEstrella (GameManager.instance.GetLogicaTablero().GetMatriz(), _logicaBarco.GetPos(), pos);

		MueveBarco (A.GetCamino ());
	}

    public void MueveBarco(Stack<Pos> camino)
    {
		StartCoroutine ("AvanzaUnPaso", camino);
    }

	IEnumerator AvanzaUnPaso(Stack<Pos> camino)
	{
        Pos newPos = camino.Pop();

        _logicaBarco.SetPos (newPos);

		this.gameObject.transform.position = new Vector3 (newPos.GetX ()*GameManager.Distancia , -newPos.GetY ()*GameManager.Distancia, 0);

        if (camino.Count > 0)
        {
            if (GameManager.instance.GetLogicaTablero().GetLogicaTile(newPos).GetTerreno() == Terreno.agua)
				yield return new WaitForSeconds (0.2f);
			else
				yield return new WaitForSeconds (0.4f);
			
			MueveBarco (camino);
		}
		else 
		{
			_logicaBarco.SetFlecha (newPos);
			_flecha.transform.position = new Vector3(newPos.GetX() * GameManager.Distancia, -newPos.GetY() * GameManager.Distancia, 0);
		}
	}

}
