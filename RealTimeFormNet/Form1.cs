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
            connection = new HubConnectionBuilder()
             .WithUrl("http://localhost:5001/ChartHub")
             .Build();

            connection.Closed += async (error) =>
            {
                Thread.Sleep(500);
                await connection.StartAsync();
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var es = connection.State;
                if (es.ToString() == "Disconnected")
                {
                    await connection.StartAsync();
                }

                connection.On<ArrayList, ArrayList>("SendUserCharts", (test, test1) =>
                {
                    productName.Clear();
                    CantProduct.Clear();

                    foreach (var item in test)
                    {
                        var s = item.ToString();
                        productName.Add(s);
                    }

                    foreach (var item in test1)
                    {
                        var s = Convert.ToInt32(item.ToString());
                        CantProduct.Add(s);
                    }
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
