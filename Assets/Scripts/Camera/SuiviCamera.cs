using UnityEngine;

/// <summary>
/// Permet de suivre un GO
/// </summary>
public class SuiviCamera : MonoBehaviour
{

    /// <summary>
    /// Le GameObject à suivre
    /// </summary>
    public Transform objetSuivi;

    /// <summary>
    /// Met à jour la position de la caméra par rapport à l'objet suivi.
    /// </summary>
    void LateUpdate()
    {

        Vector3 positionFinale = objetSuivi.position;

        // On garde le Z de la caméra pour éviter des problèmes de perspective.
        positionFinale.z = transform.position.z;

        transform.position = positionFinale;
    }
}