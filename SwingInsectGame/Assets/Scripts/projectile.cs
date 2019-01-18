using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
    public float speed;
    private weaponControl weaponControl;
    public GameObject effect;

    private void Start()
    {
        weaponControl = GameObject.FindGameObjectWithTag("weapon").GetComponent<weaponControl>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")) { 
            other.GetComponent<enemy>().health -= weaponControl.damage;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
