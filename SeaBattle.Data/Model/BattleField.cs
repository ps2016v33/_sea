using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace SeaBattle.Data.Model
{
    public class BattleField
    {
        public int Id { get; set; }

        [Column(TypeName = "XML"), Required]
        public string Field { get; set; }

        [NotMapped]
        public XmlDocument Schema
        {
            get
            {
                var doc = new XmlDocument();
                doc.LoadXml(Field);
                return doc;
            }
            set { Field = value.InnerXml; }
        }
    }
}
