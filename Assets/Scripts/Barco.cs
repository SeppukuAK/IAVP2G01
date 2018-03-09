using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barco : MonoBehaviour {

    LogicaBarco _logicaBarco;

    Sprite _spriteBarco;
    Sprite _spriteBarcoSeleccionado;

    // Use this for initialization
    void Start()
    {
    }

    public void ConstruyeBarco(LogicaBarco logicaBarco, Sprite spriteBarco, Sprite spriteBarcoSeleccionado)
    {
        _logicaBarco = logicaBarco;
        _spriteBarco = spriteBarco;
        _spriteBarcoSeleccionado = spriteBarcoSeleccionado;

       GetComponent<SpriteRenderer>().sprite = _spriteBarco;
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.GetSeleccionado() == TipoBarco.ninguno)
        {
            SpriteRenderer render = GetComponent<SpriteRenderer>();
            render.sprite = _spriteBarcoSeleccionado;

            GameManager.instance.SetSeleccionado(_logicaBarco.GetTipoBarco());
        }

    }
}
