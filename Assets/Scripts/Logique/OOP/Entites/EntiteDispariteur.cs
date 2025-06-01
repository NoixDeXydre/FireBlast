using UnityEngine;

/// <summary>
/// Permet de faire dispara�tre une entit� 
/// au bout d'une certaine p�riode.
/// </summary>
public class EntiteDispariteur
{

    /// <summary>
    /// Dur�e en seconde avant que l'objet ne disparaisse.
    /// </summary>
    private float periodeVie;

    /// <summary>
    /// Initialise le composant avec
    /// l'entit� concern�e et sa p�riode de vie.
    /// </summary>
    /// <param name="periodeVie">Dur�e de vie en secondes</param>
    public EntiteDispariteur(float periodeVie)
    {
        this.periodeVie = periodeVie;
    }

    /// <param name="nouvellePeriodeVie">Nouvelle p�riode de vie</param>
    public void SetPeriodeVie(float nouvellePeriodeVie)
    {
        periodeVie = nouvellePeriodeVie;
    }    
    
    /// <returns>La p�riode de vie restante</returns>
    public float GetPeriodeVie()
    {
        return periodeVie;
    }
    
    /// <returns>True si la p�riode de vie est de 0, sinon false</returns>
    public bool IsPeriodeVieTerminee() {
        return periodeVie <= .0f;
    }

    /// <summary>
    /// Met � jour le timer pour effectuer la destruction de l'objet
    /// avec le temps demand�.
    /// </summary>
    public void Update()
    {

        periodeVie -= Time.deltaTime;
        if (periodeVie <= .0f)
        {
            periodeVie = .0f;
        }
    }
}
