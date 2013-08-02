using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlatformAdapter
{
    public interface IBackgroundAudio
    {
        IAudioTrack CreateAudioTrack();

        bool CanSeek { get; }
        double BufferingProgress { get; }
        bool CanPause { get; }
        double Volume { get; set; }
        bool CanChangeRate { get; }

        void Play();
        void Pause();

        event EventHandler PlayStateChanged;
    }

    public interface IAudioTrack
    {
        string Album { get; set; }
        string Artist { get; set; }
        Uri Source { get; set; }
        Uri AlbumArt { get; set; }
        TimeSpan Duration { get; }
    }

    public class BackgroundAudioTrack
    {
        public string Album { get; set; }
        public string Artist { get; set; }
        public Uri Source { get; set; }
        public Uri AlbumArt { get; set; }
        public TimeSpan Duration { get; private set; }

    }
}
