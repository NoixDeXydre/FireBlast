using UnityEngine;

/// <summary>
/// Donne des informations en retour
/// aux clics du joueur.
/// </summary>
public class ControlesSouris
{

    /// <summary>
    /// Référence par rapport à la position
    /// de la souris sur l'écran.
    /// </summary>
    private readonly Camera cameraReferenceMonde;

    /// <summary>
    /// Marge dans laquelle il n'est pas encore considéré
    /// que le joueur glisse sa souris.
    /// </summary>
    private readonly Vector2 margeGlissementNonNul = new(2.0f, 1.0f);

    /// <summary>
    /// Position de la souris lorsque le joueur
    /// commence à enfoncer et glisser la souris.
    /// </summary>
    private Vector2 positionDebutEnfoncement;

    /// <summary>
    /// Position de la souris lorsque le joueur
    /// termine d'enfoncer et glisser la souris.
    /// </summary>
    private Vector2 positionFinEnfoncement;

    /// <summary>
    /// Actif si le joueur glisse la souris.
    /// </summary>
    private bool estEnfonce;

    /// <summary>
    /// Initialise une interface pour la souris.
    /// </summary>
    /// <param name="cameraReferenceMonde">Caméra du monde en référence</param>
    public ControlesSouris(Camera cameraReferenceMonde)
    {

        this.cameraReferenceMonde = cameraReferenceMonde;

        positionDebutEnfoncement = Vector2.zero;
        positionFinEnfoncement = Vector2.zero;

        estEnfonce = false;
    }

    /// <returns>
    /// True si le joueur n'a pas glissé suffisamment la souris après enfoncement,
    /// sinon false.
    /// </returns>
    public bool EstEnfoncementSansGlissement()
    {

        Vector2 differencePositionSourisGlissement
           = (Vector2)cameraReferenceMonde.ScreenToWorldPoint(Input.mousePosition) - positionDebutEnfoncement;

        return Mathf.Abs(differencePositionSourisGlissement.x) < margeGlissementNonNul.x
            && Mathf.Abs(differencePositionSourisGlissement.y) < margeGlissementNonNul.y;
    }

    /// <returns>
    /// Un vecteur pointant dans la direction 
    /// où le joueur a glissé la souris.
    /// </returns>
    public Vector2 GetVecteurEnfoncement()
    {

        // Si le joueur n'a pas glissé suffisamment...
        if (EstEnfoncementSansGlissement())
        {
            return Vector2.zero;
        }

        return positionFinEnfoncement;
    }

    /// <summary>
    /// Met à jour la position de la souris
    /// lors d'un glissement de la souris.
    /// </summary>
    public void UpdateOnEnfoncement()
    {

        if (!estEnfonce)
        {

            positionDebutEnfoncement = cameraReferenceMonde.ScreenToWorldPoint(Input.mousePosition);
            positionFinEnfoncement = Vector2.zero;

            estEnfonce = true;
        }
    }

    /// <summary>
    /// Met à jour la position de la souris
    /// lors d'un relâchement du clic de la souris.
    /// </summary>
    public void UpdateOnRelachement()
    {
        estEnfonce = false;
        positionFinEnfoncement = cameraReferenceMonde.ScreenToWorldPoint(Input.mousePosition);
    }
}
