namespace MarineFarm.Entitys
{
    /// <summary>
    /// Esta tabla es un pivote de turno por cada cargo
    /// </summary>
    public class Equipo
    {
        /// <summary>
        /// turno al que pertenece el equipo
        /// </summary>
        public int Turnoid { get; set; }
        /// <summary>
        /// cargo que se le asigna al equipo
        /// </summary>
        public int Cargoid { get; set; }

        /// <summary>
        /// nav prop
        /// </summary>
        public Turnos Turno { get; set; }
        /// <summary>
        /// nav prop
        /// </summary>
        public Cargos Cargo { get; set; }
        /// <summary>
        /// cantidad cubierta
        /// </summary>
        public int CantCubierta { get; set; }
        /// <summary>
        /// Costo por operario
        /// </summary>
        public double CostoOperario { get; set; }
    }
}
