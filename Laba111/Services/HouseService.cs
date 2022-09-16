using Java.Util;
using Laba111.Model;
using Laba111.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Android.Icu.Text.CaseMap;

namespace Laba111.Services
{
    internal class HouseService
    {
        // Создаем список для хранения данных из источника
        List<HouseService> HouseList = new();

        // Метод GetHouse() служит для извлечения и сруктурирования данных
        // в соответсвии с существующей моделью данных
        public async Task<IEnumerable<HouseService>> GetHouse()
        {
            // Если список содержит какие-то элементы
            // то вернется последовательность с содержимым этого списка
            if (HouseList?.Count > 0)
                return HouseList;

            // В данном блоке кода осуществляется подключение, чтение
            // и дессериализация файла - источника данных
            using var stream = await FileSystem.OpenAppPackageFileAsync("House.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            HouseList = JsonSerializer.Deserialize<List<HouseService>>(contents);

            return HouseList;
        }
    }

}
