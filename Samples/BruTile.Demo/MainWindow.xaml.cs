﻿using BruTile.Predefined;
using BruTile.Web;
using System;
using System.Linq;
using System.Net;
using System.Windows.Controls;

namespace BruTile.Demo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (var knownTileSource in Enum.GetValues(typeof(KnownTileSource)).Cast<KnownTileSource>())
            {
                if (knownTileSource.ToString().ToLower().Contains("cloudmade")) continue; // Exclude CloudMade

                KnownTileSource source = knownTileSource;
                var radioButton = ToRadioButton(knownTileSource.ToString(), () => KnownTileSources.Create(source));
                Layers.Children.Add(radioButton);
            }

            Layers.Children.Add(ToRadioButton("Google Map", () => 
                CreateGoogleTileSource("http://mt{s}.google.com/vt/lyrs=m@130&hl=en&x={x}&y={y}&z={z}")));
            Layers.Children.Add(ToRadioButton("Google Terrain", () => 
                CreateGoogleTileSource("http://mt{s}.google.com/vt/lyrs=t@125,r@130&hl=en&x={x}&y={y}&z={z}")));
        }

        private static ITileSource CreateGoogleTileSource(string urlFormatter)
        {
            return new HttpTileSource(new GlobalSphericalMercator(), urlFormatter, new[] {"0", "1", "2", "3"}, 
                tileFetcher: FetchImageAsGoogle()); 
        }

        private static Func<Uri, byte[]> FetchImageAsGoogle()
        {
            return uri =>
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(uri);
                httpWebRequest.UserAgent =
                    @"Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.7) Gecko/20091221 Firefox/3.5.7";
                httpWebRequest.Referer = "http://maps.google.com/";
                return RequestHelper.FetchImage(httpWebRequest);
            };
        }

        private RadioButton ToRadioButton(string name, Func<ITileSource> func)
        {
            var radioButton = new RadioButton
            {
                Content = name,
                Tag = new Func<ITileSource>(func)
            };
            radioButton.Click += (sender, args) => MapControl.SetTileSource(((Func<ITileSource>)((RadioButton)sender).Tag)());

            return radioButton;
        }
    }
}