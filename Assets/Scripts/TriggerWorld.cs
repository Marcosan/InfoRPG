using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerWorld : MonoBehaviour {

    [SerializeField] private string nameScene;
    [SerializeField] private TextMeshProUGUI titleScene;
    private GameObject actionButton;

    private void Awake() {
        actionButton = GameObject.Find("Area/ActionButton");
    }

    private void Start() {
        actionButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Interact") {
            actionButton.SetActive(true);
            titleScene.text = nameScene;
        }
        if (collision.tag == "Action") {
            SceneManager.LoadScene(nameScene);
            //Debug.Log("Ingreso a: " + nameScene);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.tag == "Interact") {
            actionButton.SetActive(false);
        }
    }

}
