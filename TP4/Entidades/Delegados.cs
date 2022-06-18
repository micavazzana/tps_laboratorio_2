using System.Collections.Generic;

namespace Entidades
{
    //Declaracion de delegados

    ///Delegado que sera utilizado para gestionar una tarea secundaria
    public delegate void DelegadoPresupuestoTotal(List<Equipo> listado, bool esEstudiante);
    ///Delegado que sera utilizado para declarar un evento
    public delegate void DelegadoConfirmaModificacion(bool confirmaModificacion);
}
