﻿using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MouseOverClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {

        private ConcurrentDictionary<string, string> _machines { get; set; }
        private readonly string _apiEndpoint = "/api/start/getname";

        public StartPage()
        {
            InitializeComponent();
            _machines = new ConcurrentDictionary<string, string>();
        }

        protected override void OnAppearing()
        {
            for (int addr = 1; addr < 256; addr++)
            {
                TryGetMachineAsync($"http://192.168.1.{addr}:5000");
            }

        }

        private async Task TryGetMachineAsync(string address)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address + _apiEndpoint);
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "text/plain";
            request.Timeout = 2000;
            request.Proxy = null;

            var contentStream = new MemoryStream();

            using (var response = await request.GetResponseAsync())
            {
                try
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        string machine = await new StreamReader(responseStream).ReadToEndAsync();
                        if (!string.IsNullOrWhiteSpace(machine))
                        {
                            _machines.TryAdd(machine, address);
                        }
                    }

                }
                catch (Exception ex)
                {
                    //TODO: Handle logging
                }
            }
        }

    }
}