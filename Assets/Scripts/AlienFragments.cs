using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alienfragment : MonoBehaviour
{
    public Rigidbody2D Fragment;
    public GameObject Prefab;
    public float speed;
    private GameObject Instance;
    private ParticleSystem particleSystemComponent;
    private ParticleSystem.ShapeModule shapeModule;
    private ParticleSystem.VelocityOverLifetimeModule velocitymodule;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate the prefab and get its ParticleSystem component
        Instance = Instantiate(Prefab, transform.position, Quaternion.identity, transform);
        particleSystemComponent = Instance.GetComponent<ParticleSystem>();
        shapeModule = particleSystemComponent.shape;
        velocitymodule = particleSystemComponent.velocityOverLifetime;
        Vector3 temp = particleSystemComponent.transform.position;
        temp.z = -5f;
        particleSystemComponent.transform.position = temp;
        // Set the scale of the fragment

        // Apply random force and torque to the fragment
        float randomrotation = Random.Range(-50.0f, 50.0f);
        float randomX = Random.Range(-10.0f, 10.0f);
        float randomY = Random.Range(-10.0f, 10.0f);
        Fragment.AddForce(new Vector2(randomX, randomY), ForceMode2D.Impulse);
        Fragment.AddTorque(randomrotation, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the position of the particle system to match the fragment
        if (Instance != null)
        {
            Instance.transform.position = transform.position;
        }
    }

    void LateUpdate()
    {
        // Get the rotation of the GameObject
        //Quaternion rotation = transform.rotation;

        float velocityDirection = (transform.rotation.z % 360.0f) / (360.0f) * 2.0f * Mathf.PI;
        float xvelocity = Mathf.Cos(velocityDirection);
        float yvelocity = Mathf.Sin(velocityDirection);
        velocitymodule.x = (xvelocity*speed);
        velocitymodule.y = (yvelocity*speed);

        // Set the emission direction and rotation of the ParticleSystem
        //shapeModule.rotation = rotation.eulerAngles;
        //shapeModule.arc = 160f; // Adjust this value based on your needs
    }
}