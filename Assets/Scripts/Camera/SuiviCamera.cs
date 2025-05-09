using UnityEngine;

/// <summary>
/// Permet de suivre un GO
/// </summary>
public class SuiviCamera : MonoBehaviour
{

    /// <summary>
    /// Taux de fluidite de 0 à 1.
    /// </summary>
    public float fluiditeCamera;

    /// <summary>
    /// Le GameObject à suivre
    /// </summary>
    public Transform objetSuivi;

    private Vector3 positionFinale;

    void Start()
    {
        positionFinale = transform.position;
    }

    /// <summary>
    /// Met à jour la position de la caméra par rapport à l'objet suivi.
    /// </summary>
    void FixedUpdate()
    {
        positionFinale.x = objetSuivi.position.x;
        positionFinale.y = objetSuivi.position.y;

        transform.position = Vector3.Lerp(transform.position, positionFinale, fluiditeCamera);
    }
}