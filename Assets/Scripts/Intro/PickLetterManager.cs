using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickLetterManager : MonoBehaviour {
    
    public Animator anim_hand;

    private void Start() {

    }

    public void EmpezarAnimacionMano() {
        Debug.Log("Empieza A Tomar carta");
        StartCoroutine(EmpezarAnimacionManoCO());
    }

    private IEnumerator EmpezarAnimacionManoCO() {
        Debug.Log("Empieza Entregar carta");
        yield return new WaitForSeconds(1f);
        anim_hand.SetBool("isOpen", true);

        yield return new WaitForSeconds(5f);

        Debug.Log("Termina todo");
        //SceneManager.LoadScene("Lobby");
    }
}
