using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnSkip : MonoBehaviour {
    
    public void ToLobby() {
        SceneManager.LoadScene("NewLobby", LoadSceneMode.Single);
    }

}
