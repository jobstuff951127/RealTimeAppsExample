using Microsoft.AspNetCore.SignalR.Client;
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
        private readonly int[] ventas = { 9200452, 12981033, 12981033, 12981033, 12981033, 4291825, 4291838, 4372147, 4372166, 4372383 };
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();

            //Targets signalR endpoint
            connection = new HubConnectionBuilder()
             .WithUrl("http://localhost:5001/ChartHub")
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

            //Go to register business id at SignalR
            await connection.InvokeAsync("Connect", ventas[id]);

            //This method listen to the communication channel to catch messages            
            connection.On<bool, int>("Done", (test, test1) =>
            {
                pictureBox1.Show();

                if (test)
                    pictureBox1.Image = Properties.Resources.success;
                else
                    pictureBox1.Image = Properties.Resources.error;
            });
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await connection.InvokeAsync("OnDisconnect");
            await connection.StopAsync();
        }
    }
}
