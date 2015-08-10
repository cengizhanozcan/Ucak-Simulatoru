using UnityEngine;
using System.Collections;


[System.Serializable]
public class PositionGame {
    public float xMin, xMax, zMin, zMax;

    public PositionGame()
    {
        zMin = -6.0f;
        zMax = 10f;
        xMin = -8f;
        xMax = 8f;
    }
}

public class PlayerController : MonoBehaviour {

    public int speed;
    public float tilda, nextFire;
    
    public float fireRate;

    public GameObject shot;
    public Transform shotSpawn;

    PositionGame pos = new PositionGame();


    void Update() {

        if (Input.GetButton("Fire1") && Time.time> nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);   
        }
    }

     void FixedUpdate()
    {
        float horizantal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
         
        Vector3 movement = new Vector3(horizantal * speed, 0, vertical * speed);
        rigidbody.velocity = movement;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, pos.xMin, pos.xMax)
            , 0.0f
            , Mathf.Clamp(rigidbody.position.z, pos.zMin, pos.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(new Vector3( rigidbody.velocity.z
 ,0.0f, rigidbody.velocity.x * tilda));
    }

}
