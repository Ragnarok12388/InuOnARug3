using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public AudioManager Sounds;
    public float distance;
    public float movespeed;
    public float headmove;
    public Animator Animations;
    public float minTime;
    public float maxTime;
    private float spawnTime;
    private bool frozen;
    public GameObject laserbeam;
    public Cameramovement camera;
    public int HP;
    public Fireball fireball;
    public bool direction;
    public float directiontime;
    public Player player;
    public Healthbar Bar;
    public bool Beat;
    public Camera follow;
    public Camera Maincamera;
    public GameObject Explosion;
    public Rigidbody2D Cthulhubody;
    public bool dead;
    public TextTMP addscore;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 25.0f;
        HP = 0;
        StartCoroutine(StartMove());
        Beat = false;
        dead = false;
    }
    IEnumerator BossExplosion()
    {
        PlayerPrefs.SetInt("beat", 1);
        float creationtime = Time.timeSinceLevelLoad;
        Maincamera.gameObject.SetActive(false);
        follow.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        dead = true;
        bool pulse = false;
        while (Time.timeSinceLevelLoad < creationtime+15.0f)
        {
            pulse = !pulse;
            float randomcry = Random.Range(0.0f, 2.0f);
            float randomX = Random.Range(-1.0f, 1.0f);
            float randomY = Random.Range(-1.0f, 1.0f);
            GameObject exp = Instantiate(Explosion, new Vector3(transform.position.x+(randomX*2.0f), transform.position.y + (randomY *2.0f), 0.0f), transform.rotation);
            Destroy(exp, 2.0f);
            if(randomcry<0.25f)
            {
                Sounds.PlayCthulhuCry();
            }
            Vector3 supervector = transform.position;
            supervector.x += (pulse ? 0.3f : -0.3f);
            supervector.y += (pulse ? 0.2f : -0.2f);
            transform.position = supervector;
            yield return new WaitForSeconds(0.2f);
        }       
        follow.gameObject.SetActive(false);
        Maincamera.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        Cthulhubody.gravityScale = 1.0f;
        Cthulhubody.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(5.0f);
        addscore.increasescore(600);
    }
    IEnumerator StartMove()
    {
        Vector3 initialposition = transform.position;
        float elapsedtime = 0;
        Vector3 targetposition = initialposition - new Vector3(distance, 0, 0);
        while (elapsedtime < distance / movespeed)
        {
            transform.position = Vector3.Lerp(initialposition, targetposition, elapsedtime / (distance / movespeed));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        Animations.SetTrigger("Start roar");
        yield return new WaitForSeconds(3.5f);
        Sounds.PlayCthulhu();
        yield return new WaitForSeconds(5.0f);
        camera.Bosssize(10.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Beat == true)
        {
            return;
        }
        if (HP>=200.0f)
        {
            Beat = true;
            StartCoroutine(BossExplosion());
        }
        if (Time.timeSinceLevelLoad < 20.0f || player == null)
        {
            return;
        }
        if (Time.timeSinceLevelLoad > directiontime)
        {
            float timeBetweenSpawn = Random.Range(20.0f, 60.0f);
            directiontime = Time.timeSinceLevelLoad + timeBetweenSpawn;

            float randomdirection = Random.Range(0.0f, 2.0f);
            if (randomdirection <= 1.0f)
            {
                headmove = -headmove;
            }
        }
        if(frozen == true)
        {
            return;
        }
        float headmovex = (1.0f - (Mathf.Abs(transform.position.x) / 15.5f))*headmove;
        float headmovey = (1.0f - (Mathf.Abs(transform.position.y) / 9.0f)) * headmove;
        Vector3 nVector = player.transform.position - transform.position;
        nVector.Normalize();
        float angle = (Mathf.Atan2(nVector.y, nVector.x) * Mathf.Rad2Deg)+180.0f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        angle += 90.0f;
        Vector3 movement2 = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle)*headmovex, Mathf.Sin(Mathf.Deg2Rad * angle)*headmovey, 0.0f);
        Vector3 Cposition = transform.position;
        Cposition.x += movement2.x;
        Cposition.y += movement2.y;
        transform.position = Cposition;
        StartCoroutine (attack());
    }
    void Openmouth()
    {
        Animations.SetTrigger("Open");
    }
    IEnumerator attack()
    {
        if (Time.timeSinceLevelLoad > spawnTime)
        {
            float timeBetweenSpawn = Random.Range(minTime * (0.25f + (0.75f *(1.0f - (HP / 200.0f)))), maxTime* (0.25f + (0.75f * (1.0f - (HP / 200.0f)))));
            frozen = true;
            yield return new WaitForSeconds(1.0f);
            float randomattack = Random.Range(0.0f, 2.0f);
            if (randomattack<=1.0f)
            {
                makelaserbeam();
                Openmouth();
                if (HP >= 100)
                {
                    makelaserbeam(16.5f, 193.0f, 105.0f);
                    makelaserbeam(16.5f, 163.0f, 75.0f);

                }
            }
            else
            {
                fireball2();

            }
            yield return new WaitForSeconds(2.0f);
            frozen = false;
            //spawnTime = Time.time + timeBetweenSpawn;
            spawnTime = Time.timeSinceLevelLoad + timeBetweenSpawn;
        }
    }
    void makelaserbeam(float laserOffset = 16.5f, float staticOffset = 178.0f, float laserrotationset = 90.0f)
    {
        

        // Calculate displacement along X and Y axes based on boss's rotation angle
        float displacementX = Mathf.Cos((transform.eulerAngles.z + staticOffset) * Mathf.Deg2Rad) * laserOffset;
        float displacementY = Mathf.Sin((transform.eulerAngles.z + staticOffset) * Mathf.Deg2Rad) * laserOffset;
        Vector3 displacement = new Vector3(displacementX, displacementY, 0.0f);

        // Transform vertical offset to world space

        // Combine displacements

        // Calculate spawn position for the laserbeam
        Vector3 spawnPosition = transform.position + displacement;

        // Calculate spawn position for the laserbeam
        //Vector3 spawnPosition = transform.position + new Vector3(displacementX, displacementY, 0.0f);

        // Instantiate laserbeam at spawn position
        GameObject LaserInstance = Instantiate(laserbeam, spawnPosition, transform.rotation);
        Destroy(LaserInstance, 2.0f);
        Vector3 CurrentRot = LaserInstance.transform.rotation.eulerAngles;
        Vector3 CRotation = transform.rotation.eulerAngles;
        CurrentRot.z = laserrotationset + CRotation.z;
        LaserInstance.transform.rotation = Quaternion.Euler(CurrentRot);
        Sounds.PlayLaser();
    }
    void fireball2()
    {
        Openmouth();
        float laserOffset = 1.50f;
        float staticOffset = 178.0f;
        float displacementX = Mathf.Cos((transform.eulerAngles.z + staticOffset) * Mathf.Deg2Rad) * laserOffset;
        float displacementY = Mathf.Sin((transform.eulerAngles.z + staticOffset) * Mathf.Deg2Rad) * laserOffset;
        StartCoroutine(Makefireball(transform.position.x+displacementX, transform.position.y + displacementY));
    }
    IEnumerator Makefireball(float x, float y)
    {
        float randomspeed = Random.Range(0.7f, 1.0f);
        float randommaxspeed = Random.Range(0.7f, 1.3f);
        Fireball Fireball1 = Instantiate(fireball, new Vector3(x, y, 0.0f), transform.rotation);
        Fireball1.speed = Fireball1.speed * randomspeed;
        Fireball1.maxspeed = Fireball1.maxspeed * randommaxspeed;
        Rigidbody2D rb1 = Fireball1.GetComponent<Rigidbody2D>();
        rb1.constraints = RigidbodyConstraints2D.None;
        yield return new WaitForSeconds(0.3f);
        randomspeed = Random.Range(0.7f, 1.0f);
        randommaxspeed = Random.Range(0.7f, 1.3f);
        Fireball Fireball2 = Instantiate(fireball, new Vector3(x, y, 0.0f), transform.rotation);
        Fireball2.speed = Fireball2.speed * randomspeed;
        Fireball2.maxspeed = Fireball2.maxspeed * randommaxspeed;
        Rigidbody2D rb2 = Fireball2.GetComponent<Rigidbody2D>();
        rb2.constraints = RigidbodyConstraints2D.None;
        yield return new WaitForSeconds(0.3f);
        randomspeed = Random.Range(0.7f, 1.0f);
        randommaxspeed = Random.Range(0.7f, 1.3f);
        Fireball Fireball3 = Instantiate(fireball, new Vector3(x, y, 0.0f), transform.rotation);
        Fireball3.speed = Fireball3.speed * randomspeed;
        Fireball3.maxspeed = Fireball3.maxspeed * randommaxspeed;
        Rigidbody2D rb3 = Fireball3.GetComponent<Rigidbody2D>();
        rb3.constraints = RigidbodyConstraints2D.None;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SolanaRigid"))
        {
            Destroy(collision.gameObject);
            HP += 1;
            Animations.SetTrigger("Hit");
            Sounds.PlayCry();
            Bar.Awake();
        }
    }
}
