using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;

class TCPServer<T>
{
    private TCPServer()
    {

    }

    public static T Connect(String AAddress, UInt16 APort)
    {
        if (channel == null)
        {
            channel = new TcpClientChannel();

            ChannelServices.RegisterChannel(channel, true);
        }

        object[] attrs = { new UrlAttribute("tcp://" + AAddress + ":" + APort + "/" + typeof(T).Name) };

        ObjectHandle H = null;

        for (int i = 100; i > 0; i--)
        {
            try
            {
                System.Threading.Thread.Sleep(100);
                H = Activator.CreateInstance(typeof(T).Name, typeof(T).FullName, attrs);

                return (T)H.Unwrap();
            }
            catch
            {
                H = null;
            }
        }

        throw new Exception("Time out.");
    }

    public static void Dispose()
    {
        ChannelServices.UnregisterChannel(channel);
        channel = null;
    }

    static TcpClientChannel channel = null;
}

class IPCServer<T>
{
    private IPCServer()
    {

    }

    public static T Connect(String APort)
    {
        if (channel != null)
            ChannelServices.UnregisterChannel(channel);

        channel = new IpcClientChannel();

        ChannelServices.RegisterChannel(channel, true);

        object[] attrs = { new UrlAttribute("ipc://" + APort + "/" + typeof(T).Name) };

        ObjectHandle H = null;

        while (H == null)
        {
            try
            {
                H = Activator.CreateInstance(typeof(T).Name, typeof(T).FullName, attrs);
                return (T)H.Unwrap();
            }
            catch
            {
                H = null;
                System.Threading.Thread.Sleep(500);
            }
        }

        throw new Exception("Time out.");
    }

    static IChannel channel = null;
}
