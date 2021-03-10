using Microsoft.AspNetCore.SignalR.Client;
using RealTimePOS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealTimePOS
{
    public partial class Form1 : Form
    {
        readonly HubConnection connection;
        private readonly int[] ventas = { 1, 1, 1, 1, 2, 3, 4, 5, 6, 7 };
        private readonly Random random = new Random();
        public Form1()
        {
            InitializeComponent();

            //Targets signalR endpoint
            connection = new HubConnectionBuilder()
             .WithUrl("http://CA214063:5001/ChartHub")
             .Build();
            //Every time signalR connection gets closed this section gonna try to connect every 3 secs
            connection.Closed += async (error) =>
            {
                Thread.Sleep(3000);
                await connection.StartAsync();
            };
            //Opens up the connection if its disconnected
            if (connection.State == HubConnectionState.Disconnected)
                connection.StartAsync().GetAwaiter();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            int id = random.Next(0, ventas.Length);
            label1.Text = ventas[id].ToString();

            try
            {
                //Go to register business id at SignalR
                await connection.InvokeAsync("Connect", ventas[id]);

                //This method listen to the communication channel to catch messages            
                connection.On<bool, int>("Done", async (test, test1) =>
                {
                    pictureBox1.Show();
                    pictureBox1.Image = test ? Resources.success : Resources.error;
                    await connection.InvokeAsync("UnSubscribe");
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private async void gunaGradientCircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("UnSubscribe");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
