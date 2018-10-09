using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinationsuppgift1 : MonoBehaviour
{
    [Range(-720, 720)]

    public float rightRotationSpeed;
    public float leftRotationSpeed;
    public SpriteRenderer spaceShipBack;
    public SpriteRenderer spaceShipFront;
    public Color BlueColor;
    public float shipSpeed;
    public float slowerShipSpeed;
    public float timer;
    public Transform spaceShipPlacement;
    public Transform spaceShipSpawn;
    public Color blueColor;
    public Color greenColor;

    // Use this for initialization
    void Start()
    {
        /* Här randomiserar jag den vanliga hastigheten på skeppet och den långsammare varianten vilket kommer aktiveras 
         * när jag trycker på S. Jag har också min timer vilket jag startar på 0.*/
        shipSpeed = Random.Range(1, 21);
        slowerShipSpeed = shipSpeed / 2;
        timer = 0;

        /* Här väljer jag ut min rotationshastighet och bestämmer att den ena ska vara snabbare än den andra.*/
        rightRotationSpeed = 150;
        leftRotationSpeed = 120;

        /* Här randomiserar jag skeppets startposition och säger till att den kan bara starta inom kamerans zon.*/
        spaceShipSpawn.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4));

        /* Här väljer jag färgen för variabler i framtiden så jag slipper hardcoda det.*/
        blueColor = new Color(0, 0, 1);
        greenColor = new Color(0, 1, 0);


   }

    // Update is called once per frame
    void Update()
    {
        /* Här gör jag så min timer går upp med 1 och printar det varje sekund. 
         * Jag säger också till så att det står timer när den printar och inte bara printar numret.*/
        if (Time.fixedTime == timer)
        {
            timer = timer + 1;
            print("Timer " + timer);
        }


        /* Här gör jag så D ändrar färg på båda spritesen och svänger åt höger och är oberoende på frameraten med hjälp av att 
         * gångra den med deltaTime. A svänger åt vänster och blir grön och är också oberoende på frameraten p.g.a deltaTime. 
           Jag gör också så S aktiverar den långsammare hastigheten men annars om den inte trycks ner så åker man den vanliga
           hastigheten vilket båda är oberoende av framerate. */
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, rightRotationSpeed * Time.deltaTime);
            spaceShipBack.color = blueColor;
            spaceShipFront.color = blueColor;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, -leftRotationSpeed * Time.deltaTime);
            spaceShipBack.color = greenColor;
            spaceShipFront.color = greenColor;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(slowerShipSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        else
        {
            transform.Translate(shipSpeed * Time.deltaTime, 0, 0, Space.Self);
        }

        /*Här så gör jag så när jag trycker på spacebar så randomiserar jag färgen (RGB) på båda av mina sprites.*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceShipBack.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            spaceShipFront.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }

        /*Här så gör jag så om min skepps position är vid kanten av kameran så inverterar jag positionen på skeppet. 
         * Om den åker ut mot y axeln inverteras dess y axeln och om den åker ut på x axeln så inverteras dess x axel.*/

        if (transform.position.x < -9 || transform.position.x > 9)
        {
            spaceShipPlacement.position = new Vector3(transform.position.x * -1f, spaceShipPlacement.position.y);
        }
        if (transform.position.y < -5 || transform.position.y > 5)
        {
            spaceShipPlacement.position = new Vector3(spaceShipPlacement.position.x, transform.position.y * -1f);
        }
    }
}
