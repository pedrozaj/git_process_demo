using A35WPFSample.Helpers;
using A35WPFSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace A35WPFSample.Comm
{
    public class FakeSerialPort
    {
        //EVENTS
        internal event EventHandler<PlotDataModel> newInfoObtained;
        internal event EventHandler<ErrorModel> errorOccurred;
        private readonly DispatcherTimer _fakeNewInfoTimer = new DispatcherTimer();


        //SINGLETON PROVIDER
        private static FakeSerialPort _fakeSerialPort;
        private FakeSerialPort()
        {
            _fakeNewInfoTimer.Tick += this.OnFakeNewInfoTimer_OnTick;
            _fakeNewInfoTimer.Interval = new TimeSpan(0, 0, 0, 5, 0); //5 seconds
        }
        public static FakeSerialPort GetInstance()
        {
            return _fakeSerialPort == null ? _fakeSerialPort = new FakeSerialPort() : _fakeSerialPort;
        }


        //TIMER EVENTS
        private void OnFakeNewInfoTimer_OnTick(object sender, object e)
        {
            newInfoObtained?.Invoke(sender, new PlotDataModel());
            //or
            //if (newInfoObtained != null)
            //{
            //    newInfoObtained(wnd, null);
            //}
            errorOccurred?.Invoke(sender, new ErrorModel("Some Cool Error"));
        }


        //EVENT HANDLING
        public void OnSamIsCoolSoHereHeIs(object sender, object e)
        {
            //Yeah he is :)
            
        }
    }
}
