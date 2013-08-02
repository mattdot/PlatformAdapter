using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlatformAdapter
{
    /// <summary>
    /// we should use a real dependency injection framework/implementation or MEF.  This is a hack
    /// </summary>
    public class Platform
    {
        private static readonly Platform current = new Platform(new SimpleServiceLocator());
        

        public static void Configure(IServiceLocator locator)
        {
        }

        public static Platform Current
        {
            get
            {
                return Platform.current;
            }
        }

        private Platform(IServiceLocator locator)
        {
            this.Locator = locator;
        }

        private IServiceLocator locator;

        public IServiceLocator Locator
        {
            get
            {
                return this.locator;
            }
            set
            {
                if (null == value)
                {
                    throw new InvalidOperationException("Can't set the locator to null");
                }

                this.locator = value;
            }
        }

        private IBackgroundAudio bkgAudio;

        /// <summary>
        /// 
        /// </summary>
        public IBackgroundAudio BackgroundAudio
        {
            get
            {
                if (null == this.bkgAudio)
                {
                    this.bkgAudio = this.locator.Resolve<IBackgroundAudio>();
                }

                return this.bkgAudio;
            }
        }
    }
}
