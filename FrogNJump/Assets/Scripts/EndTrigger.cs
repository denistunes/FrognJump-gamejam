using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void OnTriggerExit2D(Collider2D other) {
        FindObjectOfType<AudioManager>().Play("HPUp");
        gameManager.CompleteLevel();
    }
}
