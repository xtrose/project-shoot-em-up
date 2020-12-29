




// Namespace
namespace MyFirstGame
{





    // Klasse der Gegnergruppen, die Powerups erzeugen
    class ClassEnemyGroups
    {
        // Variabeln erstellen
        public int ID { get; set; }
        public int killsForPowerUp { get; set; }
        public string powerUp { get; set; }
        public int kills = 0;
        public bool compleded = false;

        // In die Liste hinzufügen
        public ClassEnemyGroups(int ID, int killsForPowerUp, string powerUp)
        {
            this.ID = ID;
            this.powerUp = powerUp;
            this.killsForPowerUp = killsForPowerUp;
        }
    }
}
