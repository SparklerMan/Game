using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponControl : MonoBehaviour {
    public float offset, shootRate, damage;
    private Vector3 cursorPos, difference, newScale;
    private float rotZ, lastPlayerScale, timeLeft;
    public Transform player;
    public GameObject projectile, weaponTip;

    private void Start()
    {
        lastPlayerScale = player.localScale.x;
    }
    void Update () {

        if(lastPlayerScale != player.localScale.x)
        {
            flip();
        }


        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        difference = cursorPos - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (timeLeft <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, weaponTip.transform.position, transform.rotation);
                timeLeft = shootRate;
            }
        }else
        {
            timeLeft -= Time.deltaTime;
        }



        lastPlayerScale = player.localScale.x;

	}

    void flip()
    {
        transform.localScale *= -1;
        offset *= -1;
    }


}
