using UnityEngine;

public class MatchRotationToParticleEmission : MonoBehaviour
{
    public ParticleSystem particleSystemComponent;
    private ParticleSystem.ShapeModule shapeModule;

    void Start()
    {
        // Get the ParticleSystem component attached to this GameObject
        particleSystemComponent = GetComponent<ParticleSystem>();

        // Get the ShapeModule of the ParticleSystem
        shapeModule = particleSystemComponent.shape;

        // Set the emission shape to Cone or Box (depending on your preference)
        // You can adjust the shape settings in the Unity Editor
        // For example, if using a cone shape:
        shapeModule.shapeType = ParticleSystemShapeType.Cone;
    }

    void LateUpdate()
    {
        // Get the rotation of the GameObject
        Quaternion rotation = transform.parent.rotation;

        // Set the emission direction and rotation of the ParticleSystem
        shapeModule.rotation = rotation.eulerAngles;
        shapeModule.arc = 160f; // Adjust this value based on your needs
    }
}