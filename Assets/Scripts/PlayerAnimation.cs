using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verifica se alguma das teclas WASD está sendo pressionada
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        // Define o valor da booleana "isWalk" no animador
        animator.SetBool("isWalk", isMoving);

        // Verifica se a tecla de pulo (espaço) está sendo pressionada
        bool isJumping = Input.GetKey(KeyCode.Space);

        // Define o valor da booleana "isJump" no animador
        animator.SetBool("isJump", isJumping);

        // Verifica se o botão esquerdo do mouse está sendo pressionado
        bool isAttacking = Input.GetMouseButton(0);

        // Define o valor da booleana "isAttack" no animador
        animator.SetBool("isAttack", isAttacking);

        // Verifica se a tecla R está sendo pressionada
        bool isDead = Input.GetKeyDown(KeyCode.R);

        // Define o valor da booleana "isDead" no animador
        animator.SetBool("isDead", isDead);
    }

}
