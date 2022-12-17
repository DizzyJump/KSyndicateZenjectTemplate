using UnityEngine;

namespace CodeBase.Services.RandomizerService
{
    public class RandomizerService : IRandomizerService
    {
        System.Collections.Generic.Stack<float> NormalValues = new System.Collections.Generic.Stack<float>();
        
        public int Next(int min, int max) =>
            Random.Range(min, max);

        /// <summary>
        /// возвращает случайно число (нормальное распределение) с матожиданием mean и среднеквадратичным отклонением dev
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="dev"></param>
        /// <returns></returns>
        public float NormalDistribution(float mean, float dev) => NormalDistribution() * dev + mean;

        /// <summary>
        /// возвращает случайно число (нормальное распределение) от 0 до 1 с матожиданием 0.5
        /// </summary>
        /// <returns></returns>
        public float NormalDistribution01 => Clamp01(NormalDistribution() / 6.0f + 0.5f);

        /// <summary>
        /// возвращает случайно число (нормальное распределение) от -1 до 1 с матожиданием 0
        /// </summary>
        /// <returns></returns>
        public float NormalDistribution11 => Mathf.Clamp(NormalDistribution() / 3.0f, -1f, 1f);


        /// <summary>
        /// Обрезание значения по границам 0 и 1
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private float Clamp01(float val) => Mathf.Clamp(val, 0.0f, 1.0f);

        /// <summary>
        /// возвращает случайно число (равномерно распределенное) в диапазоне от -1f до 1f
        /// </summary>
        /// <returns></returns>
        public float RandomFloat11 => Random.value * 2f - 1f;

        /// <summary>
        /// возвращает случайно число (нормальное распределение)
        /// </summary>
        /// <returns></returns>
        private float NormalDistribution()
        {
            if(NormalValues.Count > 0)
                return NormalValues.Pop();
            float u = 0;
            float v = 0;
            float s = 0;
            do
            {
                u = RandomFloat11;
                v = RandomFloat11;
                s = u * u + v * v;
            } while(s > 1.0 || s == 0.0);
            float r = Mathf.Sqrt(-2 * Mathf.Log(s) / s);
            NormalValues.Push(r * u);
            return r * v;
        }
    }
}