using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnoBackNet.LN.Modelos
{
    public class RespuestasLN
    {
        public int Estado { get; set; }
        public Dictionary<string, object> Respuesta { get; set; }
        public RespuestasLN()
        {
            Estado = 200; // Por defecto, estado exitoso
            Respuesta = new Dictionary<string, object>();
        }

        public void Error500(string respuesta)
        {
            Estado = 500;
            Respuesta = new Dictionary<string, object>
            {
                { "Mensaje", respuesta }
            };
        }

        public void Creado(string respuesta)
        {
            Estado = 201;
            Respuesta = new Dictionary<string, object>
            {
                { "Mensaje", respuesta }
            };
        }

        public void Fallido(string respuesta)
        {
            Estado = 400;
            Respuesta = new Dictionary<string, object>
            {
                { "Mensaje", respuesta }
            };
        }

        public void NoEncontrado(string respuesta)
        {
            Estado = 404;
            Respuesta = new Dictionary<string, object>
            {
                { "Mensaje", respuesta }
            };
        }
    }
    }
