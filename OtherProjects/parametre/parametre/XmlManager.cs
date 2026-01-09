using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace parametre
{
    public static class XmlManager
    {

        public static List<ItemWeapon> allWeapons = new List<ItemWeapon>();

        public static void SaveXMLWeapons(List<ItemWeapon> weapons)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<ItemWeapon>));
            StreamWriter writer = new StreamWriter("Weapons.xml");
            xml.Serialize(writer, weapons);
            writer.Close();
        }
        public static void LoadXMLWeapons()
        {

            XmlSerializer xml = new XmlSerializer(typeof(List<ItemWeapon>));
            StreamReader reader = new StreamReader("Weapons.xml");
            allWeapons = (List<ItemWeapon>)xml.Deserialize(reader);
            reader.Close();

        }
            
        }
    }

