using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System;

namespace ORM
{
    public class Item:DevExpress.Xpo.XPObject
    {
        public Item()
        {

        }

        public Item(Session session) : base(session)
        {

        }

        public Item(Session session, XPClassInfo classInfo) : base(session, classInfo)
        {

        }


        string description;
        string text;
        string id;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Id
        {
            get => id;
            set => SetPropertyValue(nameof(Id), ref id, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Text
        {
            get => text;
            set => SetPropertyValue(nameof(Text), ref text, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }
    }
}
