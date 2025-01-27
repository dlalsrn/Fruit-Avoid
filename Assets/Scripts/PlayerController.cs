using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private float moveSpeed = 5f;
    private float xDir = 0;
    private bool isShield = false;

    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.GetGameOver()) {
            xDir = 0;
            animator.SetBool("Running", false);
            return;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { // 왼쪽 방향
            xDir = -1;
            transform.localScale =  new Vector3(xDir, transform.localScale.y, transform.localScale.z);
            animator.SetBool("Running", true);
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { // 오른쪽 방향
            xDir = 1;
            transform.localScale =  new Vector3(xDir, transform.localScale.y, transform.localScale.z);
            animator.SetBool("Running", true);
        } else {
            xDir = 0;
            animator.SetBool("Running", false);
        }
    }

    void FixedUpdate() {
        rigidbody2d.velocity = new Vector2(xDir * moveSpeed, 0);
    }

    public void CreateShield() {
        isShield = true;
        HUDManager.Instance.CreateShield();
    }

    public void DestoryShield() {
        isShield = false;
        HUDManager.Instance.DestoryShield();
    }

    public bool GetShield() {
        return isShield;
    }
}
