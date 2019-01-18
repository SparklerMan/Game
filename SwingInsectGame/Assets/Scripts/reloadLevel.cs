using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadLevel : MonoBehaviour {

    public GameObject player;
    private playerMovement playerMovement;
    private Vector3 PlayerPos;
    public GameObject effect;

    private void Start()
    {
        playerMovement = player.GetComponent<playerMovement>();
    }

    void Update () {
        if (playerMovement.isDead && player != null)
        {
            StartCoroutine(toop());
        } 
	}

    IEnumerator toop()
    {
        Destroy(player);
        Instantiate(effect, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
