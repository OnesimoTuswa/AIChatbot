using System.Media;

namespace AIChatbot
{
    public class VoiceGreeting
    {
        public VoiceGreeting()
        {
            playVoiceGreeting();
        }

        public void playVoiceGreeting()
        {
            SoundPlayer sound = new SoundPlayer(@"C:\\Year2\\SEM1\\PROG\\0330.WAV");
            sound.PlaySync();
        }
    }
}