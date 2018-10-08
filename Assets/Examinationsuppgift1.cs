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

    // Use this for initialization
    void Start()
    {
        /* Här väljer jag ut den vanliga hastigheten på skeppet och den långsammare varianten vilket aktiveras 
         * när jag trycker på S. Jag har också min timer vilket jag startar på 0.*/
        
    shipSpeed = 6;
        slowerShipSpeed = 3;
        timer = 0;

        rightRotationSpeed = 150;
        leftRotationSpeed = 120;
        

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


        /* Här gör jag så D ändrar färg på båda spritesen och svänger åt höger, så A svänger åt vänster och blir grön. 
           Jag gör också så S aktiverar den långsammare hastigheten men annars om den inte trycks på så åker man den vanliga
           hastigheten. */
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, rightRotationSpeed * Time.deltaTime);
            spaceShipBack.color = new Color(0, 0, 1);
            spaceShipFront.color = new Color(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, -leftRotationSpeed * Time.deltaTime);
            spaceShipBack.color = new Color(0, 1, 0);
            spaceShipFront.color = new Color(0, 1, 0);
        }
       
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(slowerShipSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        else
        {
            transform.Translate(shipSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }
}
