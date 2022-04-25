using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpAvi;
//using Ozeki.Media.MediaHandlers;
using Ozeki.VoIP;
using Ozeki.Media;
//using Ozeki.VoIP.SDK;

namespace SIPCoffee
{
    public partial class Form1 : Form
    {
        Recorder rec;
        private ISoftPhone softPhone;
        private IPhoneLine phoneLine;
      //  private PhoneLineState phoneLineInformation;
        private IPhoneCall call;
        private Microphone microphone = Microphone.GetDefaultDevice();
        private Speaker speaker = Speaker.GetDefaultDevice();
        MediaConnector connector = new MediaConnector();
        PhoneCallAudioSender mediaSender = new PhoneCallAudioSender();
        PhoneCallAudioReceiver mediaReceiver = new PhoneCallAudioReceiver();

        private bool inComingCall;

        public Form1()
        {
            InitializeComponent();
            softPhone = SoftPhoneFactory.CreateSoftPhone(SoftPhoneFactory.GetLocalIP(), 5700, 5750);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //  rec = new Recorder(new RecorderParams("out.avi", 10, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 70));
          //  Console.WriteLine("Press any key to Stop...");
           // Console.ReadKey();

            // Finish Writing
           
        }

        private void InvokeGUIThread(Action action)
        {
            Invoke(action);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            softPhone.IncomingCall += new EventHandler<VoIPEventArgs<IPhoneCall>>(softPhone_inComingCall);
        }

        private void softPhone_inComingCall(object sender, VoIPEventArgs<IPhoneCall> e)
        {
         
             InvokeGUIThread(() => {txt_status.Text=("Callstate changed." + e.Item.CallState.ToString()); });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rec.Dispose();
        }

        private void call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            InvokeGUIThread(() => { txt_status.Text=("Callstate changed." + e.State.ToString()); });
        }
        private void WireUpCallEvents()
        {
            call.CallStateChanged += (call_CallStateChanged);//subscribe our callState event to the object's
        }
        private void WireDownCallEvents()
        {
            call.CallStateChanged -= (call_CallStateChanged);//unsubscribe from the object's callstate
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_add_line_Click(object sender, EventArgs e)
        {
            frm_add_sip_account frm = new frm_add_sip_account();
            frm.Show(this);
       
        }
    }
}
