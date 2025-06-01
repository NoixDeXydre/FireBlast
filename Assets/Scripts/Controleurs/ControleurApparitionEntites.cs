using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Fait apparaître les entités dans la carte au bon moment,
/// et selon l'état du jeu.
/// </summary>
public class ControleurApparitionEntites : MonoBehaviour
{

    /// <summary>
    /// Délais avant que le jeu regarde les entités à faire apparaître.
    /// </summary>
    private const float TempsAttenteUsine = 1.0f;

    /// <summary>
    /// La map où les entités vont apparaître.
    /// </summary>
    public Tilemap map;

    private EntitesCreateur usineEntites;
    private MapVirtuelle mapVirtuelle;

    private EntitesGroupePool collectiblesPool;

    private CollectionEntites entitesSrc;

    /// <summary>
    /// Initialise les composants pour repérer la map.
    /// </summary>
    private void Start()
    {

        mapVirtuelle = new(map, 3.0f);
        usineEntites = new(mapVirtuelle);

        entitesSrc = Resources.Load<CollectionEntites>(nameof(CollectionEntites));

        collectiblesPool = new(200);
        collectiblesPool.InstancierTypeEntites(3, entitesSrc.collectiblePiece.nom, entitesSrc.collectiblePiece.entite);
        collectiblesPool.InstancierTypeEntites(5, entitesSrc.collectibleTriplePiece.nom, entitesSrc.collectibleTriplePiece.entite);

        // On crée le joueur
        usineEntites.CreerEntite(entitesSrc.joueur.entite, mapVirtuelle.GetCentreMap());
        IterationTournageUsine();
    }

    /// <summary>
    /// Nouveau cycle afin de vérifier les entités à créer.
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
