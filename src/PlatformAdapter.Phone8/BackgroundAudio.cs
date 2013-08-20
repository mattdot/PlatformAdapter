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
            if (null == player)
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

        public BackgroundAudioTrack Track
        {
            get
            {
                if (null == this.player.Track)
                {
                    return null;
                }

                return new BackgroundAudioTrack(this.player.Track);
            }
            set
            {
                this.player.Track = value.Track;
            }
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
            return new BackgroundAudioTrack();
        }

        public bool CanChangeRate
        {
            get { return false; }
        }


        public event EventHandler PlayStateChanged;


        public bool IsPlaying
        {
            get { return this.player.PlayerState == PlayState.Playing; }
        }

        public IAudioTrack CurrentTrack
        {
            get
            {
                return new BackgroundAudioTrack(this.player.Track);
            }
            set
            {
                this.player.Track = ((BackgroundAudioTrack)value).Track;
            }
        }


        public Task PlayAsync()
        {
            return Task.Run(() => { this.player.Play(); });
        }

        public Task PauseAsync()
        {
            return Task.Run(() => { this.player.Pause(); });
        }
    }

    internal sealed class BackgroundAudioTrack : IAudioTrack
    {
        AudioTrack track;

        public BackgroundAudioTrack(AudioTrack track)
        {
            this.track = track;
        }

        public BackgroundAudioTrack()
        {
            this.track = new AudioTrack();
        }

        internal AudioTrack Track { get { return this.track;  } }

        public string Album
        {
            get
            {
                return this.track.Album;
            }
            set
            {
                this.track.BeginEdit();
                this.track.Album = value;
                this.track.EndEdit();
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
                this.track.BeginEdit();
                this.track.Artist = value;
                this.track.EndEdit();
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
                this.track.BeginEdit();
                this.track.Source = value;
                this.track.EndEdit();
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
                this.track.BeginEdit();
                this.track.AlbumArt = value;
                this.track.EndEdit();
            }
        }

        public TimeSpan Duration
        {
            get { return this.track.Duration; }
        }


        public string Title
        {
            get
            {
                return this.track.Title;
            }
            set
            {
                this.track.BeginEdit();
                this.track.Title = value;
                this.track.EndEdit();
            }
        }
    }

}
