﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media;
using Windows.UI.Xaml.Controls;

namespace PlatformAdapter.Windows
{
    internal sealed class BackgroundAudio : IBackgroundAudio
    {
        MediaElement mediaElement;

        public BackgroundAudio(MediaElement mediaElement)
        {
            this.mediaElement = mediaElement;

            this.mediaElement.CurrentStateChanged += OnCurrentStateChanged;
        }

        void OnCurrentStateChanged(object sender, global::Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (null != this.PlayStateChanged)
            {
                this.PlayStateChanged(this, EventArgs.Empty);
            }
        }

        public bool CanSeek
        {
            get
            {
                return this.mediaElement.CanSeek;
            }
        }

        public double BufferingProgress
        {
            get
            {
                return this.mediaElement.BufferingProgress;
            }
        }

        public bool CanPause
        {
            get
            {
                return this.mediaElement.CanPause;
            }
        }

        public double Volume
        {
            get
            {
                return this.mediaElement.Volume;
            }
            set
            {
                this.mediaElement.Volume = value;
            }
        }

        
        public IAudioTrack CreateAudioTrack()
        {
            return null;
        }

        public bool CanChangeRate
        {
            get { return true; }
        }

        public void Play()
        {
            this.mediaElement.Play();
        }

        public void Pause()
        {
            this.mediaElement.Pause();
        }


        public event EventHandler PlayStateChanged;
    }

    internal sealed class BackgroundAudioTrack : IAudioTrack
    {
        
        public string Album
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Artist
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Uri Source
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Uri AlbumArt
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TimeSpan Duration
        {
            get { throw new NotImplementedException(); }
        }
    }
}