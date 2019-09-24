using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NocheManager : MonoBehaviour {

    public NpcChase npc;
    public Animator anim_fondo;
    public Animator anim_sun;
    public Animator anim_moon;
    public Animator anim_start;
    public Animator anim_cloud;

    private void Start() {
        npc.SetSpeedNpc(0,-1);
    }

    public void CambiarNocheDia() {
        StartCoroutine(CambiarNocheDiaCO());
    }

    private IEnumerator CambiarNocheDiaCO() {
        Camera.main.orthographicSize = 5;
        npc.SetSpeedNpc(0.4f,-1);
        yield return new WaitForSeconds(3f);
        Debug.Log("Empieza Noche");
        anim_fondo.SetBool("setNight", true);
        anim_moon.SetBool("setNight", true);
        anim_sun.SetBool("setNight", true);
        anim_start.SetBool("setNight", true);
        anim_cloud.SetBool("setNight", true);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "NPC") {
            Debug.Log("Empieza Día");
            anim_fondo.SetBool("setNight", false);
            anim_moon.SetBool("setNight", false);
            anim_sun.SetBool("setNight", false);
            anim_start.SetBool("setNight", false);
            anim_cloud.SetBool("setNight", false);
        }
    }
}
