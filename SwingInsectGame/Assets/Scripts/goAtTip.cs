using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goAtTip : MonoBehaviour {
    public bool lastFlip;
    public SpriteRenderer hisSprite;
    public Vector3 newPos;

    private void Start()
    {
    }
    void Update () {
		if (hisSprite.flipX == !lastFlip)
        {
            Debug.Log(transform.position.x);
            transform.position *= -1;
            Debug.Log(transform.position.x);
        }

        lastFlip = hisSprite.flipX;
	}
}
