using UnityEngine;

/// <summary>
/// G�re la notification des �v�nements
/// suite aux clics de la souris, et donne des informations
/// visuelles et num�riques en cons�quence.
/// </summary>
public class ControleurSouris : MonoBehaviour
{

    // TODO input buffer

    /// <summary>
    /// Distance des objets affich�s dans la grid.
    /// </summary>
    private const float DistanceElementsVisuels = 100.0f;

    /// <summary>
    /// La cam�ra qui repr�sente pr�cis�ment les coordonn�es du monde.
    /// </summary>
    public Camera cameraReference;

    /// <summary>
    /// Souris �tant affich�e dans le canvas.
    /// </summary>
    public GameObject sourisVirtuelle;

    /// <summary>
    /// Affiche la direction o� souhaite se diriger le joueur.
    /// </summary>
    public LineRenderer affichageDirectionJoueur;

    /// <summary>
    /// Surface pouvant �tre cliqu�e.
    /// </summary>
    private BoxCollider2D ecranHitbox;

    /// <summary>
    /// Logique m�tier pour la souris.
    /// </summary>
    private ControlesSouris controlesSouris;

    private EtatsJeu etatsJeu;
    private Evenements evenements;

    /// <summary>
    /// Initialisation et pr�paration des composants.
    /// </summary>
    private void Start()
    {

        controlesSouris = new ControlesSouris(cameraReference);
        ecranHitbox = GetComponent<BoxCollider2D>();

        // On d�sactive le rendu de la souris avant de commencer.
        sourisVirtuelle.SetActive(false);
        affichageDirectionJoueur.enabled = false;

        etatsJeu = EtatsJeu.GetInstanceEtatsJeu();
        evenements = Evenements.GetInstanceEvenements();
    }

    /// <summary>
    /// Permet de suivre la surface cliquable vers le joueur.
    /// </summary>
    private void Update()
    {

        Vector3 positionCameraJoueur = Camera.main.transform.position;
        Vector3 positionSouris = Input.mousePosition;

        // Suit la grande collision de l'�cran
        ecranHitbox.offset = positionCameraJoueur;

        // N'est pas rendu si la souris est hors de l'�cran.
        if (Screen.safeArea.Contains(positionSouris))
        {

            // Normalisation de la position de la souris et de la cam�ra.
            positionCameraJoueur.z = DistanceElementsVisuels;
            positionSouris.z = DistanceElementsVisuels;

            sourisVirtuelle.transform.position = Camera.main.ScreenToWorldPoint(positionSouris);

            affichageDirectionJoueur.SetPosition(0, sourisVirtuelle.transform.position);
            affichageDirectionJoueur.SetPosition(1, (positionCameraJoueur - sourisVirtuelle.transform.position).normalized
                + positionCameraJoueur);
        }
    }

    /// <summary>
    /// Comportement lorsque le joueur
    /// clique une fois avec la souris.
    /// </summary>
    private void OnMouseDown()
    {
        // TODO
    }

    /// <summary>
    /// Comportement lorsque le joueur
    /// enfonce et glisse la souris.
    /// </summary>
    private void OnMouseDrag()
    {

        controlesSouris.UpdateOnEnfoncement();

        bool estEnfoncementSansGlissement = controlesSouris.EstEnfoncementSansGlissement();
        if (!estEnfoncementSansGlissement && !etatsJeu.SontMouvementsBloquees)
        {
            sourisVirtuelle.SetActive(true);
            affichageDirectionJoueur.enabled = true;
        }

        else if (etatsJeu.SontMouvementsBloquees)
        {
            sourisVirtuelle.SetActive(false);
            affichageDirectionJoueur.enabled = false;
        }

        evenements.CallbackSourisClicEnfonce(estEnfoncementSansGlissement);
    }

    /// <summary>
    /// Comportement lorsque le joueur
    /// relache le clic de la souris.
    /// </summary>
    private void OnMouseUp()
    {

        controlesSouris.UpdateOnRelachement();

        sourisVirtuelle.SetActive(false);
        affichageDirectionJoueur.enabled = false;

        evenements.CallbackSourisClicRelache(controlesSouris.GetVecteurEnfoncement());
    }
}
