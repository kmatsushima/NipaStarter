using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rug.Osc;
using System.Threading;

namespace NipaStarter
{

    public class OscManager
    {
        static OscManager _Instance;

        public static OscManager Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new OscManager();
                return _Instance;
            }
        }

        OscReceiver _Receiver;
        Thread _RecevierThread;

        public OscAddressManager AddressManager { get; private set; }

        private OscManager()
        {
            _Receiver = new OscReceiver(28282);
            _RecevierThread = new Thread(new ThreadStart(ReceiveMessage));
            AddressManager = new OscAddressManager();

            _Receiver.Connect();
            _RecevierThread.Start();

        }



        ////////////////////////////////////////////////////////////////////////////////
        ///<summary>
        ///[ROLE] : Receive
        ///[note] : -
        ///</summary> 
        public void ReceiveMessage()
        {
            try
            {
                while (_Receiver.State != OscSocketState.Closed)
                {
					Thread.Sleep(1);
					if (_Receiver.State == OscSocketState.Connected)
                    {
                        OscPacket packet;

                        if (_Receiver.TryReceive(out packet) == false)
                        {
                            continue;
                        }

                        switch (AddressManager.ShouldInvoke(packet))
                        {
                            case OscPacketInvokeAction.Invoke:
                                AddressManager.Invoke(packet);
                                break;
                            case OscPacketInvokeAction.DontInvoke:
                                break;
                            case OscPacketInvokeAction.HasError:
                                break;
                            case OscPacketInvokeAction.Pospone:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception _e)
            {
                //   Logger.Instance.AddLog(LogKind.ManagerSystemEvent, string.Format("OSCエラー: {0}", _e), LogType.SystemTrace);

            }
        }

        internal void Dispose()
        {
            _RecevierThread.Abort();
            _RecevierThread = null;
        }
    }

}
