using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour {
    
    public NpcChase npc;
    public GameObject siguienteEscena;
    private Animator animator;

    private void Start() {
        animator = npc.GetComponent<Animator>();
        siguienteEscena.SetActive(false);
        npc.SetSpeedNpc(0,-1);
    }

    public void EmpezarAnimacionTortuga() {
        Debug.Log("Empieza A caminar");
        npc.SetSpeedNpc(0.6f, -1);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "NPC") {
            Debug.Log("Empieza Entregar carta");
            npc.isMovingNpc(false);
            animator.SetBool("walking", false);
            yield return new WaitForSeconds(1f);
            Debug.Log("Entrega");
            animator.SetBool("isJumping", true);
            yield return new WaitForSeconds(3f);
            Debug.Log("Se va");
            animator.SetBool("isJumping", false);
            npc.isMovingNpc(true);
            animator.SetBool("walking", true);
            siguienteEscena.SetActive(true);
        }
    }

}
