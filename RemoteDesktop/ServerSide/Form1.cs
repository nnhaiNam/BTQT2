using System.Drawing.Imaging;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;

namespace ServerSide
{
    public partial class Form1 : Form
    {

        private readonly int port = 8080;
        private TcpListener Server;

        private bool _isSharing = false;
        //private NetworkStream mainStream;

        private Thread listenerThread;

        public Form1()
        {

            InitializeComponent();
        }



        private static byte[] GrabDesktop()
        {
            Rectangle bound = Screen.PrimaryScreen.Bounds;
            Bitmap screenShot = new Bitmap(bound.Width, bound.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(screenShot);
            graphics.CopyFromScreen(bound.X, bound.Y, 0, 0, bound.Size, CopyPixelOperation.SourceCopy);

            using (MemoryStream ms = new MemoryStream())
            {
                screenShot.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }


        private async Task SendImageDesktopAsync(TcpClient tcpClient)
        {

          /*  listBox1.Invoke(new MethodInvoker(() =>
            {
                listBox1.Items.Add("send");
            }));*/
            byte[] imageData = GrabDesktop();
            NetworkStream mainStream = tcpClient.GetStream();

            // Convert the byte array to a base64 string
            string base64Image = Convert.ToBase64String(imageData) + "\n"; // Adding a newline as a delimiter

            // Write the base64 string to the stream
            using (StreamWriter writer = new StreamWriter(mainStream, leaveOpen: true))
            {
                await writer.WriteAsync(base64Image);
                await writer.FlushAsync(); // Ensure the data is sent immediately
            }

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            listenerThread = new Thread(new ThreadStart(StartServer));
            listenerThread.Start();
            buttonStart.Enabled = false;
            buttonStart.Text = "Listenning....";


        }

        private void StartServer()
        {
            Server = new TcpListener(IPAddress.Any, 8080);
            Server.Start();
            while (true)
            {

                TcpClient client = Server.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                clientThread.IsBackground = true;
                clientThread.Start(client);
            }
        }

        /* private void StartListenning()
         {
             while (!tcpClient.Connected)
             {
                 Server.Start();
                 tcpClient = Server.AcceptTcpClient();
             }

         }*/


        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            //test
            StreamWriter writerr = new StreamWriter(stream) { AutoFlush = true };
            timer1.Tick += (s, ev) => Timer1_TickWithTcpClient(s, ev, client);
            while (true)
            {
                try
                {
                    string command = reader.ReadLine();                  
                    if (command == "SCREENSHOT")
                    {
                        /*Bitmap screenshot = CaptureScreen();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            screenshot.Save(ms, ImageFormat.Png);
                            byte[] imageBytes = ms.ToArray();
                           


                            


                            *//* BinaryWriter writer = new BinaryWriter(stream);

                            writer.Write(imageBytes.Length);
                            writer.Write(imageBytes);*//*

                            //test
                            //string base64Image = Convert.ToBase64String(imageBytes);
                            //writer.WriteLine(base64Image);

                        }*/

                        //complete
                        /*writerr.WriteLine("BEGIN");

                        byte[] imageData = GrabDesktop();
                        NetworkStream mainStream = client.GetStream();

                        // Convert the byte array to a base64 string
                        string base64Image = Convert.ToBase64String(imageData) ; // Adding a newline as a delimiter

                        // Write the base64 string to the stream
                        using (StreamWriter writer = new StreamWriter(mainStream, leaveOpen: true))
                        {
                            writer.WriteLine(base64Image);
                            writer.Flush(); // Ensure the data is sent immediately
                        }*/
                        //complete


                       writerr.WriteLine("BEGIN");
                       
                        Bitmap screenshot = CaptureScreen();
                        //writerr.WriteLine("BEGIN");
                        using (MemoryStream ms = new MemoryStream())
                        {
                            screenshot.Save(ms, ImageFormat.Png);
                            byte[] imageBytes = ms.ToArray();
                            NetworkStream mainStream = client.GetStream();

                            // Convert the byte array to a base64 string
                            string base64Image = Convert.ToBase64String(imageBytes); // Adding a newline as a delimiter

                          

                            // Write the base64 string to the stream
                            using (StreamWriter writer = new StreamWriter(mainStream, leaveOpen: true))
                            {
                                writer.WriteLine(base64Image);
                                writer.Flush(); // Ensure the data is sent immediately
                            }
                        }    


                    }
                    else if (command == "VIEWSCREEN")
                    {
                        BeginInvoke((Action)(() =>
                        {
                            _isSharing = true;
                            timer1.Start();
                        }));
                    }
                    else if (command == "STOPSCREEN")
                    {
                        BeginInvoke((Action)(() =>
                        {
                            timer1.Stop();
                            _isSharing = false;                       
                          
                            
                        }));
                    }




                }
                catch
                {

                }
           


            }
            
          

        }
        private Bitmap CaptureScreen()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }
            return bitmap;
        }
     

        private async void Timer1_TickWithTcpClient(object sender, EventArgs e, TcpClient tcpClient)
        {
            //await SendImageDesktopAsync(tcpClient);

            if (_isSharing)
            {
               await SendImageDesktopAsync(tcpClient);
            }

        }

       
        
    }
}
