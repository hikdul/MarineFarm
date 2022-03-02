namespace MarineFarm.Helpers
{
    /// <summary>
    /// solo es una clase auxiliar con funciones genericas sobre fechas
    /// </summary>
    public static class DateGame
    {
        /// <summary>
        /// para saber los dias de un mes dependiendo de su año
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int DaysInMont(DateTime date)
        {

            int Mont = date.Month;

            if (Mont == 2)
                return date.DayOfYear == 365 ? 28 : 29;
            if (Mont == 4 || Mont == 6 || Mont == 9 || Mont == 11)
                return 30;
            return 31;

        }
    }
}
