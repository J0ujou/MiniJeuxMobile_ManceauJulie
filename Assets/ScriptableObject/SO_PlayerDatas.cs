using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "SO_PlayerDatas", menuName = "Scriptable Objects/SO_PlayerDatas")]
public class SO_PlayerDatas : ScriptableObject
{
    //données existantes
    public string Name;
    public int Score;
    public int Level;
    
    //listes highscores
    public List<HighscoreEntry> highscoresRNJ = new List<HighscoreEntry>();
    public List<HighscoreEntry> highscoresGNW = new List<HighscoreEntry>();
    public List<HighscoreEntry> highscoresSG = new List<HighscoreEntry>();
    
    private SaveController saveSystem;
    private const int nbMaxHighscore = 10;

    public void LoadDatas()
    {
        CheckSaveSystem();
        // utiliser fonction de savesystem pour load les datas
        // elle renvoie des playersdatas
        PlayerDatas datas = saveSystem.Load();
        // donc je dois les affecter aux variables de mon scriptable object
        Name = datas.Name;
        Score = datas.Score;
        Level = datas.Level;
        highscoresRNJ = datas.highscoresRNJ;
        highscoresGNW = datas.highscoresGNW;
        highscoresSG = datas.highscoresSG;
    }
    

    public void SaveDatas()
    {
        CheckSaveSystem();
        // pour utiliser la fonction save de ma savesystem j'ai besoin de playerdatas
        // je dois créer un playerdatas à partir de mon SO
        PlayerDatas datas  = new PlayerDatas();
        datas.Name = Name;
        datas.Score = Score;
        datas.Level = Level;
        datas.highscoresRNJ = highscoresRNJ;
        datas.highscoresGNW = highscoresGNW;
        datas.highscoresSG = highscoresSG;
        // j'envoie ca à la fonction de savesystem
        saveSystem.Save(datas);
    }
    
        /// Ajoute un nouveau score au tableau des highscores d'un jeu spécifique
    /// </summary>
    public void AddHighscore(string gameName, string playerName, int scoreValue)
    {
        // Créer une nouvelle entrée
        HighscoreEntry newEntry = new HighscoreEntry(playerName, scoreValue);
        
        // Récupérer la liste correspondant au jeu
        List<HighscoreEntry> targetList = GetHighscoreList(gameName);
        
        if (targetList != null)
        {
            // Ajouter le score
            targetList.Add(newEntry);
            
            // Trier par score décroissant (du plus grand au plus petit)
            targetList.Sort((a, b) => b.Score.CompareTo(a.Score));
            
            // Garder seulement le top 10
            if (targetList.Count > nbMaxHighscore)
            {
                targetList.RemoveRange(nbMaxHighscore, targetList.Count - nbMaxHighscore);
            }
            
            // Réassigner la liste triée
            //SetHighscoreList(gameName, targetList);
            
            // Sauvegarder automatiquement
            SaveDatas();
            Debug.Log($"Highscore ajouté pour {gameName} : {playerName} - {scoreValue}. Total: {targetList.Count} entrées");
        }
    }
        
    /// Vérifie si un score est suffisant pour entrer dans le top 10
    public bool IsHighscore(string gameName, int scoreValue)
    {
        List<HighscoreEntry> targetList = GetHighscoreList(gameName);
        
        if (targetList == null) return false;
        
        // Si moins de 10 entrées, c'est toujours un highscore
        if (targetList.Count < nbMaxHighscore) return true;
        
        // Sinon, vérifier si le score est meilleur que le 10ème
        return scoreValue > targetList[targetList.Count - 1].Score;
    }
    
    /// Récupère la liste des highscores pour un jeu donné
    public List<HighscoreEntry> GetHighscoreList(string gameName)
    {
        switch (gameName)
        {
            case "RunNJump":
                return highscoresRNJ;
            case "GameNWatch":
                return highscoresGNW;
            case "SuikaGame":
                return highscoresSG;
            default:
                Debug.LogWarning($"Nom de jeu inconnu : {gameName}");
                return null;
        }
    }

    private void SetHighscoreList(string gameName, List<HighscoreEntry> newList)
    {
        switch (gameName)
        {
            case "RunNJump":
                highscoresRNJ = newList;
                break;
            case "GameNWatch":
                highscoresGNW = newList;
                break;
            case "SuikaGame":
                highscoresSG = newList;
                break;
        }
    }

    private void CheckSaveSystem()
    {
        // vérifier si savesystem contient un objet du type savesystem (qlqchose dedans??)
        if (saveSystem == null)
        {
            // si rien , j'en instancie un (créer)
            saveSystem = new SaveController();
        }

    }
}
