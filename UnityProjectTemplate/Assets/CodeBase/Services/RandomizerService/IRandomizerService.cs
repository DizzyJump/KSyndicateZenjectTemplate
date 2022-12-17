namespace CodeBase.Services.RandomizerService
{
    public interface IRandomizerService
    {
        int Next(int min, int max);

        /// <summary>
        /// возвращает случайно число (нормальное распределение) с матожиданием mean и среднеквадратичным отклонением dev
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="dev"></param>
        /// <returns></returns>
        float NormalDistribution(float mean, float dev);

        /// <summary>
        /// возвращает случайно число (нормальное распределение) от 0 до 1 с матожиданием 0.5
        /// </summary>
        /// <returns></returns>
        float NormalDistribution01 { get; }

        /// <summary>
        /// возвращает случайно число (нормальное распределение) от -1 до 1 с матожиданием 0
        /// </summary>
        /// <returns></returns>
        float NormalDistribution11 { get; }

        /// <summary>
        /// возвращает случайно число (равномерно распределенное) в диапазоне от -1f до 1f
        /// </summary>
        /// <returns></returns>
        float RandomFloat11 { get; }
    }
}