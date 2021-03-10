using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

  public Animator anim;


private float horisontaalinenPyorinta = 0;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
//hmmm, taitaa olla noobi koodauskerho, huoh ttylsistyn täällä -pekka 2021.17.2 klo 19.09 ruumisautossa jee//
    // Update is called once per frame
    void Update()
    {
        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
      float horizontal = Input.GetAxis("Horizontal") * 5;
      float vertical = Input.GetAxis("Vertical") * 5;  
      Vector3 nopeus = new Vector3(horizontal, 0, vertical);
nopeus = transform.rotation * nopeus;

horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;
transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);


// ANIMAATIO ALUE, VIELÄ ON RIKKI
      hahmokontrolleri.SimpleMove(nopeus);
      hahmokontrolleri.Move(nopeus * Time.deltaTime);
      if(Input.GetAxis("Vertical") != 0)
      {
        anim.SetBool("walk", true);
      }else{
        anim.SetBool("walk", false);
      }
    }

}