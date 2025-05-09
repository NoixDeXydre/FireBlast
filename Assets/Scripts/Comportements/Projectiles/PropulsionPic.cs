using UnityEngine;

/// <summary>
/// D�fini le comportement d'un pic.
/// Un pic va simplement se diriger dans la direction
/// dans laquelle elle pointe.
/// </summary>
public class PropulsionPic : MonoBehaviour
{

    /// <summary>
    /// Dur�e du projectile avant de dispara�tre.
    /// </summary>
    public float dureeApparition;

    /// <summary>
    /// Vitesse du projectile.
    /// </summary>
    public float vitesse;

    /// <summary>
    /// Contr�le la disparition de l'objet.
    /// </summary>
    private DisparitionEntite controleurDisparitionEntite;

    /// <summary>
    /// Le projectile � lancer.
    /// </summary>
    private Rigidbody2D projectile;

    /// <summary>
    /// Projette l'entit�
    /// </summary>
    private void Start()
    {

        controleurDisparitionEntite = new DisparitionEntite(gameObject, dureeApparition);
        projectile = gameObject.GetComponent<Rigidbody2D>();

        // Propulse le pic selon �a direction.
        projectile.linearVelocity = transform.up * vitesse;
    }

    /// <summary>
    /// Met � jour le timer pour la disparition de l'entit�.
    /// </summary>
    private void FixedUpdate()
    {
        controleurDisparitionEntite.Update();
    }
}
