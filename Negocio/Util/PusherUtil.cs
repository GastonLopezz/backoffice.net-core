using Microsoft.AspNetCore.Mvc;
using PusherServer;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Util
{
    public class PusherUtil
    {

        private static string APP_ID = "1091889";
        private static string APP_KEY = "63877c6a11fd9e23a056";
        private static string APP_SECRET = "58bacf3504c15560c569";
        private static string CLUSTER = "us2";
        public static string canal = "EvaChat";
        public static string evento = "enviarMensaje";

        public static string Enviar(string canal, string evento, object data)
        {
            try
            {
                var options = new PusherOptions
                {
                    Cluster = CLUSTER,
                    Encrypted = true
                };

                var pusher = new Pusher(
                  APP_ID,
                  APP_KEY,
                  APP_SECRET,
                  options);

                var result = pusher.TriggerAsync(
                  canal,
                  evento,
                  data);

                return result.Result.ToString();

            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

    }
}
