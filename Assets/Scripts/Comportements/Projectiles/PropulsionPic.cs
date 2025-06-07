using UnityEngine;

/// <summary>
/// Défini le comportement d'un pic.
/// Un pic va simplement se diriger dans la direction
/// dans laquelle elle pointe.
/// </summary>
public class PropulsionPic : MonoBehaviour
{

    /// <summary>
    /// Durée du projectile avant de disparaître.
    /// </summary>
    public float dureeApparition;

    /// <summary>
    /// Direction où se dirigera le projectile.
    /// </summary>
    public float angleDirection;

    /// <summary>
    /// Vitesse du projectile.
    /// </summary>
    public float vitesse;

    /// <summary>
    /// Contrôle la disparition de l'objet.
    /// </summary>
    private TimerEcoulement timerEcoulement;

    /// <summary>
    /// Le projectile à lancer.
    /// </summary>
    private Rigidbody2D projectile;

    /// <summary>
    /// Projette l'entité
    /// </summary>
    private void Awake()
    {

        timerEcoulement = new TimerEcoulement(dureeApparition, 0.0f, true); 
        projectile = gameObject.GetComponent<Rigidbody2D>();

        // Propulse le pic selon ça direction.
        Vector3 directionProjectile = Quaternion.Euler(0.0f, angleDirection, 0.0f) * transform.forward;
        projectile.linearVelocity = new Vector2(directionProjectile.x, directionProjectile.z).normalized * vitesse;
    }

    private void OnDisable()
    {
        timerEcoulement.ResetTimer();
        timerEcoulement.SetPauseTimer(true);
    }

    private void OnEnable()
    {
        timerEcoulement.SetPauseTimer(false);
    }

    /// <summary>
    /// Met à jour le timer pour la disparition de l'entité.
    /// </summary>
    private void FixedUpdate()
    {

        if (timerEcoulement.Update())
        {
            gameObject.SetActive(false);
        }            
    }
}
