using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealTimeFormNet
{
    public partial class Form1 : Form
    {

        readonly HubConnection connection;

        ArrayList productName = new ArrayList();
        ArrayList CantProduct = new ArrayList();
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            //Targets signalR endpoint
            connection = new HubConnectionBuilder()
             .WithUrl("http://CA214063:5001/TotalPOSHub")
             .Build();
            //Every time signalR connection gets closed this section gonna try to connect every 3 secs
            connection.Closed += async (error) =>
            {
                Thread.Sleep(3000);
                await connection.StartAsync();
            };
            //Opens up the connection if its disconnected
            //if (connection.State == HubConnectionState.Disconnected)
            //    connection.StartAsync().GetAwaiter();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            chart1.Hide();
            productName.Clear();
            CantProduct.Clear();
           
            productName.Add("Celular");
            productName.Add("Monitor");
            productName.Add("Teclado");
            productName.Add("Mouse");
            productName.Add("Headset");
            productName.Add("Auticulares");

            CantProduct.Add(random.Next(1, 13));
            CantProduct.Add(random.Next(1, 13));
            CantProduct.Add(random.Next(1, 13));
            CantProduct.Add(random.Next(1, 13));
            CantProduct.Add(random.Next(1, 13));
            CantProduct.Add(random.Next(1, 13));

            await connection.InvokeAsync("SendUserCharts", productName, CantProduct);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                connection.On<ArrayList, ArrayList>("SendUserCharts", (test, test1) =>
                {
                    chart1.Show();
                    productName.Clear();
                    CantProduct.Clear();

                    //test.OfType<ArrayList>().ToList().ForEach(o => productName.Add(o.ToString()));

                    //test1.OfType<ArrayList>().ToList().ForEach(o => CantProduct.Add(Convert.ToInt32(o.ToString())));

                    foreach (var item in test) productName.Add(item.ToString());

                    foreach (var item in test1) CantProduct.Add(Convert.ToInt32(item.ToString()));

                    chart1.Series[0].Points.DataBindXY(productName, CantProduct);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("SignalR not working, " + ex.ToString());
            }
        }
    }
}
