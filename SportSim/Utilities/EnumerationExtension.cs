using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;

namespace Simocracy.SportSim
{
	public class EnumerationExtension : MarkupExtension
	{
		private Type _enumType;


		public EnumerationExtension(Type enumType)
		{
			if(enumType == null)
				throw new ArgumentNullException("enumType");

			EnumType = enumType;
		}

		public Type EnumType
		{
			get { return _enumType; }
			private set
			{
				if(_enumType == value)
					return;

				var enumType = Nullable.GetUnderlyingType(value) ?? value;

				if(enumType.IsEnum == false)
					throw new ArgumentException("Type must be an Enum.");

				_enumType = value;
			}
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var enumValues = Enum.GetValues(EnumType);
			ArrayList filteredValues = new ArrayList();
			foreach(Enum wValue in enumValues)
			{
				FieldInfo fi = EnumType.GetField(wValue.ToString());
				if(null != fi)
				{
					BrowsableAttribute[] wBrowsableAttributes = fi.GetCustomAttributes(typeof(BrowsableAttribute), true) as BrowsableAttribute[];
					if(wBrowsableAttributes.Length > 0 && wBrowsableAttributes[0].Browsable == false)
						continue;
				}
				filteredValues.Add(wValue);
			}

			return (
			  from object enumValue in filteredValues
			  select new EnumerationMember
			  {
				  Value = enumValue,
				  Description = GetDescription(enumValue)
			  }).ToArray();
		}

		private string GetDescription(object enumValue)
		{
			var descriptionAttribute = EnumType
			  .GetField(enumValue.ToString())
			  .GetCustomAttributes(typeof(DescriptionAttribute), false)
			  .FirstOrDefault() as DescriptionAttribute;


			return descriptionAttribute != null
			  ? descriptionAttribute.Description
			  : enumValue.ToString();
		}

		public class EnumerationMember
		{
			public string Description { get; set; }
			public object Value { get; set; }
		}
	}
}
