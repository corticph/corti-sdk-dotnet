namespace CortiApi;

[Serializable]
public class CortiApiEnvironment
{
    public static readonly CortiApiEnvironment Eu = new CortiApiEnvironment
    {
        Base = "https://api.eu.corti.app/v2",
        Wss = "wss://api.eu.corti.app/audio-bridge/v2",
        Login = "https://auth.eu.corti.app/realms",
        Agents = "https://api.eu.corti.app",
    };

    public static readonly CortiApiEnvironment Us = new CortiApiEnvironment
    {
        Base = "https://api.us.corti.app/v2",
        Wss = "wss://api.us.corti.app/audio-bridge/v2",
        Login = "https://auth.us.corti.app/realms",
        Agents = "https://api.us.corti.app",
    };

    /// <summary>
    /// URL for the base service
    /// </summary>
    public string Base { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the wss service
    /// </summary>
    public string Wss { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the login service
    /// </summary>
    public string Login { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }

    /// <summary>
    /// URL for the agents service
    /// </summary>
    public string Agents { get;
#if NET5_0_OR_GREATER
        init;
#else
        set;
#endif
    }
}
