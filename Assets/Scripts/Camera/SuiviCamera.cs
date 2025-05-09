using UnityEngine;

/// <summary>
/// Permet de suivre un GO
/// </summary>
public class SuiviCamera : MonoBehaviour
{

    /// <summary>
    /// Taux de fluidite de 0 � 1.
    /// </summary>
    public float fluiditeCamera;

    /// <summary>
    /// Le GameObject � suivre
    /// </summary>
    public Transform objetSuivi;

    private Vector3 positionFinale;

    void Start()
    {
        positionFinale = transform.position;
    }

    /// <summary>
    /// Met � jour la position de la cam�ra par rapport � l'objet suivi.
    /// </summary>
    void FixedUpdate()
    {
        positionFinale.x = objetSuivi.position.x;
        positionFinale.y = objetSuivi.position.y;

        transform.position = Vector3.Lerp(transform.position, positionFinale, fluiditeCamera);
    }
}