using Datos.Context;
using Datos.Entity.EncuestaEntity;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto.Encuestas;
using Negocio.Dto.Encuestas.Response;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Services {
    public class EncuestaService:IEncuestaService {
        private readonly ContextoParticular _context;
        private readonly ContextoGeneral _contextoGeneral;
        public EncuestaService(ContextoParticular ctx, ContextoGeneral ctxg) {
            _context = ctx;
            _contextoGeneral = ctxg;
        }
        public void AddEncuesta(EncuestaRequest encuesta) {
            var enc = new Encuesta() {
                Titulo = encuesta.Titulo,
                Fecha = DateTime.Now,
                TipoEncuesta = encuesta.TipoEncuesta
            };
            _context.Encuesta.Add(enc);
            _context.SaveChanges();

            if (encuesta.TipoEncuesta == "Curso") {
                var enc_curso = new EncuestaCurso() {
                    EncuestaId = enc.Id,
                    SeccionTemplateId = encuesta.SeccionId,
                    CursoId=encuesta.FkId
                };
                _context.EncuestaCurso.Add(enc_curso);
                _context.SaveChanges();
            }
            if(encuesta.TipoEncuesta == "Facultad")
            {
                var facultad = _contextoGeneral.Facultad.FirstOrDefault(a => a.Url == encuesta.Facultad);
                if (facultad != null) {
                    var enc_facultad = new EncuestaFacultad()
                    {
                        EncuestaId = enc.Id,
                        FacultadId = facultad.Id,
                        SeccionTemplateId = encuesta.SeccionId
                    };
                    _context.EncuestaFacultades.Add(enc_facultad);
                    _context.SaveChanges();
                }
            }

            foreach (var preg in encuesta.LstPreguntas) {
                var p = new Preguntas() {
                    Frase=preg.Pregunta,
                    TipoCheck=preg.Opcion,
                    EncuestaId=enc.Id
                };
                _context.Preguntas.Add(p);
                _context.SaveChanges();
            }
            foreach (var resp in encuesta.LstRespuestas) {
                var op = new Opciones() {
                    Respuesta=resp.Respuesta,
                    PreguntaId= GetIdPreguntaEncuesta(resp.PreguntaAsociada,enc.Id)
                };
                _context.Opciones.Add(op);
                _context.SaveChanges();
            }
        }
        private int GetIdPreguntaEncuesta(string pregunta,int encuestaId) {
            return _context.Preguntas.SingleOrDefault(i => i.Frase == pregunta && i.EncuestaId == encuestaId).Id;
        }
        public EncuestaResponse ObtenerEncuestaParaResponder(int encuestaId) {
            Encuesta e=_context.Encuesta.SingleOrDefault(x => x.Id == encuestaId);
            EncuestaResponse encuesta = new EncuestaResponse() {
                Id=e.Id,
                Nombre=e.Titulo,
                TipoEncuesta=e.TipoEncuesta,
                LstPreguntas=new List<PreguntasResponse>()
            };
            List<Preguntas> preguntas = _context.Preguntas.Where(x => x.EncuestaId == encuesta.Id).ToList();
              
             foreach(var p in preguntas) {
                PreguntasResponse pregunta = new PreguntasResponse() {
                    Id = p.Id,
                    Pregunta = p.Frase,
                    TipoPregunta = p.TipoCheck,
                    LstOpciones=new List<OpcionesResponse>()
                };
                encuesta.LstPreguntas.Add(pregunta);

                 var respuestas = _context.Opciones.Where(x=>x.PreguntaId==p.Id).ToList();
                foreach(var resp in respuestas) {
                    pregunta.LstOpciones.Add(new OpcionesResponse() {
                        Id=resp.Id,
                        Respuesta=resp.Respuesta
                    });
                }
            }

            return encuesta;
        }
        public List<EncuestaResponse> ObtenerEncuestasCurso(int cursoId) {
            List<EncuestaResponse> lstEncResp = new List<EncuestaResponse>();
            var encuestas = _context.EncuestaCurso
                .Where(j=> j.CursoId==cursoId).ToList();
            foreach(var e in encuestas) {
                var enc = _context.Encuesta.SingleOrDefault(x => x.Id == e.EncuestaId);
                var encr = new EncuestaResponse() {
                    Id = enc.Id,
                    Nombre = enc.Titulo,
                    TipoEncuesta = enc.TipoEncuesta
                };
                lstEncResp.Add(encr);
            }

            return lstEncResp;
            
        }

        public List<EncuestaResponse> ObtenerEncuestasFacultad(string facultad)
        {
            var Facultad = _contextoGeneral.Facultad.FirstOrDefault(f => f.Url == facultad);
            List<EncuestaResponse> lstEncResp = new List<EncuestaResponse>();
            if (Facultad != null)
            {
                var encuestas = _context.EncuestaFacultades
                    .Where(j => j.FacultadId == Facultad.Id).ToList();
                foreach (var e in encuestas)
                {
                    var enc = _context.Encuesta.SingleOrDefault(x => x.Id == e.EncuestaId);
                    var encr = new EncuestaResponse()
                    {
                        Id = enc.Id,
                        Nombre = enc.Titulo,
                        TipoEncuesta = enc.TipoEncuesta
                    };
                    lstEncResp.Add(encr);
                }
            }

            return lstEncResp;

        }

        public List<PreguntasEstadisticaResponse> EstadisticasCurso(int cursoId,int idEncuesta) {
            List<PreguntasEstadisticaResponse> LstPreguntas = new List<PreguntasEstadisticaResponse>();

            var preguntas=_context.Preguntas.Where(x => x.EncuestaId == idEncuesta).ToList();
            var totalInscriptos = _context.Inscripcion.Where(x => x.CursoId == cursoId)
                             .GroupBy(p => p.CursoId)
                .Select(g => new {
                    Count = g.Count()
                })
                .ToList();
                           

            foreach (var p in preguntas){ //Preguntas de la encuesta
                var pp = new PreguntasEstadisticaResponse() {
                    Pregunta = p.Frase,
                    Tipo = p.TipoCheck,
                    LstRespuestas = new List<RespuestasEstadisticasResponse>()
                };
                LstPreguntas.Add(pp);
                var opciones = _context.Opciones.Where(x => x.PreguntaId == p.Id).ToList();

                foreach (var resp in opciones) {//Opciones de las Preguntas
                    //cantidad = _context.Respuestas.Select(x => x.OpcionId == resp.Id).Count();
                    var j= _context.Respuestas.Where(x => x.OpcionId == resp.Id)
                               .GroupBy(p => p.OpcionId)
                  .Select(g => new
                  {
                      Count = g.Count()
                  })
                  .ToList();

                    Console.WriteLine(j.Count);
                    Console.WriteLine(j);

                    var oo = new RespuestasEstadisticasResponse() {
                        Respuesta=resp.Respuesta,
                        CantidadRespuestas= j.Count,
                        Porcentaje= (j.Count*100)/totalInscriptos.Count
                    };
                    pp.LstRespuestas.Add(oo);
                }
            }
            return LstPreguntas;
        }


        public void BorrarEncuestaCurso(int idEncuesta) {
            var e = _context.Encuesta.SingleOrDefault(t => t.Id == idEncuesta);
            _context.Encuesta.Remove(e);
            _context.SaveChanges();
        }

        public void BorrarEncuestaFacultad(int idEncuesta)
        {
            var e = _context.Encuesta.SingleOrDefault(t => t.Id == idEncuesta);
            _context.Encuesta.Remove(e);
            _context.SaveChanges();
        }

        public void ResponderEncuesta(ResponderEncuestaRequest respuestas) {
  
            foreach (var resCheck in respuestas.LstRespuestasCheck) {
                
                var responder = new Respuestas() {
                    CuentaId = respuestas.UsuarioId,
                    OpcionId = resCheck.RespuestasCheck
                };
                Console.WriteLine(resCheck.RespuestasCheck);
                Console.WriteLine(responder);
                _context.Respuestas.Add(responder);
                _context.SaveChanges();

            }
            foreach (var resRadio in respuestas.LstRespuestasRadio) {
                var responder = new Respuestas() {
                    CuentaId = respuestas.UsuarioId,
                    OpcionId = resRadio.RespuestasRadio
                };
                _context.Respuestas.Add(responder);
                _context.SaveChanges();

            }

        }


    }
}
