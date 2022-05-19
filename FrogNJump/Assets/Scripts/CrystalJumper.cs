using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalJumper : MonoBehaviour
{
    bool Destoryed = false;
    public float cooldown;
    public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce = 10f;

    void Update() {
        animator.SetBool("Destoryed", Destoryed);
    }

    void OnTriggerEnter2D(Collider2D collisionInfo) {
        if (collisionInfo.tag == "Player" && Destoryed == false)
        {
            FindObjectOfType<AudioManager>().Play("SuperJump");
            Destoryed = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Invoke("EnableBool", cooldown);
        }
    }

    void EnableBool(){
        Destoryed = false;
    }
}
