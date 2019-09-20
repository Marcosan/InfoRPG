using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSceneTurtle : MonoBehaviour {
    public Transform posSceneTurtle;
    public GameObject tortuga;
    public NocheManager nocheManager;
    public Animator anim_joystick;

    // Para controlar si empieza o no la transición
    private bool start = false;
    // Para controlar si la transición es de entrada o salida
    private bool isFadeIn = false;
    // Opacidad inicial del cuadrado de transición
    private float alpha = 0;
    // Transición de 1 segundo
    private float fadeTime = 1f;

    private GameObject player;
    private SpriteRenderer sprite;

    private void Start() {
        //tortuga.SetActive(false);
        player = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Interact") {
            sprite.enabled = false;
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Interact") {
            sprite.enabled = true;
        }
        if (collision.tag == "Action") {
            FadeIn();
            anim_joystick.SetBool("IsClosed", true);

            yield return new WaitForSeconds(fadeTime);
            FadeOut();
            player.gameObject.SetActive(false);
            player.transform.position = posSceneTurtle.position;
            tortuga.SetActive(true);
            nocheManager.CambiarNocheDia();
        }
    }    

    // Dibujaremos un cuadrado con opacidad encima de la pantalla simulando una transición
    void OnGUI(){

        // Si no empieza la transición salimos del evento directamente
        if (!start)
            return;

        // Si ha empezamos creamos un color con una opacidad inicial a 0
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        // Creamos una textura temporal para rellenar la pantalla
        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        // Dibujamos la textura sobre toda la pantalla
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        // Controlamos la transparencia
        if (isFadeIn){
            // Si es la de aparecer le sumamos opacidad
            alpha = Mathf.Lerp(alpha, 1.1f, fadeTime * Time.deltaTime);
        }
        else{
            // Si es la de desaparecer le restamos opacidad
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);
            // Si la opacidad llega a 0 desactivamos la transición
            if (alpha < 0) start = false;
        }

    }

    // Método para activar la transición de entrada
    void FadeIn(){
        start = true;
        isFadeIn = true;
    }

    // Método para activar la transición de salida
    void FadeOut(){
        isFadeIn = false;
    }
}
