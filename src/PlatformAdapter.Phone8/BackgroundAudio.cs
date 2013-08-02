using Microsoft.Phone.BackgroundAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformAdapter.Phone8
{
    internal sealed class BackgroundAudio : IBackgroundAudio
    {
        BackgroundAudioPlayer player;

        public BackgroundAudio(BackgroundAudioPlayer player)
        {
            if (null == this.player)
            {
                throw new ArgumentNullException("player", "Must provide an instance of BackgroundAudioPlayer");
            }

            this.player = player;

            this.player.PlayStateChanged += player_PlayStateChanged;
        }

        void player_PlayStateChanged(object sender, EventArgs e)
        {
            if (null != this.PlayStateChanged)
            {
                this.PlayStateChanged(sender, e);
            }
        }

        

        public BackgroundAudio() : this(BackgroundAudioPlayer.Instance)
        {
        }

        public bool CanSeek
        {
            get
            {
                return this.player.CanSeek;
            }
        }

        public double BufferingProgress
        {
            get
            {
                return this.player.BufferingProgress;
            }
        }

        public bool CanPause
        {
            get
            {
                return this.player.CanPause;
            }
        }

        public double Volume
        {
            get
            {
                return this.player.Volume;
            }
            set
            {
                this.player.Volume = value;
            }
        }

        public IAudioTrack CreateAudioTrack()
        {
            throw new NotImplementedException();
        }

        public bool CanChangeRate
        {
            get { return false; }
        }

        public void Play()
        {
            this.player.Play();
        }

        public void Pause()
        {
            this.player.Pause();
        }


        public event EventHandler PlayStateChanged;
    }

    internal sealed class BackgroundAudioTrack : IAudioTrack
    {
        AudioTrack track;

        public BackgroundAudioTrack(AudioTrack track)
        {
            this.track = track;
        }

        public string Album
        {
            get
            {
                return this.track.Album;
            }
            set
            {
                this.track.Album = value;
            }
        }

        public string Artist
        {
            get
            {
                return this.track.Artist;
            }
            set
            {
                this.track.Artist = value;
            }
        }

        public Uri Source
        {
            get
            {
                return this.track.Source;
            }
            set
            {
                this.track.Source = value;
            }
        }

        public Uri AlbumArt
        {
            get
            {
                return this.track.AlbumArt;
            }
            set
            {
                this.track.AlbumArt = value;
            }
        }

        public TimeSpan Duration
        {
            get { return this.track.Duration; }
        }
    }

}
