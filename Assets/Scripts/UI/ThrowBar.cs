using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBar : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    PlayerAttack playerAttack;
    public float currentCharge = 0;
    public float maxCharge;
    bool isCharging;
    float chargeStart;
    // Start is called before the first frame update
    void Start()
    {
        playerAttack = player.GetComponent<PlayerAttack>();
        maxCharge = playerAttack.powerMax - playerAttack.powerMin;
    }

    // Update is called once per frame
    void Update()
    {
        Charge();
        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            currentCharge = 0;
            isCharging = false;
            canvas.SetActive(false);
        }
    }
    void Charge()
    {
        if(isCharging && currentCharge < maxCharge)
        {
            float timeDif = Time.time - chargeStart;
            currentCharge = timeDif / maxCharge;
            transform.localScale = new Vector3(transform.localScale.x, currentCharge, transform.localScale.z);
        }
    }

    private void OnEnable()
    {
        isCharging = true;
        chargeStart = Time.time;
    }
}
