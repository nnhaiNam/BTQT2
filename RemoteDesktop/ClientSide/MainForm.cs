using System.Drawing.Imaging;
using System.Net.Http;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class MainForm : Form
    {
        private TcpClient client;
        private NetworkStream mainStream;

        private  Thread GetImage;

        private bool isGetImageRunning = false;

        private CancellationTokenSource cts;

        public MainForm()
        {
            client = new TcpClient();
          // GetImage = new Thread(StartReceivingImages);
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(textBoxPort.Text);
                client.Connect(textBoxIP.Text, port);
                mainStream = client.GetStream();
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonConnect.Enabled = false;
                buttonConnect.Text = "Connected";
            }
            catch
            {
                MessageBox.Show("Lỗi không thể kết nối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private async void buttonTakeScreen_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                //mainStream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
                writer.WriteLine("SCREENSHOT");

                /* BinaryReader binareader = new BinaryReader(stream);


                 int imageSize = binareader.ReadInt32();
                 byte[] imageBytes = binareader.ReadBytes(imageSize);
                 MessageBox.Show("da gui thong diep");
                 using (MemoryStream ms = new MemoryStream(imageBytes))
                 {

                     Image image = Image.FromStream(ms); // Create the image object first to catch errors                        

                 }*/


                //test
                
                using (StreamReader reader = new StreamReader(mainStream, leaveOpen: true))
                {
                    
                    string base64Image = await reader.ReadLineAsync(); // Read one line at a time

                    MessageBox.Show("client go here!");
                    if (!string.IsNullOrEmpty(base64Image))
                    {

                        try
                        {
                            byte[] imageBytes = Convert.FromBase64String(base64Image);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {



                                Image image = Image.FromStream(ms); // Create the image object first to catch errors
                                /*pictureBox1.Invoke((MethodInvoker)(() =>
                                {
                                    pictureBox1.Image = image;
                                    
                                }));*/
                                listBox1.Invoke(new MethodInvoker(() =>
                                {
                                    listBox1.Items.Add("receive complete !!");
                                }));

                                FormScreenShot formScreenShot = new FormScreenShot(imageBytes);
                                formScreenShot.Show();

                            }
                        }
                        catch (Exception ex)
                        {
                            listBox1.Invoke(new MethodInvoker(() =>
                            {
                                listBox1.Items.Add($"Error receiving image: {ex.Message}");
                            }));
                        }
                    }
                }    
                



               /* FormScreenShot formScreenShot = new FormScreenShot(imageBytes);
                formScreenShot.Show();*/
            }
            catch (Exception ex)
            {
                listBox1.Invoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Add($"Error receiving image: {ex.Message}");
                }));
            }
            /* try
             {
                 NetworkStream stream = client.GetStream();
                 StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
                 writer.WriteLine("SCREENSHOT");

                 StreamReader reader = new StreamReader(stream);
                 string base64Image = reader.ReadLine();

                 if (!string.IsNullOrEmpty(base64Image))
                 {                 

                     byte[] imageBytes = Convert.FromBase64String(base64Image);
                     using (MemoryStream ms = new MemoryStream(imageBytes))
                     {

                         Image image = Image.FromStream(ms); // Create the image object first to catch errors                        

                     }


                     FormScreenShot formScreenShot = new FormScreenShot(imageBytes);
                     formScreenShot.Show();
                 }
                 else
                 {
                     throw new Exception("Received empty base64 image string.");
                 }
             }
             catch (Exception ex)
             {
                 listBox1.Invoke(new MethodInvoker(() =>
                 {
                     listBox1.Items.Add($"Error receiving image: {ex.Message}");
                 }));
             }*/



        }

        private async void buttonTakeScreen_ClickTest(object sender, EventArgs e)
        {
            try
            {
            
                NetworkStream stream = client.GetStream();              
                StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
                StreamReader reader1 = new StreamReader(stream);
                //await writer.WriteLineAsync("SCREENSHOT");
                 writer.WriteLine("SCREENSHOT");
                

                /* listBox1.Invoke(new MethodInvoker(() =>
                 {
                     listBox1.Items.Add($"{cmd}");
                 }));

                 if(cmd!="BEGIN")
                 {
                     return;
                 }  */
                //

               /* string? cmd = null;
                await cmd = reader1.ReadLineAsync();*/
               string cmd=  reader1.ReadLine();


                listBox1.Invoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Add($"{cmd}");
                }));

                if (cmd != "BEGIN")
                {
                    MessageBox.Show("Lỗi,Vui lòng thử lại!");
                    string base64Image = null;
                    using (StreamReader reader = new StreamReader(mainStream, leaveOpen: true))
                    {
                         base64Image =  reader.ReadLine();
                    }

                    //
                    while(base64Image!="BEGIN")
                    {
                        using (StreamReader reader = new StreamReader(mainStream, leaveOpen: true))
                        {
                            writer.WriteLine("SCREENSHOT");
                            base64Image =  reader.ReadLine();
                            listBox1.Invoke(new MethodInvoker(() =>
                            {
                                listBox1.Items.Add($"thừa: {base64Image}");
                            }));
                            
                        }
                    }    
                    //return;

                }
                //







                //test

                using (StreamReader reader = new StreamReader(mainStream, leaveOpen: true))
                {

                    string base64Image = await reader.ReadLineAsync(); // Read one line at a time

                    //MessageBox.Show("client go here! ");

                    if (!string.IsNullOrEmpty(base64Image))
                    {

                        try
                        {
                            byte[] imageBytes = Convert.FromBase64String(base64Image);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {



                                Image image = Image.FromStream(ms); // Create the image object first to catch errors
                               
                                listBox1.Invoke(new MethodInvoker(() =>
                                {
                                    listBox1.Items.Add("receive complete !!");
                                }));

                                FormScreenShot formScreenShot = new FormScreenShot(imageBytes);
                                formScreenShot.Show();

                            }
                        }
                        catch (Exception ex)
                        {
                            listBox1.Invoke(new MethodInvoker(() =>
                            {
                                listBox1.Items.Add($"Error receiving image take screen: {ex.Message}");
                            }));

                        }
                    }
                }



            }
            catch (Exception ex)
            {
                listBox1.Invoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Add($"Error receiving image take screen: {ex.Message}");
                }));

                
            }
            



        }

        private void buttonViewScreen_Click(object sender, EventArgs e)
        {
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

            writer.WriteLine("VIEWSCREEN");        
            /* GetImage = new Thread(StartReceivingImages);
             GetImage.Start();*/

            StartReceivingImages();


        }
        private  void StartReceivingImages()
        {
            // Task.Run(async () => await ReceiveImageAsync());

            cts = new CancellationTokenSource();
            Task.Run(async () => await ReceiveImageAsync(cts.Token));
            
        }


        private async Task ReceiveImageAsync(CancellationToken token)
        {
            
            mainStream = client.GetStream();
            using (StreamReader reader = new StreamReader(mainStream, leaveOpen: true))
            {
                while (!token.IsCancellationRequested)
                {
                   /* if(token.IsCancellationRequested)
                    {
                        break;
                    }  */  
                  /*  listBox1.Invoke(new MethodInvoker(() =>
                    {
                        listBox1.Items.Add("Countine");
                    }));*/
                    string base64Image = await reader.ReadLineAsync(); // Read one line at a time

                    if (!string.IsNullOrEmpty(base64Image))
                    {

                        try
                        {
                            byte[] imageBytes = Convert.FromBase64String(base64Image);
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {



                                Image image = Image.FromStream(ms); // Create the image object first to catch errors
                                pictureBox1.Invoke((MethodInvoker)(() =>
                                {
                                    pictureBox1.Image = image;
                                    listBox1.Invoke(new MethodInvoker(() =>
                                    {
                                        listBox1.Items.Add("receive complete screen!!");
                                    }));
                                }));

                                //formViewScreen.SetImage(image);


                            }
                        }
                        catch (Exception ex)
                        {
                            listBox1.Invoke(new MethodInvoker(() =>
                            {
                                listBox1.Items.Add($"Error receiving image view screen: {ex.Message}");
                            }));
                        }
                    }
                }


                

                listBox1.Invoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Add("Exit");
                }));
            }


        }


        private  void button1_Click(object sender, EventArgs e)
        {

          
            try
            {
               

                if (cts != null)
                {
                    cts.Cancel();
                    cts = null; // Allow the cancellation token source to be recreated
                    listBox1.Invoke(new MethodInvoker(() =>
                    {
                        listBox1.Items.Add("After Click");
                    }));
                    
                } 

                MessageBox.Show("Pause complete!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);  
                
                    
                NetworkStream stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

                writer.WriteLine("STOPSCREEN");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"Error stopping image receiving: {ex.Message}");
            }


        }
    }
}
