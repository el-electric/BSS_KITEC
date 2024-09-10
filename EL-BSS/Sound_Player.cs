using EL_BSS.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM = System.Media;

namespace EL_BSS
{
    public class Sound_Player
    {
        public async void play_Sound(bool loop)
        {
            /*string strFilePath = string.Empty;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "WAV 파일 선택";
            ofd.FileName = "";
            ofd.Filter = "bin파일 (*.wav) | *.wav; | 모든 파일 (*.*) | *.*";

            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string fileFullName = ofd.FileName;
                // string fileFullName = global::EL_BSS.Properties.Resources.
                string fileFullName = "EL_BSS.Resources.221085beep.wav";
                playWaveFile(fileFullName, false);
            }*/

            //Stream audioStream = new MemoryStream(Properties.Resources.beep);
            //string fileFullName = global::EL_BSS.Properties.Resources.beep;
            playWaveFile(loop);
        }

        public void Stop_play()
        {
            _SoundPlayer.Stop();
            _SoundPlayer.Dispose();

        }

        SM.SoundPlayer _SoundPlayer;

        public void playWaveFile(string filePath, bool playlooping)
        {
            if (_SoundPlayer != null)
            {
                _SoundPlayer.Stop();
                _SoundPlayer.Dispose();
                _SoundPlayer = null;
            }

            /*if (string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }*/

            _SoundPlayer = new SM.SoundPlayer(filePath);

            if (playlooping)
            {
                _SoundPlayer.PlayLooping();
            }
            else
            {
                _SoundPlayer.Play();
            }
        }

        public void playWaveFile(bool playlooping)
        {
            if (_SoundPlayer != null)
            {
                _SoundPlayer.Stop();
                _SoundPlayer.Dispose();
            }

            /*if (string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }*/

            _SoundPlayer = new SM.SoundPlayer(Properties.Resources.beep);

            if (playlooping)
            {
                _SoundPlayer.PlayLooping();
            }
            else
            {
                _SoundPlayer.Play();
            }
        }
    }
}
