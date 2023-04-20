using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZulipStatusUpdater.Models
{
    /// <summary>
    /// Profile Fields
    /// </summary>
    [XmlRoot("ProfileFields")]
    public class ProfileFields
    {
        [XmlInclude(typeof(ProfileField))] // include type class Person
        public class PersonalList
        {
            [XmlArray("ProfileFieldArray")]
            [XmlArrayItem("ProfileFieldObject")]
            public List<ProfileField> ProfileFields = new List<ProfileField>();

            [XmlElement("Listname")]
            public string Listname { get; set; }

            // Konstruktoren 
            public PersonalList() { }

            public PersonalList(string name)
            {
                this.Listname = name;
            }

            public void AddField(ProfileField field)
            {
                ProfileFields.Add(field);
            }
        }

    }
}

[XmlType("ProfileField")] // define Type
public class ProfileField
{
    public enum FieldType
    {
        SHORT_TEXT = 1,
        LONG_TEXT = 2,
        LIST_OF_OPTIONS,
        DATE_PICKER,
        LINK,
        PERSON_PICKER,
        EXTERNAL_ACCOUNT,
        PRONOUNS
    }



    [XmlElement("Name", DataType = "string")]
    public string Name { get; set; }

    [XmlElement("ID")]
    public int Id { get; set; }

    [XmlElement("Order")]
    public int Order { get; set; }

    [XmlElement("Type")]
    public FieldType Type { get; set; }

    [XmlElement("FieldData")]
    public string FieldData { get; set;}

    // Konstruktoren 
    //public ProfileField() { }

    public ProfileField(string name, int id, int order, FieldType type)
    {
        this.Name = name;
        this.Order = order;
        this.Type = type;
        this.Id = id;
        this.FieldData = "";
    }
}
