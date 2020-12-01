using Datos.Context;
using Datos.Entity.EncuestaGeneralEntity;
using Negocio.Dto.Encuestas;
using Negocio.Dto.Encuestas.Response;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Services
{
    public class EncuestaUDELARService : IEncuestaUDELARService
    {
        private readonly ContextoParticular _context;
        private readonly ContextoGeneral _contextoGeneral;
        public EncuestaUDELARService(ContextoParticular ctx, ContextoGeneral ctxg)
        {
            _context = ctx;
            _contextoGeneral = ctxg;
        }
        public void AddEncuesta(EncuestaGeneralRequest encuesta)
        {
            foreach (var item in _contextoGeneral.Facultad.ToList())
            {

            }

            var enc = new EncuestaGeneral()
            {
                Titulo = encuesta.Titulo,
                Fecha = DateTime.Now
            };
            _contextoGeneral.EncuestaGeneral.Add(enc);
            _contextoGeneral.SaveChanges();

            foreach (var preg in encuesta.LstPreguntas)
            {
                var p = new PreguntasGeneral()
                {
                    Frase = preg.Pregunta,
                    TipoCheck = preg.Opcion,
                    EncuestaGeneralId = enc.Id
                };
                _contextoGeneral.PreguntasGeneral.Add(p);
                _contextoGeneral.SaveChanges();
            }
            foreach (var resp in encuesta.LstRespuestas)
            {
                var op = new OpcionesGeneral()
                {
                    Respuesta = resp.Respuesta,
                    PreguntaGeneralId = GetIdPreguntaEncuesta(resp.PreguntaAsociada, enc.Id)
                };
                _contextoGeneral.OpcionesGeneral.Add(op);
                _contextoGeneral.SaveChanges();
            }
        }
        private int GetIdPreguntaEncuesta(string pregunta, int encuestaId)
        {
            return _contextoGeneral.PreguntasGeneral.SingleOrDefault(i => i.Frase == pregunta && i.EncuestaGeneralId == encuestaId).Id;
        }

        public EncuestaGeneralResponse ObtenerEncuestaParaResponder(int encuestaId)
        {
            EncuestaGeneral e = _contextoGeneral.EncuestaGeneral.SingleOrDefault(x => x.Id == encuestaId);
            EncuestaGeneralResponse encuesta = new EncuestaGeneralResponse()
            {
                Id = e.Id,
                Nombre = e.Titulo,
                LstPreguntas = new List<PreguntasResponse>()
            };
            List<PreguntasGeneral> preguntas = _contextoGeneral.PreguntasGeneral.Where(x => x.EncuestaGeneralId == encuesta.Id).ToList();

            foreach (var p in preguntas)
            {
                PreguntasResponse pregunta = new PreguntasResponse()
                {
                    Id = p.Id,
                    Pregunta = p.Frase,
                    TipoPregunta = p.TipoCheck,
                    LstOpciones = new List<OpcionesResponse>()
                };
                encuesta.LstPreguntas.Add(pregunta);

                var respuestas = _contextoGeneral.OpcionesGeneral.Where(x => x.PreguntaGeneralId == p.Id).ToList();
                foreach (var resp in respuestas)
                {
                    pregunta.LstOpciones.Add(new OpcionesResponse()
                    {
                        Id = resp.Id,
                        Respuesta = resp.Respuesta
                    });
                }
            }

            return encuesta;
        }


        public List<EncuestaGeneralResponse> ObtenerEncuestas()
        {
            List<EncuestaGeneralResponse> lstEncResp = new List<EncuestaGeneralResponse>();
            var encuestas = _contextoGeneral.EncuestaGeneral.ToList();
            foreach (var e in encuestas)
            {
                var enc = _contextoGeneral.EncuestaGeneral.SingleOrDefault(x => x.Id == e.Id);
                var encr = new EncuestaGeneralResponse()
                {
                    Id = enc.Id,
                    Nombre = enc.Titulo
                };
                lstEncResp.Add(encr);
            }
            return lstEncResp;

        }


        public void BorrarEncuesta(int idEncuesta)
        {
            var e = _contextoGeneral.EncuestaGeneral.SingleOrDefault(t => t.Id == idEncuesta);
            _contextoGeneral.EncuestaGeneral.Remove(e);
            _contextoGeneral.SaveChanges();
        }

        public void ResponderEncuesta(ResponderEncuestaGeneralRequest respuestas)
        {
            
            foreach (var resCheck in respuestas.LstRespuestasCheck)
            {
                var responder = new RespuestasGeneral()
                {
                    CuentaId = respuestas.UsuarioId,
                    OpcionId = resCheck.RespuestasCheck
                };
                Console.WriteLine(resCheck.RespuestasCheck);
                Console.WriteLine(responder);
                _contextoGeneral.RespuestasGeneral.Add(responder);
                _contextoGeneral.SaveChanges();

            }
            foreach (var resRadio in respuestas.LstRespuestasRadio)
            {
                var responder = new RespuestasGeneral()
                {
                    CuentaId = respuestas.UsuarioId,
                    OpcionId = resRadio.RespuestasRadio
                };
                _contextoGeneral.RespuestasGeneral.Add(responder);
                _context.SaveChanges();

            }

        }
    }
}
