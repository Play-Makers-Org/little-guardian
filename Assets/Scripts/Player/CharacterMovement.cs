using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float CharacterSpeedx;
    public float CharacterSpeedy;
    private float vertical, horizontal;
    public bool isShocked=false;
    public bool isReverted = false;
    private Animator playerAnimator;
    
    private Rigidbody2D _rb;
    
    void Start()
    {
        //Önceki projemde bu şekilde rigidbody oluşturmuşum. Gerekli mi bilmiyorum, yine de ekledim.
        _rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        //Animasyon kodu
    }

    private void Update()
    {
        //Karakterin hareketi
        PlayerMovement();
        
    }

    public void PlayerMovement()
    {   
        transform.position += new Vector3(CharacterSpeedx,CharacterSpeedy,0)*Time.deltaTime;
        //Animasyon kodu
        playerAnimator.SetFloat("Speed",Mathf.Abs(CharacterSpeedx));
        playerAnimator.SetFloat("SpeedY",Mathf.Abs(CharacterSpeedy));
        if (isShocked == true)
        {   
            
            if (Input.GetKey(KeyCode.D))
            {
                CharacterSpeedx = 0f;

                
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                CharacterSpeedx = 0f;

                
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                CharacterSpeedx = 0f;
                
            }

            if (Input.GetKey(KeyCode.W))
            {
                CharacterSpeedy = 0f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                CharacterSpeedy = 0f;
            }
            else
            {
                CharacterSpeedy = 0f;
            }
        }
        else if(isReverted==true)
        {   //Makinenin etkisiyle karakterin kontrollerini karıştıran kod
            if (Input.GetKey(KeyCode.W))
            {
                CharacterSpeedx = 5f;

                
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                CharacterSpeedx = -5f;

                
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                CharacterSpeedx = 0f;
                
            }

            if (Input.GetKey(KeyCode.S))
            {
                CharacterSpeedy = 5f;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                CharacterSpeedy = -5f;
            }
            else
            {
                CharacterSpeedy = 0f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                CharacterSpeedx = 5f;

                //Karakteri döndüren kod
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                CharacterSpeedx = -5f;

                //Karakteri döndüren kod
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                CharacterSpeedx = 0f;
                //Tuştan elini kaldırdığında karakterin hareketini sonlandıran komut.
            }

            if (Input.GetKey(KeyCode.W))
            {
                CharacterSpeedy = 5f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                CharacterSpeedy = -5f;
            }
            else
            {
                CharacterSpeedy = 0f;
            }
        }
    }
    
}
