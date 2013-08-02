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
        bool IsPlaying { get; }

        void Play();
        void Pause();

        IAudioTrack CurrentTrack { get; set; }

        event EventHandler PlayStateChanged;
    }

    public interface IAudioTrack
    {
        string Album { get; set; }
        string Artist { get; set; }
        Uri Source { get; set; }
        Uri AlbumArt { get; set; }
        TimeSpan Duration { get; }

        string Title { get; set; }
    }
}
