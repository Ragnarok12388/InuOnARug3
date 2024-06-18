using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleBehavior : MonoBehaviour
{
    public float movespeed;
    public float distance;
    private Vector3 initialposition;
    public EdgeCollider2D collider2;
    private List<Vector2> Frame1Vector2List;
    private List<Vector2> Frame2Vector2List;
    private List<Vector2> Frame3Vector2List;
    private List<Vector2> Frame4Vector2List;
    private List<Vector2> Frame5Vector2List;
    public GameObject player;
    public GameObject gameOverPanel;
    public Player player2;
    public Livestext livesdoge;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        initialposition = transform.position;
        StartCoroutine(lower());
        Frame1Vector2List = new List<Vector2>();

        // Manually add custom Vector2 values to the list
        Frame1Vector2List.Add(new Vector2(-0.1928751f, -2.02863f));
        Frame1Vector2List.Add(new Vector2(1.757116f, 0.952592f));
        Frame1Vector2List.Add(new Vector2(0.34243f, 2.013279f));
        Frame1Vector2List.Add(new Vector2(-1.009277f, 1.030415f));

        Frame2Vector2List = new List<Vector2>();

        // Manually add custom Vector2 values to the list
        Frame2Vector2List.Add(new Vector2(-0.1928751f, -2.02863f));
        Frame2Vector2List.Add(new Vector2(1.757116f, 0.952592f));
        Frame2Vector2List.Add(new Vector2(0.34243f, 2.013279f));
        Frame2Vector2List.Add(new Vector2(-1.009277f, 1.030415f));

        Frame3Vector2List = new List<Vector2>();

        // Manually add custom Vector2 values to the list
        Frame3Vector2List.Add(new Vector2(0.526269f, -1.835427f));
        Frame3Vector2List.Add(new Vector2(-1.79567f, 0.8989245f));
        Frame3Vector2List.Add(new Vector2(-0.5055158f, 2.024013f));
        Frame3Vector2List.Add(new Vector2(1.094488f, 0.9016135f));

        Frame4Vector2List = new List<Vector2>();

        // Manually add custom Vector2 values to the list
        Frame4Vector2List.Add(new Vector2(-0.2250755f, -2.511638f));
        Frame4Vector2List.Add(new Vector2(1.660515f, 0.3407828f));
        Frame4Vector2List.Add(new Vector2(-0.8704547f, 1.58394f));
        Frame4Vector2List.Add(new Vector2(0.3324099f, 2.715574f));

        Frame5Vector2List = new List<Vector2>();

        // Manually add custom Vector2 values to the list
        Frame5Vector2List.Add(new Vector2(-0.2250755f, -2.511638f));
        Frame5Vector2List.Add(new Vector2(-1.709802f, 0.7271886f));
        Frame5Vector2List.Add(new Vector2(0.8683714f, 1.594673f));
        Frame5Vector2List.Add(new Vector2(-0.2364653f, 2.726308f));


    }

    public void LoadFrame1()
    {
        collider2.SetPoints(Frame1Vector2List);
    }

    public void LoadFrame2()
    {
        collider2.SetPoints(Frame2Vector2List);
    }

    public void LoadFrame3()
    {
        collider2.SetPoints(Frame3Vector2List);
    }

    public void LoadFrame4()
    {
        collider2.SetPoints(Frame4Vector2List);
    }

    public void LoadFrame5()
    {
        collider2.SetPoints(Frame5Vector2List);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Doge")
        {
            if (player2.poweredUp == false)
            {
                audioManager.PlayYelp();
                if (player2.lives > 1)
                {
                    player2.lives -= 1;
                    livesdoge.Awake();
                    return;
                }

                gameOverPanel.SetActive(true);
                Destroy(player.gameObject);
            }
        }
    }

    IEnumerator lower()
    {
        float elapsedtime = 0;
        Vector3 targetposition = initialposition + new Vector3(0, distance, 0);
        while (elapsedtime < distance / movespeed)
        {
            transform.position = Vector3.Lerp(initialposition, targetposition, elapsedtime / (distance / movespeed));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetposition;
        yield return new WaitForSeconds(2.0f);
        //Instantiate(Laser, transform.position + new Vector3(1.0f, -1.0f, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        yield return new WaitForSeconds(4.0f);
        elapsedtime = 0;
        targetposition = initialposition;
        initialposition = transform.position;
        while (elapsedtime < distance / movespeed)
        {
            transform.position = Vector3.Lerp(initialposition, targetposition, elapsedtime / (distance / movespeed));
            elapsedtime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetposition;
    }
}
