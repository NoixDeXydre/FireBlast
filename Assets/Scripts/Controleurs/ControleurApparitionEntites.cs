using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Fait appara�tre les entit�s dans la carte au bon moment,
/// et selon l'�tat du jeu.
/// </summary>
public class ControleurApparitionEntites : MonoBehaviour
{

    /// <summary>
    /// La map o� les entit�s vont appara�tre.
    /// </summary>
    public Tilemap map;

    private EntitesCreateur usineEntites;
    private MapVirtuelle mapVirtuelle;

    private EntitesGroupePool pool;

    private CollectionEntites entitesSrc;

    /// <summary>
    /// Initialise les composants pour rep�rer la map.
    /// </summary>
    private void Start()
    {

        mapVirtuelle = new(map, 3.0f);
        usineEntites = new(mapVirtuelle);

        entitesSrc = Resources.Load<CollectionEntites>(nameof(CollectionEntites));

        pool = new(200);

        // Cache des entit�s

        foreach(Entite entite in entitesSrc.datasets)
        {
            pool.InstancierTypeEntites(entite.nombreMaxApparition, entite.nomEntite, entite.entite);
        }

        // On cr�e le joueur
        usineEntites.CreerEntite(entitesSrc.datasetJoueur.entite, mapVirtuelle.GetCentreMap());
        IterationTournageUsine();
    }

    /// <summary>
    /// Nouveau cycle afin de v�rifier les entit�s � cr�er.
    /// </summary>
    private void IterationTournageUsine()
    {
        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 25f, 1.1f));
        Invoke(nameof(SousIterationEnnemis), Aleatoire.ChoisirNombreParmisPlage(10f, 30f, 0.9f));
    }

    private void SousIterationCollectibles()
    {

        GameObject collectible = pool.GetInstanceTypeEntiteNonActif(entitesSrc.groupeCollectibles.ChoisirEntiteAleatoirement());
        if (collectible != null)
        {
            collectible.transform.position = Aleatoire.ChoisirPointParmisDeuxAxes(mapVirtuelle.GetCoordonneesIntervallesX(), mapVirtuelle.GetCoordonneesIntervallesY());
            collectible.SetActive(true);
        }

        Invoke(nameof(SousIterationCollectibles), Aleatoire.ChoisirNombreParmisPlage(5f, 10f));
    }

    private void SousIterationEnnemis()
    {

        GameObject collectible = pool.GetInstanceTypeEntiteNonActif(entitesSrc.groupeEnnemis.ChoisirEntiteAleatoirement());
        if (collectible != null)
        {
            collectible.transform.position = Aleatoire.ChoisirPointParmisDeuxAxes(mapVirtuelle.GetCoordonneesIntervallesX(), mapVirtuelle.GetCoordonneesIntervallesY());
            collectible.SetActive(true);
        }

        Invoke(nameof(SousIterationEnnemis), Aleatoire.ChoisirNombreParmisPlage(2f, 7f));
    }
}
