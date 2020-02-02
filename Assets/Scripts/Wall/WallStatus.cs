using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    untouched,
    damaged,
    broken,
    destroyed
}

public class WallStatus : MonoBehaviour
{
    public AudioSource damageAudio;
    public AudioSource repairAudio;
    public Status status;
    public Transform wall1;
    public Transform wall2;
    Transform jugador;
    CanvasWarning avisoDerecha, avisoIzquierda;
    public float duracionAviso = 1;
    public float rangoActivacionAviso = 5;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Snowman").transform;
        avisoDerecha = GameObject.Find("CanvasWarningRight").GetComponent<CanvasWarning>();
        avisoIzquierda = GameObject.Find("CanvasWarningLeft").GetComponent<CanvasWarning>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnowBall"))
        {
            Repair();
            Destroy(other.gameObject);
        }
    }

    public void Damage()
    {
        status++;
        Aviso();
        damageAudio.Play();
        ChangeScale();
        if (status == Status.destroyed)
        {
            Destroy(gameObject);
        }
    }


    void Repair()
    {
        if (status != 0)
        {
            status--;
            repairAudio.Play();
            ChangeScale();
        }
    }

    void ChangeScale()//Temporal
    {
        switch (status)
        {
            case Status.untouched:
                wall1.localScale = new Vector3(2, 4, 1);
                wall2.localScale = new Vector3(2, 4, 1);
                //healthBar.sizeDelta = new Vector2(1, 0.3f);
                break;

            case Status.damaged:
                wall1.localScale = new Vector3(2, 2.5f, 1f);
                wall2.localScale = new Vector3(2, 2.5f, 1f);
                //healthBar.sizeDelta = new Vector2(0.75f, 0.3f);
                break;

            case Status.broken:
                wall1.localScale = new Vector3(2, 1, 1f);
                wall2.localScale = new Vector3(2, 1, 1f);
                //healthBar.sizeDelta = new Vector2(0.5f, 0.3f);
                break;
        }
    }

    void Aviso()
    {
        bool isOutOfRange = Mathf.Abs(jugador.position.x - transform.position.x) >= rangoActivacionAviso;
        bool isRight = jugador.position.x > transform.position.x;

        if (isOutOfRange && isRight)
        {
            avisoDerecha.Warn();
        }

        if (isOutOfRange && !isRight)
        {
            avisoIzquierda.Warn();
        }

    }
}
