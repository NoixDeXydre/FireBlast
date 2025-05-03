using UnityEngine;

/// <summary>
/// Permet de faire dispara�tre une entit� 
/// au bout d'une certaine p�riode.
/// </summary>
public class DisparitionEntite
{

    /// <summary>
    /// Dur�e en seconde avant que l'objet ne disparaisse.
    /// </summary>
    private float periodeVie;

    /// <summary>
    /// Entit� qui va dispara�tre dans le temps imparti.
    /// </summary>
    private readonly GameObject entiteADisparaitre;

    /// <summary>
    /// Initialise le composant avec
    /// l'entit� concern�e et sa p�riode de vie.
    /// </summary>
    /// <param name="entiteADisparaitre">Objet devant dispara�tre</param>
    /// <param name="periodeVie">Dur�e de vie en secondes</param>
    public DisparitionEntite(GameObject entiteADisparaitre, float periodeVie)
    {
        this.periodeVie = periodeVie;
        this.entiteADisparaitre = entiteADisparaitre;
    }

    /// <summary>
    /// Met � jour le timer pour effectuer la destruction de l'objet
    /// avec le temps demand�.
    /// </summary>
    public void Update()
    {

        periodeVie -= Time.deltaTime;
        if (periodeVie <= 0.0f)
        {
            Object.Destroy(entiteADisparaitre);
        }
    }
}
