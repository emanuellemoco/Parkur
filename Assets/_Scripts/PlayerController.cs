
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerController : MonoBehaviour
{

   //Referência usada para a câmera filha do jogador
   GameObject playerCamera;
   //Utilizada para poder travar a rotação no angulo que quisermos.
   float cameraRotation;
   float _baseSpeed = 10.0f;
   float _gravidade = 4.0f; 
   float maxSpeed = 3f;
   
   float y = 0;
   float x = 0;

   private float horizontalJump = 7f;


   private float jump = 1.4f;

   CharacterController characterController;

   public LayerMask isWall;


   private bool isWallRight, isWallLeft;
   
   private float timeWall = 0.0f;

   public float wallLimit = 2.0f;
   
   void Start()
   {
       
       
       Cursor.lockState = CursorLockMode.Locked;

       
        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.Find("Main Camera");
        cameraRotation = 0.0f;
        isWallRight = false;
        isWallLeft = false;
   }


   void Running()
   {
        x  /= 1.5f;
        x += Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Tratando movimentação do mouse
        float mouse_dX = Input.GetAxis("Mouse X");
        float mouse_dY = Input.GetAxis("Mouse Y");

        //Tratando a rotação da câmera
        cameraRotation -= mouse_dY;
        Mathf.Clamp(cameraRotation, -75.0f, 75.0f);

        //Verificando se é preciso aplicar a gravidade

        if(characterController.isGrounded){ 
            y = -_gravidade * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
                y = jump;
            }
        else if (isWallLeft || isWallRight){
                //y -= _gravidade/20.0f * Time.deltaTime;
                y = 0;   
                if (Input.GetKeyDown(KeyCode.Space)){
                    y = 2*jump/3;

                    if (isWallLeft)
                        x += horizontalJump;
                    else 
                        x -= horizontalJump;
                }
        }
            

            else
                y -= _gravidade * Time.deltaTime;
        
        //if (Math.Abs(x) > maxSpeed)
         //   (x > 0) ? (x = maxSpeed) : (x = -maxSpeed) ; 

        Vector3 direction = transform.right * x + transform.up * y + transform.forward * z;


        characterController.Move(direction * _baseSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, mouse_dX);

        playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation, 0.0f, 0.0f);
   }


   void Update()
   {
        isWallRight = Physics.Raycast(transform.position, transform.right, 1.2f, isWall);
        isWallLeft = Physics.Raycast(transform.position, -transform.right, 1.2f, isWall);
        Debug.Log(isWallLeft);
        Debug.Log(isWallRight);
        Running();
   }

   void LateUpdate()

   {
        RaycastHit hit;
        Debug.DrawRay(playerCamera.transform.position, transform.forward*10.0f, Color.magenta);
        if(Physics.Raycast(playerCamera.transform.position, transform.forward, out hit, 100.0f))
            Debug.Log(hit.collider.name);
        }
} 