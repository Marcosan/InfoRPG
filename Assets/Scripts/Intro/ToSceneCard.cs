using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSceneCard : MonoBehaviour {
    public Transform posSceneTurtle;
    public GameObject tortuga;
    public LetterManager letterManager;

    private Transform player;

    private void Start() {
        //tortuga.SetActive(false);
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "NPC") {
            collision.gameObject.SetActive(false);
            player.position = posSceneTurtle.position;
            tortuga.SetActive(true);
            letterManager.EmpezarAnimacionTortuga();
        }
    }
}
