using UnityEngine;

/// <summary>
/// Permet de faire disparaître une entité 
/// au bout d'une certaine période.
/// </summary>
public class DisparitionEntite
{

    /// <summary>
    /// Durée en seconde avant que l'objet ne disparaisse.
    /// </summary>
    private float periodeVie;

    /// <summary>
    /// Entité qui va disparaître dans le temps imparti.
    /// </summary>
    private readonly GameObject entiteADisparaitre;

    /// <summary>
    /// Initialise le composant avec
    /// l'entité concernée et sa période de vie.
    /// </summary>
    /// <param name="entiteADisparaitre">Objet devant disparaître</param>
    /// <param name="periodeVie">Durée de vie en secondes</param>
    public DisparitionEntite(GameObject entiteADisparaitre, float periodeVie)
    {
        this.periodeVie = periodeVie;
        this.entiteADisparaitre = entiteADisparaitre;
    }

    /// <summary>
    /// Met à jour le timer pour effectuer la destruction de l'objet
    /// avec le temps demandé.
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
