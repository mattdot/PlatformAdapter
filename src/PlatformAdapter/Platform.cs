using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlatformAdapter
{
    /// <summary>
    /// This is the primary API for the PlatformAdapter framework.
    /// </summary>
    public class Platform
    {
        #region Static Implementation

        private static readonly Platform current = new Platform(new SimpleServiceLocator());
        
        /// <summary>
        /// Gets a reference to the current platform adapter implementation.
        /// </summary>
        public static Platform Current
        {
            get
            {
                return Platform.current;
            }
        }

        /// <summary>
        /// Retrieves an instance of a PlatformAdapter service.
        /// </summary>
        /// <typeparam name="T">A platform adapter interface.</typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return Platform.current.locator.Resolve<T>();
        }

        public static IBackgroundAudio BackgroundAudio
        {
            get
            {
                return Platform.current.backgroundAudio.Value;
            }
        }

        public static ICryptographyAdapter Cryptography
        {
            get
            {
                return Platform.current.cryptography.Value;
            }
        }

        public static IStorageAdapter Storage
        {
            get
            {
                return Platform.current.storage.Value;
            }
        }


        #endregion

        private Platform(IServiceLocator locator)
        {
            this.Locator = locator;
        }

        private IServiceLocator locator;

        private Lazy<IBackgroundAudio> backgroundAudio = new Lazy<IBackgroundAudio>(Platform.Resolve<IBackgroundAudio>);
        private Lazy<ICryptographyAdapter> cryptography = new Lazy<ICryptographyAdapter>(Platform.Resolve<ICryptographyAdapter>);
        private Lazy<IStorageAdapter> storage = new Lazy<IStorageAdapter>(Platform.Resolve<IStorageAdapter>);

        public IServiceLocator Locator
        {
            get
            {
                if (null == this.locator)
                {
                    throw new InvalidOperationException("Platform.Locator must be set before Platform can be used.");
                }

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
    }
}
