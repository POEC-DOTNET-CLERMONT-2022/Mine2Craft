# Mine2Craft

## Description du projet

En tant que grand fan de jeux-vidéos et du jeu **Minecraft**,
nous étions frustrés durant nos premières heures de jeu à 
chercher comment faire nos premiers items. 

Il est vrai que maintenant, dans le jeu, le joueur 
a accès à un gestionnaire de craft mais il est beaucoup 
trop restrictif. Il faut avoir les objets necessaires pour
crafter l'item dans l'inventaire ou l'avoir déjà crafter 
pour le voir apparaître.

On a donc eu l'idée de créer une application qui centralise
tous les crafts du jeu pour aider les nouveaux comme les
anciens joueur. Il existe déjà un site qui fait la même
chose mais on veut essayer de faire mieux, avec des
recherches plus simplifiées et intuitives.

## Description des applications

### Gestion des utilisateurs

Les rôles sont répartie sur trois niveaux avec différentes
fonctionnalité et pouvoir :
- Utilisateur simple : c'est le rôle de base à la création
d'un utilisateur, il peut simplement consulter les crafts
présent sur l'application.
- Les modérateurs : leur rôle est plus avancé que celui
des utilisateurs simple, car dans l'application ils peuvent
faire toutes les opérations sur les crafts (ajout, suppresion,
modification).
- Les administrateurs : le rôle que peut d'utilisateur aura,
il a un accès à une interface web dans laquelle il peut gérer
tous les autres utilisateurs.

### Application lourde

L'application lourde est développé en **C#** avec **WPF**
et une api **ASP.NET**.

Du côté graphique il y a une page de connexion qui ammène
sur une page de navigation entre toutes les parties, après
une connexion réussi. Ensuite l'application se sépare entre
quatre pages bien distinctes, dont deux qui ne sont pas
accessible à des utilisateurs de base.

Il y a deux pages de consultation, une qui permet de consulter
les crafts sur une table de craft et l'autre les résultats
de la cuisson des items dans un four.

Les deux pages de gestion, servent pour gérer les items d'une part
et les items complets de l'autre. On a décidé de séparer les deux
car les comportements sont assez différents.

### Application web

L'application web est uniquement accessible pour les administrateurs
et contient un table html avec la liste de tous les utilisateurs
enregistrés dans l'application et avec la possibilité de modifier
uniquement leur rôle ou de les supprimer.