﻿namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.IO;
    using AquaShop.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddAquarium")
                    {
                        string aquariumType = input[1];
                        string aquariumName = input[2];

                        result = controller.AddAquarium(aquariumType, aquariumName);
                    }
                    else if (input[0] == "AddDecoration")
                    {
                        string decorationType = input[1];

                        result = controller.AddDecoration(decorationType);
                    }
                    else if (input[0] == "InsertDecoration")
                    {
                        string aquariumName = input[1];
                        string decorationType = input[2];

                        result = controller.InsertDecoration(aquariumName, decorationType);
                    }
                    else if (input[0] == "AddFish")
                    {
                        string aquariumName = input[1];
                        string fishType = input[2];
                        string fishName = input[3];
                        string fishSpecies = input[4];
                        decimal price = decimal.Parse(input[5]);

                        result = controller.AddFish(aquariumName, fishType, fishName, fishSpecies, price);
                    }
                    else if (input[0] == "FeedFish")
                    {
                        string aquariumName = input[1];

                        result = controller.FeedFish(aquariumName);
                    }
                    else if (input[0] == "CalculateValue")
                    {
                        string aquariumName = input[1];

                        result = controller.CalculateValue(aquariumName);
                    }
                    else if (input[0] == "Report")
                    {
                        result = controller.Report();
                    }

                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}