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
              .WithUrl("http://localhost:5001/TestHub")
              .Build();

            connection.Closed += async (error) =>
            {
                Thread.Sleep(500);
                await connection.StartAsync();
            };
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var es = connection.State;
                if (es.ToString() == "Disconnected")
                {
                    await connection.StartAsync();
                }

                connection.On<string>("SendUserGrants", (test) =>
                {
                    textBox2.Text = test;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("SignalR not working, " + ex.ToString());
            }

        }
        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            await connection.InvokeAsync("SendUserGrants", textBox1.Text);
        }

    }
}
