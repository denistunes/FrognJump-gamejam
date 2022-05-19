using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        
        if (gameManager.numOfHearts < gameManager.MaxHearts)
        {
            FindObjectOfType<AudioManager>().Play("HPUp");
            gameManager.numOfHearts += 1;
            Destroy(gameObject);
        }
    }
}
