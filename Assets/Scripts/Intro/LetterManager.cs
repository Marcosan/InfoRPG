using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour {
    
    public GameObject npc;
    public GameObject carta;
    public GameObject siguienteEscena;
    private Animator anim_npc;
    private Animator anim_carta;
    private NpcChase npcScript;
    private Transform carta_child;
    private bool start;

    private void Start() {
        start = true;
        npcScript = npc.GetComponent<NpcChase>();
        anim_npc = npc.GetComponent<Animator>();
        anim_carta = carta.GetComponent<Animator>();
        carta_child = carta.transform.GetChild(0);

        siguienteEscena.SetActive(false);
        npcScript.SetSpeedNpc(0,-1);
    }

    private void Update() {
        if (start) {
            carta_child.transform.position = new Vector2(npc.transform.position.x, carta_child.transform.position.y);
        }
    }

    public void EmpezarAnimacionTortuga() {
        Debug.Log("Empieza A caminar");
        npcScript.SetSpeedNpc(0.6f, -1);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "NPC") {
            Debug.Log("Empieza Entregar carta");
            start = false;
            npcScript.isMovingNpc(false);
            anim_npc.SetBool("walking", false);
            yield return new WaitForSeconds(1f);

            Debug.Log("Entrega");
            anim_npc.SetBool("isJumping", true);
            anim_carta.SetBool("isJumping",true);
            //anim_carta.Play("letter_leave");
            yield return new WaitForSeconds(3f);

            Debug.Log("Se va");
            start = false;
            anim_npc.SetBool("isJumping", false);
            anim_npc.SetBool("walking", true);
            npcScript.isMovingNpc(true);
            siguienteEscena.SetActive(true);
        }
    }

}
