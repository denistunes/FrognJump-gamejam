using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager gameManager;
    public SpriteRenderer sprite;
    public Color DamageColor;
    public Color OGColor;

    [Header("Damager")]
    public float damageCooldown;
    bool damaged = false;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
        if (collisionInfo.collider.tag == "Death" && damaged == false)
        {
            FindObjectOfType<AudioManager>().Play("Hurt");
            gameManager.numOfHearts -= 1;
            StartCoroutine("Damage");
            transform.position = gameManager.lastJumpPos;

            if (gameManager.numOfHearts < 1)
            {
                FindObjectOfType<AudioManager>().Play("Dead");
                Destroy(gameObject);
                gameManager.EndGame();
            }
        }

        if (collisionInfo.collider.tag == "Finish")
        {
            FindObjectOfType<AudioManager>().Play("HPUp");
            gameManager.CompleteLevel();
        }
    }

    IEnumerator Damage()
    {
        damaged = true;

        sprite.color = DamageColor; 
 
        yield return new WaitForSeconds(damageCooldown);

        sprite.color = OGColor; 
 
        damaged = false;
    }
}
