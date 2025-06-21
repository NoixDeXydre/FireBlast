using UnityEngine;
using Zenject;

/// <summary>
/// Défini les dépendances à un injecter dans la scène Jeu.
/// </summary>
public class InstallerJeu : MonoInstaller
{

    /// <summary>
    /// Défini et injecte
    /// </summary>
    public override void InstallBindings()
    {

        // Instancie une map virtuelle afin de connaître les bordures.
        Container.Bind<MapVirtuelle>().FromComponentInHierarchy().AsSingle();

        Container.Bind<EntitesCreateur>().AsSingle();

        // Contrôleurs 
        Container.Bind<ControleurScore>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ControleurTemps>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ControleurVie>().FromComponentInHierarchy().AsSingle();
    }
}