using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examinationsuppgift1 : MonoBehaviour
{
    [Range(-720, 720)]

    public float rotationSpeed;
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

        rotationSpeed = 100;
        

    }

    // Update is called once per frame
    void Update()
    {
        /* Här gör jag så min timer går upp med 1 varje sekund och printar den varje frame.*/
        timer = timer + 1 * Time.deltaTime;
        print("Timer " + timer);

        /* Här gör jag så D ändrar färg på båda spritesen och svänger åt höger, så A svänger åt vänster och blir grön. 
           Jag gör också så S aktiverar den långsammare hastigheten men annars om den inte trycks på så åker man den vanliga
           hastigheten. */
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            spaceShipBack.color = new Color(0, 0, 1);
            spaceShipFront.color = new Color(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
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
    }
}
