using Microsoft.AspNetCore.SignalR.Client;
using RealTimeApplication.Model;
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

namespace RealTimeApplication
{
    public partial class Form1 : Form
    {
        HubConnection connection;

        public Form1()
        {
            InitializeComponent();
             connection = new HubConnectionBuilder()
              .WithUrl("http://localhost:55104/TestHub")
              .Build();

            connection.Closed += async (error) =>
            {
                Thread.Sleep(500);
                await connection.StartAsync();
            };

            Load += new EventHandler(Form1_Load);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //if (connection)
                //{

                //}
                var es = connection.State;
                if (es.ToString() == "Disconnected")
                {
                    await connection.StartAsync();
                }

                //var test = HubConnectionState.Connected;

            }
            catch (Exception ex)
            {
                //messagesList.Items.Add(ex.Message);
                MessageBox.Show("SignalR not working, " + ex.ToString());
            }

            connection.On<string>("SendUserGrants", (test) =>
            {
                textBox1.Text = test;
            });
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            UserGrants userGrants = new UserGrants
            {
                Modulo = "test",
                Access = true
            };

            await connection.InvokeAsync("SendUserGrants", "pasdasdasw");
        }

        private  void button2_Click(object sender, EventArgs e)
        {

            connection.On<string>("SendUserGrants", (test) =>
            {
                textBox1.Text = test;
            });
        }
    }
}
