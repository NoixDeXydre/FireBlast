using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Fait appara�tre les entit�s dans la carte au bon moment,
/// et selon l'�tat du jeu.
/// </summary>
public class ControleurApparitionEntites : MonoBehaviour
{

    /// <summary>
    /// D�lais avant que le jeu regarde les entit�s � faire appara�tre.
    /// </summary>
    private const float TempsAttenteUsine = 1.0f;

    /// <summary>
    /// La map o� les entit�s vont appara�tre.
    /// </summary>
    public Tilemap map;

    private EntitesCreateur usineEntites;
    private MapVirtuelle mapVirtuelle;

    private EntitesGroupePool collectiblesPool;

    private CollectionEntites entitesSrc;

    /// <summary>
    /// Initialise les composants pour rep�rer la map.
    /// </summary>
    private void Start()
    {

        mapVirtuelle = new(map, 3.0f);
        usineEntites = new(mapVirtuelle);

        entitesSrc = Resources.Load<CollectionEntites>(nameof(CollectionEntites));

        collectiblesPool = new(200);
        collectiblesPool.InstancierTypeEntites(3, entitesSrc.collectiblePiece.nom, entitesSrc.collectiblePiece.entite);
        collectiblesPool.InstancierTypeEntites(5, entitesSrc.collectibleTriplePiece.nom, entitesSrc.collectibleTriplePiece.entite);

        // On cr�e le joueur
        usineEntites.CreerEntite(entitesSrc.joueur.entite, mapVirtuelle.GetCentreMap());
        IterationTournageUsine();
    }

    /// <summary>
    /// Nouveau cycle afin de v�rifier les entit�s � cr�er.
    /// </summary>
    private void IterationTournageUsine()
    {
        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 25f, 1.1f));
    }

    private void SousIterationCollectibles()
    {

        GameObject collectible = collectiblesPool.GetInstanceTypeEntiteNonActif(entitesSrc.collectibles.ChoisirEntiteAleatoirement());
        if (collectible != null)
        {
            collectible.transform.position = Aleatoire.ChoisirPointParmisDeuxAxes(mapVirtuelle.GetCoordonneesIntervallesX(), mapVirtuelle.GetCoordonneesIntervallesY());
            collectible.SetActive(true);
        }

        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 10f));
    }
}
