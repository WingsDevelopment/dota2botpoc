using DotaMatch.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotatest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DotaClient client = DotaClient.Create(Credentials.UserName,
                    Credentials.Password,
                    Credentials.API_KEY,
                    new DotaClientParams());

                client.Connect();

                client.CreateLobby("torretotest16",
                    "test1",
                    new DotaLobbyParams(
                        new ulong[] { 52572231 },
                        new ulong[] { 87828889 }
                    ));

                client.InviteToLobby(52572231);
                client.InviteToLobby(87828889);

                client.OnGameFinished += Client_OnGameFinished;

                Console.WriteLine("Lobby Started");
                //client.Reset();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Client_OnGameFinished(DotaGameResult Outcome)
        {
            if (Outcome == DotaGameResult.Radiant)
            {
                //Radiant Win
                Console.WriteLine("Radiant won");
            }
            else if (Outcome == DotaGameResult.Dire)
            {
                // Dire Win
                Console.WriteLine("Dire won");
            }
            else
            {
                // Error Occured
                Console.WriteLine("Error");
            }
        }

    }
}
