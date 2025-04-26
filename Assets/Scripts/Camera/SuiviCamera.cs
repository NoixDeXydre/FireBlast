using UnityEngine;

/// <summary>
/// Permet de suivre un GO
/// </summary>
public class SuiviCamera : MonoBehaviour
{

    /// <summary>
    /// Le GameObject � suivre
    /// </summary>
    public Transform objetSuivi;

    /// <summary>
    /// Met � jour la position de la cam�ra par rapport � l'objet suivi.
    /// </summary>
    void LateUpdate()
    {

        Vector3 positionFinale = objetSuivi.position;

        // On garde le Z de la cam�ra pour �viter des probl�mes de perspective.
        positionFinale.z = transform.position.z;

        transform.position = positionFinale;
    }
}