using UnityEngine;

/// <summary>
/// Donne des informations en retour
/// aux clics du joueur.
/// </summary>
public class ControlesSouris
{

    /// <summary>
    /// R�f�rence par rapport � la position
    /// de la souris sur l'�cran.
    /// </summary>
    private Camera cameraReferenceMonde;

    /// <summary>
    /// Position de la souris lorsque le joueur
    /// commence � enfoncer et glisser la souris.
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
    /// <param name="cameraReferenceMonde">Cam�ra du monde en r�f�rence</param>
    public ControlesSouris(Camera cameraReferenceMonde)
    {

        this.cameraReferenceMonde = cameraReferenceMonde;

        positionDebutEnfoncement = new Vector2(.0f, .0f);
        positionFinEnfoncement = new Vector2(.0f, .0f);

        estEnfonce = false;
    }

    /// <returns>
    /// True si le joueur n'a pas gliss� la souris apr�s enfoncement,
    /// sinon false
    /// </returns>
    public bool EstEnfoncementSansGlissement()
    {
        Vector2 directionGlissement = GetVecteurEnfoncement();
        return directionGlissement.x == 0 && directionGlissement.y == 0;
    }

    /// <returns>
    /// Un vecteur pointant dans la direction 
    /// o� le joueur a gliss� la souris.
    /// </returns>
    public Vector2 GetVecteurEnfoncement()
    {

        float positionX = positionFinEnfoncement.x - positionDebutEnfoncement.x;
        float positionY = positionFinEnfoncement.y - positionDebutEnfoncement.y;

        return new Vector2(positionX, positionY);
    }

    /// <summary>
    /// Met � jour la position de la souris
    /// lors d'un glissement de la souris.
    /// </summary>
    public void UpdateOnEnfoncement()
    {

        if (!estEnfonce)
        {
        
            positionDebutEnfoncement.x = Input.mousePosition.x;
            positionDebutEnfoncement.y = Input.mousePosition.y;

            positionDebutEnfoncement = cameraReferenceMonde.ScreenToWorldPoint(positionDebutEnfoncement);

            // On �vite ainsi des erreurs c�t� d�veloppement.
            positionFinEnfoncement.x = positionDebutEnfoncement.x;
            positionFinEnfoncement.y = positionDebutEnfoncement.y;

            estEnfonce = true;
        }
    }

    /// <summary>
    /// Met � jour la position de la souris
    /// lors d'un rel�chement du clic de la souris.
    /// </summary>
    public void UpdateOnRelachement()
    {

        if (estEnfonce)
        {
            positionFinEnfoncement.x = Input.mousePosition.x;
            positionFinEnfoncement.y = Input.mousePosition.y;
            estEnfonce = false;

            positionFinEnfoncement = cameraReferenceMonde.ScreenToWorldPoint(positionFinEnfoncement);
        }
    }
}
