using Microsoft.Xna.Framework.Audio;





// Namespace
namespace MyFirstGame
{





    // Klasse der Boss Sounds
    class ClassBossSounds
    {
        // Variableln
        public SoundEffect soundeffect { get; set; }

        // Zur Liste hinzuf�gen
        public ClassBossSounds(SoundEffect soundeffect)
        {
            this.soundeffect = soundeffect;
        }
    }
}
