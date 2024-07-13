using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using CustomRec.Server;
using CustomRec.Vault;

namespace CustomRec.Menu
{
    class Menu
    {
        public static bool firstTime = false;
        public static bool isBanned;
        public static string version;
        public static string appVersion = "0.0.2";

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "CustomRec - Loading..";

            Console.WriteLine(" ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗██████╗ ███████╗ ██████╗");
            Console.WriteLine("██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔══██╗██╔════╝██╔════╝");
            Console.WriteLine("██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║██████╔╝█████╗  ██║     ");
            Console.WriteLine("██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██║     ");
            Console.WriteLine("╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║██║  ██║███████╗╚██████╗");
            Console.WriteLine("╚ ═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝ ╚═════╝");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Please wait.. Loading essential files..");

            Directory.CreateDirectory("CustomRecData\\App\\");
            Directory.CreateDirectory("CustomRecData\\Profile\\");
            Directory.CreateDirectory("CustomRecData\\Images\\");
            Directory.CreateDirectory("CustomRecData\\Rooms\\");
            Directory.CreateDirectory("CustomRecData\\Images\\");
            Directory.CreateDirectory("CustomRecData\\Rooms\\Downloaded\\");
            if (!File.Exists("CustomRecData\\App\\tutorial.txt"))
            {
                File.WriteAllText("CustomRecData\\App\\tutorial.txt", "This file is for telling the application whether or not to run the tutorial on run. Do not delete this. Have fun! :D\n\n- Liam");
                firstTime = true;
            }

            if (!(File.Exists("CustomRecData\\avatar.txt")))
            {
                File.WriteAllText("CustomRecData\\avatar.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/avatar.txt"));
            }
            else if (File.ReadAllText("CustomRecData\\avatar.txt") == "")
            {
                File.WriteAllText("CustomRecData\\avatar.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/recroom2016/OpenRec/master/Download/avatar.txt"));
            }
            if (!(File.Exists("CustomRecData\\avataritems.txt")))
            {
                File.WriteAllText("CustomRecData\\avataritems.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/avataritems.txt"));
            }
            if (!(File.Exists("CustomRecData\\avataritems2.txt")))
            {
                File.WriteAllText("CustomRecData\\avataritems2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/avataritems2.txt"));
            }
            if (!(File.Exists("CustomRecData\\equipment.txt")))
            {
                File.WriteAllText("CustomRecData\\equipment.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/equipment.txt"));
            }
            if (!(File.Exists("CustomRecData\\consumables.txt")))
            {
                File.WriteAllText("CustomRecData\\consumables.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/consumables.txt"));
            }
            if (!(File.Exists("CustomRecData\\gameconfigs.txt")))
            {
                File.WriteAllText("CustomRecData\\gameconfigs.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/gameconfigs.txt"));
            }
            if (!(File.Exists("CustomRecData\\storefronts2.txt")))
            {
                File.WriteAllText("CustomRecData\\storefronts2.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/storefront2.txt"));
            }
            if (!(File.Exists("CustomRecData\\baserooms.txt")))
            {
                File.WriteAllText("CustomRecData\\baserooms.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/baserooms.txt"));
            }
            if (!(File.Exists("CustomRecData\\Profile\\username.txt")))
            {
                File.WriteAllText("CustomRecData\\Profile\\username.txt", "CustomRec - " + new Random().Next(0, 1000000));
            }
            if (!(File.Exists("CustomRecData\\Profile\\level.txt")))
            {
                File.WriteAllText("CustomRecData\\Profile\\level.txt", "10");
            }
            if (!(File.Exists("SavCustomRecDataeData\\Profile\\userid.txt")))
            {
                File.WriteAllText("CustomRecData\\Profile\\userid.txt", "10000000");
            }
            if (!(File.Exists("CustomRecData\\myrooms.txt")))
            {
                File.WriteAllText("CustomRecData\\myrooms.txt", "[]");
            }
            if (!(File.Exists("CustomRecData\\settings.txt")))
            {
                File.WriteAllText("CustomRecData\\settings.txt", Newtonsoft.Json.JsonConvert.SerializeObject(API.Settings.CreateDefaultSettings()));
            }
            if (!(File.Exists("CustomRecData\\profileimage.png")))
            {
                File.WriteAllBytes("CustomRecData\\profileimage.png", new WebClient().DownloadData("https://github.com/liamdoesvr/CustomRec/blob/main/DefaultProfileImage.png"));
            }
            if (!(File.Exists("CustomRecData\\App\\privaterooms.txt")))
            {
                File.WriteAllText("CustomRecData\\App\\privaterooms.txt", "Disabled");
            }
            if (!(File.Exists("CustomRecData\\App\\showopenrecinfo.txt")))
            {
                File.WriteAllText("CustomRecData\\App\\showopenrecinfo.txt", "Enabled");
            }
            if (!(File.Exists("CustomRecData\\App\\facefeaturesadd.txt")))
            {
                File.WriteAllText("CustomRecData\\App\\facefeaturesadd.txt", new WebClient().DownloadString("https://raw.githubusercontent.com/liamdoesvr/CustomRec/main/Config/facefeaturesadd.txt"));


                if (firstTime)
                {
                    Tutorial();
                }
                else
                {
                    MainMenu();
                }
            }

            static void Tutorial()
            {
                Console.Clear();

                Console.Title = "CustomRec - Tutorial";
                Console.WriteLine(" ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗██████╗ ███████╗ ██████╗");
                Console.WriteLine("██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔══██╗██╔════╝██╔════╝");
                Console.WriteLine("██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║██████╔╝█████╗  ██║     ");
                Console.WriteLine("██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██║     ");
                Console.WriteLine("╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║██║  ██║███████╗╚██████╗");
                Console.WriteLine("╚ ═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝ ╚═════╝");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Welcome to CustomRec! Follow this short tutorial to start playing old Rec Room!");
                Console.WriteLine();
                Console.WriteLine("CustomRec is a server that allows you to play old versions of Rec Room.");
                Console.WriteLine("In this menu, you can change your profile, launch the server, or see whats new.");
                Console.WriteLine("To play, you must have a build. To download them, go to our Discord server.");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("Once you have a build, follow these steps.");
                Console.WriteLine("1. Un-zip the build and place it somewhere you will remember it.");
                Console.WriteLine("2. Start the server with this application in the main menu.");
                Console.WriteLine("3. Launch the 'RecRoom-Release.exe' file in the build files.");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("If it doesn't work, make sure your server is up and running.");
                Console.WriteLine("To check this, go to your server and check if it says 'All systems running.'");
                Console.WriteLine("If it doesn't, try troubleshooting, or go to our Discord server for help!");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine("Thanks for using CustomRec and have fun!");
                Console.WriteLine("Press any key to go to the menu");
                Console.ReadKey();
                MainMenu();
            }

            static void MainMenu()
            {
                Console.Clear();
                Console.Title = "CustomRec - Menu";
                Console.WriteLine(" ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗██████╗ ███████╗ ██████╗");
                Console.WriteLine("██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔══██╗██╔════╝██╔════╝");
                Console.WriteLine("██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║██████╔╝█████╗  ██║     ");
                Console.WriteLine("██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██║     ");
                Console.WriteLine("╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║██║  ██║███████╗╚██████╗");
                Console.WriteLine("╚ ═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝ ╚═════╝");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Made by liamdoes.vr - Version: " + appVersion + "Discord: SERVER NOT MADE");
                Console.WriteLine();
                Console.WriteLine("1. Download Builds");
                Console.WriteLine("2. Edit Profile");
                Console.WriteLine("3. Start server");
                Console.WriteLine("4. Changelogs");
                Console.WriteLine("5. Settings");

                string readMenuOption = Console.ReadLine();
                if (readMenuOption == "3")
                {
                    SelectBuild();
                }
                else if (readMenuOption == "4")
                {
                    Changelogs();
                }
                else if (readMenuOption == "5")
                {
                    Settings();
                }
            }

            static void StartServer(string version)
            {
                Console.Clear();

                Console.Title = "CustomRec - Server";
                Console.WriteLine(" ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗██████╗ ███████╗ ██████╗");
                Console.WriteLine("██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔══██╗██╔════╝██╔════╝");
                Console.WriteLine("██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║██████╔╝█████╗  ██║     ");
                Console.WriteLine("██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██║     ");
                Console.WriteLine("╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║██║  ██║███████╗╚██████╗");
                Console.WriteLine("╚ ═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝ ╚═════╝");
                Console.WriteLine("------------------------------------------------------------------------------");

                if (version == "2018")
                {
                    version = "2018" + "1";
                }

                else if (version == "2017")
                {
                    version = "2017" + "1";
                }

                else if (version == "2016")
                {
                    version = "2016" + "1";

                    new APIServer();
                    new WebSocket.WebSocket();
                }

                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Please open the build you want to play.");
                Console.ReadLine();
            }

            static void SelectBuild()
            {
                Console.Clear();

                Console.Title = "CustomRec - Select Build";
                Console.WriteLine(" ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗██████╗ ███████╗ ██████╗");
                Console.WriteLine("██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔══██╗██╔════╝██╔════╝");
                Console.WriteLine("██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║██████╔╝█████╗  ██║     ");
                Console.WriteLine("██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██║     ");
                Console.WriteLine("╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║██║  ██║███████╗╚██████╗");
                Console.WriteLine("╚ ═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝ ╚═════╝");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Select the build your gonna play with CustomRec.");
                Console.WriteLine("Choose either 2016, 2017, or 2018.");
                Console.WriteLine("------------------------------------------------------------------------------");
                string buildToPlay = Console.ReadLine();

                if (buildToPlay == "2018")
                {
                    StartServer("2018");
                }

                else if (buildToPlay == "2017")
                {
                    StartServer("2017");
                }

                else if (buildToPlay == "2016")
                {
                    StartServer("2016");
                }
            }

            static void EditProfile()
            {

            }

            static void Changelogs()
            {
                Console.Clear();
                Console.Title = "CustomRec - Chaneglogs";
                Console.WriteLine(" ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗██████╗ ███████╗ ██████╗");
                Console.WriteLine("██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔══██╗██╔════╝██╔════╝");
                Console.WriteLine("██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║██████╔╝█████╗  ██║     ");
                Console.WriteLine("██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██║     ");
                Console.WriteLine("╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║██║  ██║███████╗╚██████╗");
                Console.WriteLine("╚ ═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝ ╚═════╝");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Check out the update logs here and check for bug fixes.");
                Console.WriteLine();
                Console.WriteLine("-- Beta Version - 0.0.2 ------------------------------------------------------");
                Console.WriteLine("- Added");
                Console.WriteLine("- Added");
                Console.WriteLine("- Added");
                Console.WriteLine("- Added");
                Console.WriteLine("-- Beta Version - 0.0.1 ------------------------------------------------------");
                Console.WriteLine("- Added Tutorial");
                Console.WriteLine("- Added Main Menu");
                Console.WriteLine("- Added Changelogs (what your seeing right now)");
                Console.WriteLine("- Added Settings");
                Console.WriteLine("------------------------------------------------------------------------------");

                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey();
                MainMenu();
            }

            static void Settings()
            {
                Console.Clear();
                Console.Title = "CustomRec - Chaneglogs";
                Console.WriteLine(" ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗██████╗ ███████╗ ██████╗");
                Console.WriteLine("██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔══██╗██╔════╝██╔════╝");
                Console.WriteLine("██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║██████╔╝█████╗  ██║     ");
                Console.WriteLine("██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══██╗██╔══╝  ██║     ");
                Console.WriteLine("╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║██║  ██║███████╗╚██████╗");
                Console.WriteLine("╚ ═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝ ╚═════╝");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("Change your settings here such as private rooms and resetting your save data.");
                Console.WriteLine();
                Console.WriteLine("1. Reset Save Data");
                Console.WriteLine("2. Private Rooms");
                Console.WriteLine("3. Custom Room Downloader");
                Console.WriteLine("4. Import Rec Room Profile");
                Console.WriteLine("------------------------------------------------------------------------------");

                Console.WriteLine("Press any key to go back to the main menu.");
                Console.ReadKey();
                MainMenu();
            }

            static void DownloadBuilds()
            {

            }
        }
    }
}
