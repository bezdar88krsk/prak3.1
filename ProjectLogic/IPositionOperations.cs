using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLogic
{
    public interface IPositionOperations
    {
        /// <summary>
        /// Конвертирует текст в позицию
        /// </summary>
        /// <param name="text"></param>
        /// <returns>возвращщает позицию</returns>
        Position ConvertPosition(string text);
        /// <summary>
        /// Конвертирует текст в позицию
        /// </summary>
        /// <param name="text"></param>
        /// <returns>возвращщает позицию</returns>
        Position ConvertPosition(int index);
        /// <summary>
        /// Возвращает массив всех позиций
        /// </summary>
        /// <returns>возвращает массив строк позиций</returns>
        string[] GetPositions();

    }
}
