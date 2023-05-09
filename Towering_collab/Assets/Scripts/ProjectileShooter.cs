using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Camera player_cam;
    public GameObject player;
    //public GameObject launcher_cam;
    public float launchForce = 150f;
    public float destroy_time = 2f;
    public float spawn_distance;
    public float height_head_to_launcher;
    private GameObject ring0;
    private GameObject ring1;
    private int launched0 = 0;
    private int launched1 = 0;
    private GameObject spawnPoint0;
    private GameObject spawnPoint1;
    public float cooldown_tp;
    private float timer0;
    private float timer1;
    public AudioSource throwSound, tpSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (launched0)
            {
                case 0:
                    // Get the camera's transform
                    throwSound.Play();
                    Transform cameraTransform = player_cam.transform;

                    // Calculate the launch direction based on the camera's forward vector
                    Vector3 launchDirection = cameraTransform.forward;

                    var pos_proj = player_cam.transform.position + player_cam.transform.forward * spawn_distance;

                    // Spawn a new ball and set its position to the camera's position
                    GameObject ring0 = Instantiate(ballPrefab, new Vector3(pos_proj.x, pos_proj.y - height_head_to_launcher, pos_proj.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    ring0.name = "ring0";

                    // Get the ball's rigidbody component and apply a force in the launch direction
                    Rigidbody ballRigidbody = ring0.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);
                    launched0 = 1;
                    break;

                case 1:
                    tpSound.Play();
                    spawnPoint0 = GameObject.Find("ring0");
                    player.transform.position = Vector3.MoveTowards(transform.position, spawnPoint0.transform.position, 100050 * Time.deltaTime);
                    player_cam.transform.position = Vector3.MoveTowards(transform.position, spawnPoint0.transform.position, 100050 * Time.deltaTime);
                    if (spawnPoint0 != null)
                    {
                        Destroy(spawnPoint0);
                        timer0 = cooldown_tp;
                    }
                    launched0 = 0;
                    break;
                default:
                    break;
            }
        }
        if (launched0 == 1)
        {
            timer0 -= Time.deltaTime;
        }
        if (timer0 <= 0)
        {
            GameObject a = GameObject.Find("ring0");
            if (a != null)
            {
                Destroy(a);
                timer0 = cooldown_tp;
            }
            launched0 = 0;
        }


        ///////////////////// 2nd ring ///////////////////////////


        if (Input.GetMouseButtonDown(1))
        {
            switch (launched1)
            {
                case 0:
                    throwSound.Play();
                    // Get the camera's transform
                    Transform cameraTransform = player_cam.transform;

                    // Calculate the launch direction based on the camera's forward vector
                    Vector3 launchDirection = cameraTransform.forward;

                    var pos_proj = player_cam.transform.position + player_cam.transform.forward * spawn_distance;

                    // Spawn a new ball and set its position to the camera's position
                    GameObject ring1 = Instantiate(ballPrefab, new Vector3(pos_proj.x, pos_proj.y - height_head_to_launcher, pos_proj.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    ring1.name = "ring1";

                    // Get the ball's rigidbody component and apply a force in the launch direction
                    Rigidbody ballRigidbody = ring1.GetComponent<Rigidbody>();
                    ballRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);
                    launched1 = 1;
                    break;

                case 1:
                    tpSound.Play();
                    spawnPoint1 = GameObject.Find("ring1");
                    player.transform.position = Vector3.MoveTowards(transform.position, spawnPoint1.transform.position, 100050 * Time.deltaTime);
                    player_cam.transform.position = Vector3.MoveTowards(transform.position, spawnPoint1.transform.position, 100050 * Time.deltaTime);
                    if (spawnPoint1 != null)
                    {
                        Destroy(spawnPoint1);
                        timer1 = cooldown_tp;
                    }
                    launched1 = 0;
                    break;
                default:
                    break;
            }
        }
        if (launched1 == 1)
        {
            timer1 -= Time.deltaTime;
        }
        if (timer1 <= 0)
        {
            GameObject a = GameObject.Find("ring1");
            if (a != null)
            {
                Destroy(a);
                timer1 = cooldown_tp;
            }
            launched1 = 0;
        }
    }
}