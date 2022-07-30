// Position Open, Close and Update message webhook on discord by paolo panicali july 2022

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using cAlgo.API;
using cAlgo.API.Indicators;
using cAlgo.API.Internals;
using cAlgo.Indicators;


namespace cAlgo.Robots
{
    [Robot(TimeZone = TimeZones.UTC, AccessRights = AccessRights.FullAccess)]
    public class Discord : Robot
    {
        string token, text;

        protected override void OnStart()
        {
            Positions.Opened += PositionsOnOpened;
            Positions.Closed += PositionsOnClosed;

            foreach (var position in Positions)
            {
                text = "Discord Bot Assistant started // OPEN POSITION : ////--- BOTNAME: " + position.Label + "--- Symbol: " + position.SymbolName + "---- ENTRY: " + position.EntryPrice + "---- SL: " + position.StopLoss + "---- TP: " + position.TakeProfit + "---- TIME UTC: " + position.EntryTime + "---- PROFIT:  " + position.Pips + " pips";

                string filename = "C:\\DiscordMessage\\ConsoleApp1.exe";
                var proc = System.Diagnostics.Process.Start(filename, text);

                proc.CloseMainWindow();
                proc.Close();

                System.Threading.Thread.Sleep(5000);

                Print(text);
            }
        }

        protected override void OnBar()
        {
            if (Bars.OpenTimes.LastValue.Minute == 5)
            {
                OpenPositionsUpdate();
            }
        }

        // Send discord position update messsage
        protected void OpenPositionsUpdate()
        {
            foreach (var position in Positions)
            {
                text = "UPDATE CURRENTLY OPEN POSITION : ////--- BOTNAME: " + position.Label + "--- Symbol: " + position.SymbolName + "---- ENTRY: " + position.EntryPrice + "---- SL: " + position.StopLoss + "---- TP: " + position.TakeProfit + "---- TIME UTC: " + position.EntryTime + "---- PROFIT:  " + position.Pips + " pips";

                string filename = "C:\\DiscordMessage\\ConsoleApp1.exe";
                var proc = System.Diagnostics.Process.Start(filename, text);

                proc.CloseMainWindow();
                proc.Close();

                System.Threading.Thread.Sleep(5000);

                Print(text);
            }
        }

        private void PositionsOnOpened(PositionOpenedEventArgs args)
        {
            text = "NEW TRADE OPENED : ////--- BOTNAME: " + args.Position.Label + "--- Symbol: " + args.Position.SymbolName + "---- ENTRY: " + args.Position.EntryPrice + "---- SL: " + args.Position.StopLoss + "---- TP: " + args.Position.TakeProfit + "---- TIME UTC: " + args.Position.EntryTime + "---- PROFIT:  " + args.Position.Pips + " pips";

            string filename = "C:\\DiscordMessage\\ConsoleApp1.exe";
            var proc = System.Diagnostics.Process.Start(filename, text);

            proc.CloseMainWindow();
            proc.Close();

            System.Threading.Thread.Sleep(5000);

            Print(text);
        }

        private void PositionsOnClosed(PositionClosedEventArgs args)
        {
            var position = args.Position;
            text = "CLOSED TRADE : ////--- BOTNAME: " + position.Label + "--- Symbol: " + position.SymbolName + "---- ENTRY: " + position.EntryPrice + "---- SL: " + position.StopLoss + "---- TP: " + position.TakeProfit + "---- TIME UTC: " + position.EntryTime + "---- PROFIT:  " + position.Pips + " pips";

            string filename = "C:\\DiscordMessage\\ConsoleApp1.exe";
            var proc = System.Diagnostics.Process.Start(filename, text);

            proc.CloseMainWindow();
            proc.Close();

            System.Threading.Thread.Sleep(5000);

            Print(text);
        }
    }
}
