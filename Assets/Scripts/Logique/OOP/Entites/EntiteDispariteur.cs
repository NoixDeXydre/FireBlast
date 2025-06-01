using UnityEngine;

/// <summary>
/// Permet de faire disparaître une entité 
/// au bout d'une certaine période.
/// </summary>
public class EntiteDispariteur
{

    /// <summary>
    /// Durée en seconde avant que l'objet ne disparaisse.
    /// </summary>
    private float periodeVie;

    /// <summary>
    /// Initialise le composant avec
    /// l'entité concernée et sa période de vie.
    /// </summary>
    /// <param name="periodeVie">Durée de vie en secondes</param>
    public EntiteDispariteur(float periodeVie)
    {
        this.periodeVie = periodeVie;
    }

    /// <param name="nouvellePeriodeVie">Nouvelle période de vie</param>
    public void SetPeriodeVie(float nouvellePeriodeVie)
    {
        periodeVie = nouvellePeriodeVie;
    }    
    
    /// <returns>La période de vie restante</returns>
    public float GetPeriodeVie()
    {
        return periodeVie;
    }
    
    /// <returns>True si la période de vie est de 0, sinon false</returns>
    public bool IsPeriodeVieTerminee() {
        return periodeVie <= .0f;
    }

    /// <summary>
    /// Met à jour le timer pour effectuer la destruction de l'objet
    /// avec le temps demandé.
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
