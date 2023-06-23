using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using V7.BaseApplication.Utilies.Models;

namespace V7.BaseApplication.Utilies.Helpers
{
	public static class EnumarationExtentions
	{
		public static string GetDescription(this Enum enumValue)
		///
		{
			return enumValue.GetType()
				   .GetMember(enumValue.ToString())
				   .First()
				   .GetCustomAttribute<DescriptionAttribute>()?
				   .Description ?? enumValue.ToString();
		}
		public static List<LookUpViewModel> GetLookUpViewModels(this Type type, params Enum[] filter)
		{
			var output = new List<LookUpViewModel>();
			var enumItems = Enum.GetValues(type).OfType<Enum>().ToList();
			if (filter != null)
			{
				enumItems = enumItems.Except(filter).ToList();

			}
			foreach (var item in enumItems)
			{
				output.Add(new LookUpViewModel
				{
					Value = Convert.ToInt32(item),
					ValueText = item.ToString(),
					Description = item.GetDescription(),
				});
			}

			return output;
		}
	}
}
