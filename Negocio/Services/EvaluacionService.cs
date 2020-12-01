using Datos.Context;
using Datos.Entity;
using Datos.Entity.EvaluacionEntity;
using Microsoft.EntityFrameworkCore;
using Negocio.Dto;
using Negocio.Dto.Evaluaciones;
using Negocio.Dto.Response.Evaluaciones;
using Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio.Services {

    public class EvaluacionService : IEvaluacionService {
        private readonly ContextoParticular _context;
        private readonly IMaterialService _materialSerivce;
        public EvaluacionService(ContextoParticular _contextoParticular, IMaterialService materialService) {
            _context = _contextoParticular;
            _materialSerivce = materialService;
        }

        public string agregarEvaluacion(EvaluacionRequest evaluacionRequest) {
            string res = "";
            Evaluacion evaluacion = new Evaluacion {
                Titulo = evaluacionRequest.Titulo,
                Fecha = evaluacionRequest.Fecha,
                ValidacionBedelia = false,
                EsArchivo = evaluacionRequest.EsArchivo,
                TipoEvaluacion = evaluacionRequest.TipoEvaluacion,
                CalificacionAprobacion = evaluacionRequest.CalificacionAprobacion,
                SeccionTemplateId = evaluacionRequest.SeccionId
            };
            
            _context.Evaluaciones.Add(evaluacion);
            _context.SaveChanges();
            if (!evaluacionRequest.EsArchivo){
                foreach (var vof in evaluacionRequest.vofs)
                {
                    agregarVerdaderoFalso(evaluacion, vof, evaluacionRequest.opciones);
                }
                foreach (var des in evaluacionRequest.desarrollos)
                {
                    agregarDesarrollo(evaluacion, des);
                }
                return res;
            }
            return res;
        }
        private void agregarVerdaderoFalso(Evaluacion evaluacion,VerdaderoFalsoRequest verdaderoFalso, List<OpcionRequest>opciones) {
            VerdaderoFalso vf = new VerdaderoFalso
            {
                Frase = verdaderoFalso.Pregunta,
                MultipleOpcion = verdaderoFalso.Opcion,
              //  Evaluacion = evaluacion,
                EvaluacionId = evaluacion.Id
            };
            _context.VerdaderoFalso.Add(vf);
            _context.SaveChanges();

            foreach (OpcionRequest op in opciones) {
                if (op.PreguntaAsociada.Equals(verdaderoFalso.Pregunta))
                {
                    Opcion opcion = new Opcion
                    {
                        Frase = op.Respuesta,
                        Correcta = op.Correcta,
                       // VerdaderoFalso = vf,
                        VerdaderoFalsoId = vf.Id
                    };
                    _context.OpcionesVoF.Add(opcion);

                }
            }
            _context.SaveChanges();

        }
        private void agregarDesarrollo(Evaluacion evaluacion,DesarrolloRequest desarrollo) {
            Desarrollo d = new Desarrollo {
                Pregunta = desarrollo.Pregunta,
                PuntajeAprobacion = desarrollo.PuntajeAprobacion,
                //Evaluacion = evaluacion,
                EvaluacionId = evaluacion.Id
            };
            _context.Desarrollo.Add(d);
            _context.SaveChanges();

        }

        public void responderEvaluacion(RespuestaEvaluacionRequest evaluacion)
        {//Ver si se paso de la fecha
            var cuenta = _context.Cuenta.SingleOrDefault(e => e.Id == evaluacion.EstudianteId);
            var _evaluacion = _context.Evaluaciones.SingleOrDefault(e => e.Id == evaluacion.EvaluacionId);
            var _vofs = _context.VerdaderoFalso.Where(x => x.EvaluacionId == _evaluacion.Id).ToList();

            foreach(var vof in _vofs)
            {
                var opc = _context.OpcionesVoF.Where(x => x.VerdaderoFalsoId == vof.Id).ToList();
                foreach(var opcion in opc) 
                {
                    bool esta = false;
                    foreach(var respuesta in evaluacion.vofs)
                    {
                        if (respuesta.OpcionId == opcion.Id)
                        {
                            esta = true;
                            responderVof(cuenta, _evaluacion, respuesta);
                        }
                    }
                    if (!esta)
                    {
                        responderVof(cuenta, _evaluacion, new RespuestaVofRequest
                        {
                            Eleccion = false,
                            OpcionId = opcion.Id
                        });
                    }
                }

            }
            if (evaluacion.desarrollos != null)
            {
                if(evaluacion.desarrollos.Count > 0)
                {
                    foreach (var desarrollo in evaluacion.desarrollos)
                    {
                        responderDesarrollo(evaluacion.EvaluacionId, cuenta, desarrollo);
                    }
                }
                else
                {
                    var calificacion = _context.Calificaciones.SingleOrDefault(e => e.EvaluacionId == evaluacion.EvaluacionId && e.EstudianteId == evaluacion.EstudianteId);
                    calificar(new CalificacionRequest()
                    {
                        Facultad=evaluacion.Facultad,
                        CalificacionId= calificacion.Id,
                        CalificacionesDesarrollo= new List<CalificacionDesarrollo>()
                    });
                    _context.SaveChanges();
                }
            }
            else
            {
                var calificacion = _context.Calificaciones.SingleOrDefault(e => e.EvaluacionId == evaluacion.EvaluacionId && e.EstudianteId == evaluacion.EstudianteId);
                calificar(new CalificacionRequest()
                {
                    Facultad = evaluacion.Facultad,
                    CalificacionId = calificacion.Id,
                    CalificacionesDesarrollo = new List<CalificacionDesarrollo>()
                });
            }
            _context.SaveChanges();
        }
        public void responderVof(Cuenta cuenta, Evaluacion evaluacion, RespuestaVofRequest respuesta) {
            var opcion = _context.OpcionesVoF.SingleOrDefault(o => o.Id == respuesta.OpcionId);
            var vof = _context.VerdaderoFalso.SingleOrDefault(v => v.Id == opcion.VerdaderoFalsoId);
            
            var respuestaVof = new RespuestaVoF {
                Eleccion = respuesta.Eleccion,
                OpcionId = respuesta.OpcionId,
                Opcion = opcion,
                EstudianteId = evaluacion.Id,
                Estudiante = cuenta,
                VerdaderoFalso = vof,
                VerdaderoFalsoId = vof.Id
            };
            generarCalificacion(evaluacion.Id, cuenta);
            _context.RespuestaVoF.Add(respuestaVof);
            _context.SaveChanges();
        }

        private void generarCalificacion(int EvaluacionId, Cuenta Estudiante) {
            var evaluacion = _context.Evaluaciones.SingleOrDefault(e => e.Id == EvaluacionId);
            if (evaluacion == null) {
                throw (new Exception("La calificacion no existe o no esta publicada"));
            }
            if (!existeCalificacion(evaluacion.Id, Estudiante.Id)) {
                var calificacion = new Calificacion {
                    EstadoCalificacion = "Pendiente",
                    FechaPublicada = DateTime.Now,
                 //   Estudiante = Estudiante,
                    EstudianteId = Estudiante.Id,
                    Evaluacion = evaluacion,
                    EvaluacionId = evaluacion.Id
                };
                _context.Calificaciones.Add(calificacion);
                _context.SaveChanges();

            }
        }

        private bool existeCalificacion(int EvaluacionId, int EstudianteId) {
            var calificacion = _context.Calificaciones.SingleOrDefault(e => e.EvaluacionId == EvaluacionId && e.EstudianteId == EstudianteId);
            if (calificacion == null) {
                return false;
            }
            return true;
        }



        public void responderDesarrollo(int EvaluacionId,Cuenta cuenta, RespuestaDesarrolloRequest respuesta) {
            var desarrollo = _context.Desarrollo.SingleOrDefault(o => o.Id == respuesta.DesarrolloId);
            var respuestaD = new RespuestaDesarrollo {
                Respuesta = respuesta.Respuesta,
                DesarrolloId = respuesta.DesarrolloId,
                Desarrollo = desarrollo,
                EstudianteId = cuenta.Id,
                Estudiante = cuenta
            };
            generarCalificacion(EvaluacionId, cuenta);
            _context.RespuestaDesarrollo.Add(respuestaD);
            _context.SaveChanges();
        }

        public void calificar(CalificacionRequest notasDesarrollo) {
            var calificacion = _context.Calificaciones.SingleOrDefault(c => c.Id == notasDesarrollo.CalificacionId);
            var evaluacion = _context.Evaluaciones.SingleOrDefault(e => e.Id == calificacion.EvaluacionId);
            var estudiante = _context.Cuenta.SingleOrDefault(e => e.Id == calificacion.EstudianteId);
            var respuestasDesarrollo = _context.RespuestaDesarrollo.Where(i => i.EstudianteId == estudiante.Id && i.Desarrollo.EvaluacionId == calificacion.EvaluacionId).ToList();
            int cantRespuestas = respuestasDesarrollo.Count;
            int respuestasCorrectas = 0;
            foreach (var respDesarrollo in respuestasDesarrollo) {
                var calDes = notasDesarrollo.CalificacionesDesarrollo;
                foreach (var nota in calDes) {
                    if (nota.Nota > 0 && nota.Nota <= 100) {
                        if (nota.DesarrolloId == respDesarrollo.DesarrolloId) {
                            var d = _context.Desarrollo.SingleOrDefault(d => d.Id == nota.DesarrolloId);
                            if (d != null) {
                                respDesarrollo.Puntaje = nota.Nota;
                                if (nota.Nota >= d.PuntajeAprobacion) {
                                    respuestasCorrectas++;
                                }
                            }
                        }
                    } else {
                        throw (new Exception("Una nota no es mayor a 0 y menor o igual a 100"));
                    }
                }
            }

            int[] retornovof = calificarVof(notasDesarrollo.CalificacionId);

            int cantidadTotalPreguntas = retornovof[1] + cantRespuestas;
            int cantidadCorrectas = retornovof[0] + respuestasCorrectas;

            int notaFinal = (cantidadCorrectas * 100) / cantidadTotalPreguntas;

            calificacion.FechaCorregida = DateTime.Now;

            if (notaFinal >= evaluacion.CalificacionAprobacion) {
                calificacion.EstadoCalificacion = "Aprobado";
            } else {
                calificacion.EstadoCalificacion = "Reprobado";
            }
            calificacion.Nota = notaFinal;
            _context.SaveChanges();
        }
        private int[] calificarVof(int CalificacionId) {
            var calificacion = _context.Calificaciones.SingleOrDefault(c => c.Id == CalificacionId);
            var estudiante = _context.Cuenta.SingleOrDefault(e => e.Id == calificacion.EstudianteId);
            var verdaderoFalsos = _context.VerdaderoFalso.Where(v => v.EvaluacionId == calificacion.EvaluacionId).ToList();
            var respuestasVof = _context.RespuestaVoF.Where(i => i.EstudianteId == estudiante.Id && i.VerdaderoFalso.EvaluacionId == calificacion.EvaluacionId).ToList();
            int cantRespuestas = respuestasVof.Count();
            int cantVoF = verdaderoFalsos.Count();
            int respuestasCorrectas = 0;
            foreach (var vof in verdaderoFalsos) {
                bool correcta = true;
                var opciones = _context.OpcionesVoF.Where(o => o.VerdaderoFalsoId == vof.Id).ToList();
                foreach (var opc in opciones) {
                    foreach (var rvof in respuestasVof) {
                        if (rvof.OpcionId == opc.Id) {
                            if (rvof.Eleccion != opc.Correcta) {
                                correcta = false;
                            }
                        }
                    }
                }
                if (correcta) {
                    respuestasCorrectas++;
                }
            }
            int[] retorno = { respuestasCorrectas, cantVoF };
            return retorno;
        }
        
        public List<EvaluacionResponse> obtenerEvaluacionesSeccion(int SeccionId) {
            List<EvaluacionResponse> response = new List<EvaluacionResponse>();
            var seccion = _context.SeccionTemplate.SingleOrDefault(s => s.Id == SeccionId);
            var evaluaciones = _context.Evaluaciones.Where(e => e.SeccionTemplateId == seccion.Id).ToList();

            foreach (var evaluacion in evaluaciones) {
                var verdaderoFalsos = _context.VerdaderoFalso.Where(v => v.EvaluacionId == evaluacion.Id).ToList();
                var desarrollos = _context.Desarrollo.Where(d => d.EvaluacionId == evaluacion.Id).ToList();

                var evaluacioRresponse = new EvaluacionResponse {
                    Id = evaluacion.Id,
                    Nombre = evaluacion.Titulo,
                    CalificacionAprobacion = evaluacion.CalificacionAprobacion,
                    Fecha = evaluacion.Fecha,
                    TipoEvaluacion = evaluacion.TipoEvaluacion,
                    ValidacionBedelia = evaluacion.ValidacionBedelia,
                    EsArchivo=evaluacion.EsArchivo,
                    vofs = new List<VerdaderoFalsoResponse>(),
                    desarrollos = new List<DesarrolloResponse>()
                };
                foreach (var vof in verdaderoFalsos) {
                    var opciones = _context.OpcionesVoF.Where(o => o.VerdaderoFalsoId == vof.Id).ToList();
                    var vofResponse = new VerdaderoFalsoResponse {
                        Id = vof.Id,
                        Frase = vof.Frase,
                        MultipleOpcion = vof.MultipleOpcion,
                        Opciones = new List<OpcionResponse>()
                    };
                    foreach (var opc in opciones) {
                        var opcResponse = new OpcionResponse {
                            Id = opc.Id,
                            Frase = opc.Frase
                        };
                        vofResponse.Opciones.Add(opcResponse);
                    }
                    evaluacioRresponse.vofs.Add(vofResponse);
                }

                foreach (var des in desarrollos) {
                    var desarrolloResponse = new DesarrolloResponse {
                        Id = des.Id,
                        Pregunta = des.Pregunta
                    };
                    evaluacioRresponse.desarrollos.Add(desarrolloResponse);
                }
                response.Add(evaluacioRresponse);
            }
            return response;
        }
        public EvaluacionResponse obtenerEvaluacion(int EvaluacionId) {
            var evaluacion = _context.Evaluaciones.SingleOrDefault(s => s.Id == EvaluacionId);
            var evaluacioRresponse = new EvaluacionResponse {
                Id = evaluacion.Id,
                Nombre = evaluacion.Titulo,
                CalificacionAprobacion = evaluacion.CalificacionAprobacion,
                Fecha = evaluacion.Fecha,
                TipoEvaluacion = evaluacion.TipoEvaluacion,
                ValidacionBedelia = evaluacion.ValidacionBedelia,
                EsArchivo=evaluacion.EsArchivo,
                vofs = new List<VerdaderoFalsoResponse>(),
                desarrollos = new List<DesarrolloResponse>()
            };
            var verdaderoFalsos = _context.VerdaderoFalso.Where(v => v.EvaluacionId == evaluacion.Id).ToList();
            var desarrollos = _context.Desarrollo.Where(d => d.EvaluacionId == evaluacion.Id).ToList();

            foreach (var v in verdaderoFalsos) {
                   var vofResponse = new VerdaderoFalsoResponse {
                        Id = v.Id,
                        Frase = v.Frase,
                        MultipleOpcion = v.MultipleOpcion,
                        Opciones = new List<OpcionResponse>()
                    };
                
                    evaluacioRresponse.vofs.Add(vofResponse);
                var opciones = _context.OpcionesVoF.Where(o => o.VerdaderoFalsoId == v.Id).ToList();

                foreach (var opc in opciones) {
                        var opcResponse = new OpcionResponse {
                            Id = opc.Id,
                            Frase = opc.Frase,
                        };
                        vofResponse.Opciones.Add(opcResponse);
                    }
                }         
            

            foreach (var des in desarrollos) {
                var desarrolloResponse = new DesarrolloResponse {
                    Id = des.Id,
                    Pregunta = des.Pregunta
                };
                evaluacioRresponse.desarrollos.Add(desarrolloResponse);
            }

            return evaluacioRresponse;
        }

        public List<CalificacionResponse> obtenerCalificacionesUsuario(int idCuenta) {
            List<CalificacionResponse> respuesta = new List<CalificacionResponse>();
            var cuenta = _context.Cuenta.SingleOrDefault(c => c.Id == idCuenta);
            var calificaciones = _context.Calificaciones.Where(c => c.EstudianteId == cuenta.Id).ToList();
            var persona = _context.Persona.SingleOrDefault(p => p.Id == cuenta.PersonaId);
            foreach (var calificacion in calificaciones) {
                var evaluacion = _context.Evaluaciones.SingleOrDefault(e => e.Id == calificacion.EvaluacionId);
                var calificacionResponse = new CalificacionResponse {
                    Id = calificacion.Id,
                    EstadoCalificacion = calificacion.EstadoCalificacion,
                    Nota = calificacion.Nota,
                    FechaCorregida = calificacion.FechaCorregida,
                    FechaPublicada = calificacion.FechaPublicada,
                    NombreEstudiante = persona.Nombre,
                    ApellidoEstudiante = persona.Apellido,
                    EvaluacionNombre = evaluacion.Titulo,
                    EvaluacionId = evaluacion.Id
                };
                respuesta.Add(calificacionResponse);
            }
            return respuesta;
        }
        public List<CalificacionResponse> obtenerCalificacionesEvaluacion(int EvaluacionId) {
            List<CalificacionResponse> respuesta = new List<CalificacionResponse>();
            var evaluacion = _context.Evaluaciones.SingleOrDefault(e => e.Id == EvaluacionId);
            if (evaluacion == null) {
                throw (new Exception("La calificacion no existe o no fue publicada"));
            }
            var calificaciones = _context.Calificaciones.Where(c => c.EvaluacionId == evaluacion.Id).ToList();
            foreach (var calificacion in calificaciones) {
                var cuenta = _context.Cuenta.SingleOrDefault(c => c.Id == calificacion.EstudianteId);
                var persona = _context.Persona.SingleOrDefault(p => p.Id == cuenta.PersonaId);
                var calificacionResponse = new CalificacionResponse {
                    Id = calificacion.Id,
                    EstadoCalificacion = calificacion.EstadoCalificacion,
                    Nota = calificacion.Nota,
                    FechaCorregida = calificacion.FechaCorregida,
                    FechaPublicada = calificacion.FechaPublicada,
                    NombreEstudiante=persona.Nombre,
                    ApellidoEstudiante=persona.Apellido,
                    EvaluacionId=evaluacion.Id,
                    EvaluacionNombre=evaluacion.Titulo
                };
                respuesta.Add(calificacionResponse);
            }
            return respuesta;
        }

        public RespuestasResponse obtenerRespuestasEvaluacion(int EvaluacionId, int EstudianteId) {
            RespuestasResponse response = new RespuestasResponse {
                desarrollos = new List<RespuestaDesarrolloResponse>(),
                vofs = new List<RespVerdaderoFalsoResponse>()
            };
            var vofs = _context.VerdaderoFalso.Where(v => v.EvaluacionId == EvaluacionId).ToList();
            foreach (var vof in vofs) {
                var respVerdaderoFalsoResponse = new RespVerdaderoFalsoResponse {
                    Id = vof.Id,
                    Frase = vof.Frase,
                    MultipleOpcion = vof.MultipleOpcion,
                    Opciones = new List<RespuestaOpcionResponse>()
                };
                var opciones = _context.OpcionesVoF.Where(o => o.VerdaderoFalsoId == vof.Id).ToList();
                foreach (var opc in opciones) {
                    var respuestaVof = _context.RespuestaVoF.SingleOrDefault(v => v.EstudianteId == EstudianteId && v.OpcionId == opc.Id);
                    var respuestaVofResponse = new RespuestaVoFResponse {
                        Id = respuestaVof.Id,
                        Eleccion = respuestaVof.Eleccion
                    };
                    var respuestaOpciones = new RespuestaOpcionResponse {
                        Id = opc.Id,
                        Frase = opc.Frase,
                        respuesta = respuestaVofResponse
                    };
                    respVerdaderoFalsoResponse.Opciones.Add(respuestaOpciones);
                }
                response.vofs.Add(respVerdaderoFalsoResponse);
            }
            var des = _context.Desarrollo.Where(d => d.EvaluacionId == EvaluacionId).ToList();
            foreach (var desarrollo in des) {
                var respuestaDesarrollo = _context.RespuestaDesarrollo.SingleOrDefault(d => d.EstudianteId == EstudianteId && d.DesarrolloId == desarrollo.Id);
                var responseDesarrollo = new RespuestaDesarrolloResponse {
                    Id = respuestaDesarrollo.Id,
                    Puntaje = respuestaDesarrollo.Puntaje,
                    Respuesta = respuestaDesarrollo.Respuesta,
                    Pregunta = desarrollo.Pregunta
                };
                response.desarrollos.Add(responseDesarrollo);
            }
            return response;
        }
      public bool FechaLimiteEvaluacion(int IdEvaluacion) {
            var fechaActual = DateTime.Now;
            Evaluacion e=_context.Evaluaciones.Find(IdEvaluacion);
            if (e.Fecha>= fechaActual) {
                return true;
            }
            return false;
        }

        public List<EvaluacionCursoResponse> ObtenerEvaluacionesDelCurso(int CursoId) {
            List<EvaluacionCursoResponse> lst = new List<EvaluacionCursoResponse>();
            var evaluacionesCurso=_context.Evaluaciones.Include(x => x.SeccionTemplate)
                                .Include(x=>x.SeccionTemplate.Curso)
                                .Where(x => x.SeccionTemplate.Curso.Id==CursoId).ToList();

            foreach(var ec in evaluacionesCurso) {
         
                var califacion = _context.Calificaciones
                    .Include(x => x.Estudiante)
                    .Include(x => x.Estudiante.PersonaCuenta).Where(i=>i.EvaluacionId==ec.Id).ToList();
                foreach (var c in califacion) {

                    var ecr = new EvaluacionCursoResponse() {
                        EstudianteId=c.EstudianteId,
                        EvaluacionId = ec.Id,
                        EvaluacionTitulo = ec.Titulo,
                        CiEstudiante = c.Estudiante.PersonaCuenta.Ci,
                        NombreEstudiante = c.Estudiante.PersonaCuenta.Nombre,
                        ApellidoEstudiante = c.Estudiante.PersonaCuenta.Apellido,
                        NotaEstudiante = c.Nota,
                        EstadoCalifiacion= c.EstadoCalificacion,
                        EsArchivo = ec.EsArchivo,
                        TipoEvaluacion = ec.TipoEvaluacion,
                        CalificacionAprobacion = ec.CalificacionAprobacion
                    };
                    var archivo = _context.ArchivoEvaluaciones.SingleOrDefault(x => x.CuentaId == c.EstudianteId && x.EvaluacionId == ec.Id);

                    if (archivo==null) {
                        ecr.NombreArchivo = null;
                    } else {
                        ecr.NombreArchivo = archivo.Nombre;
                    }

                    lst.Add(ecr);
                }
            }
            return lst;
        }

    public int ObtenerIdCalifacion(int idEvaluacion, int idEstudiante) {
            return _context.Calificaciones.SingleOrDefault(x => x.EstudianteId == idEstudiante && x.EvaluacionId == idEvaluacion).Id;
    }

    public void EditarCalifacion(int idEvaluacion,int idEstudiante,int Nota) {
            Calificacion c =_context.Calificaciones.SingleOrDefault(x=>x.EvaluacionId==idEvaluacion && x.EstudianteId==idEstudiante);
            c.Nota=Nota;
            c.EstadoCalificacion = "Corregido";
            _context.SaveChanges();
        }
    }
}