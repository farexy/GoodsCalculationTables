using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculation.DataTables;

namespace Calculation
{
    class Serializer
    {
        private static BinaryFormatter formatter;

        public static void WriteToFile(String filePath, AbstractTable dataTable)
        {
            formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, dataTable);
            }
        }

        public static AbstractTable ReadFromFile(String fileName)
        {
            formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                return (AbstractTable)formatter.Deserialize(fs);
            }
        }
    }
}
